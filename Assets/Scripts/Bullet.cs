///////////////////////////////////////////////////////////////////////
//
//      Bullet.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// A bullet that is shot from the player's gun
public class Bullet : MonoBehaviour
{
    [System.NonSerialized]
    public int faceDir = 1;
    uint maxBullets = 5;
    float moveSpeed = 16.0f;
    uint lifeFixedFrames = 40;
    uint fixedFrameCounter = 0;
    bool collidesWithSave = false;
    NewCollider2D obstaclesController;
    NewCollider2D savesController;
    Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        // At the start ensure we don't have more than max amount of bullets on the screen
        if (FindObjectsOfType<Bullet>().Length > maxBullets)
        {
            // Destroy instantly to prevent calling update
            Destroy(gameObject);
            return;
        }
        
        NewCollider2D[] newColliders = GetComponents<NewCollider2D>();
        savesController = newColliders[0];
        obstaclesController = newColliders[1];
        
        GameManager.Instance.PlaySound("Shoot");
    }

    void FixedUpdate()
    {
        // Destroy bullet if it did not collide with anything for more than 40 fixed frames
        if (fixedFrameCounter > lifeFixedFrames)
        {
            DestroyBullet(false);
        }

        // Calculate velocity
        velocity.x = faceDir * moveSpeed;

        // Calculate collisions
        obstaclesController.Move(velocity);
        savesController.Move(velocity * Mathf.Epsilon);

        fixedFrameCounter++;
    }

    void Update()
    {
        // If colliding with a save blocker
        if (savesController.collisions.left || savesController.collisions.right)
        {
            // Store the thing the bullet collided with
            GameObject target = savesController.collisions.target;

            if (target.tag == "BulletBlocker")
            {
                // Show save blocker
                target.GetComponent<BulletBlocker>().Show();

                // Destroy instantly
                DestroyBullet(true);
                return;
            }
        }

        // If bullet previously was colliding with a save and now it is not,
        //   it is past the save
        if (!savesController.collisions.left && !savesController.collisions.right && collidesWithSave)
        {
            collidesWithSave = false;
        }
        
        // If bullet previously was not colliding with a save and now it is,
        //   it hit the save - save the game
        if ((savesController.collisions.left || savesController.collisions.right) &&
            !collidesWithSave)
        {
            collidesWithSave = true;

            savesController.collisions.target.GetComponent<Save>().SaveGame();
        }

        Vector3 pos = transform.position;

        // If colliding with obstacles or outside of the room
        if (obstaclesController.collisions.right || obstaclesController.collisions.left ||
            pos.x < -GM.TILE_SIZE_UNITS / 2.0f || 
            pos.x > (GM.N_TILES_HOR * GM.TILE_SIZE_UNITS) + GM.TILE_SIZE_UNITS/2.0f)
        {
            GameObject target = obstaclesController.collisions.target;

            // If colliding with destructable object - destruct it
            if (target != null && target.tag == "Destructable")
            {
                target.GetComponent<DestructibleBlock>().Destruct();
            }

            // Destroy instantly with particles
            DestroyBullet(true);
        }
    }

    // Destroys the bullet. Can toggle destroy particle effect on/off
    void DestroyBullet(bool destroyParticles)
    {
        // Draw particles if needed
        if (destroyParticles)
        {
            ParticleSystem ps = GetComponentInChildren<ParticleSystem>();

            ps.transform.parent = null;
            ps.Play();
        }
        
        Destroy(gameObject);
    }
}
