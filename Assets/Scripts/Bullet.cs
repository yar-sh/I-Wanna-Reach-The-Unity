///////////////////////////////////////////////////////////////////////
//
//      Bullet.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int faceDir = 1;
    public float moveSpeed = 666.0f;
    public uint maxBullets = 5;

    bool collidesWithSave = false;
    NewCollider2D obstaclesController;
    NewCollider2D savesController;
    Camera camera;
    Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        if (FindObjectsOfType<Bullet>().Length > maxBullets)
        {
            Destroy(gameObject);
        }

        NewCollider2D[] newColliders = GetComponents<NewCollider2D>();
        savesController = newColliders[0];
        obstaclesController = newColliders[1];

        camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        velocity.x = faceDir * moveSpeed;

        obstaclesController.Move(velocity * Time.deltaTime, false);
        savesController.Move(new Vector2(Mathf.Epsilon, 0) * Time.deltaTime, false);

        if (!savesController.collisions.left && !savesController.collisions.right && collidesWithSave)
        {
            collidesWithSave = false;
        }

        if ((savesController.collisions.left || savesController.collisions.right) &&
            !collidesWithSave)
        {
            collidesWithSave = true;

            savesController.collisions.target.GetComponent<Save>().SaveGame();
        }

        Vector3 pos = transform.position;

        // If colliding or outside of the camera view
        if (obstaclesController.collisions.right || obstaclesController.collisions.left ||
            pos.x < camera.transform.position.x - (GM.N_TILES_HOR + 1) / 2 * GM.TILE_SIZE_PX ||
            pos.x > camera.transform.position.x + (GM.N_TILES_HOR + 1) / 2 * GM.TILE_SIZE_PX)
        {
            Destroy(gameObject);
        }
    }
}
