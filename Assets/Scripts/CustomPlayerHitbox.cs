///////////////////////////////////////////////////////////////////////
//
//      CustomPlayerHitbox.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Custom collider for player. Player has a default collider for collisions with
// obstacles, this one is for dangers, saves, warps and jump refreshers
public class CustomPlayerHitbox : MonoBehaviour
{
    public float lightsOutFadeTime = 7.0f;

    NewCollider2D dangersController;
    NewCollider2D savesController;
    NewCollider2D warpsController;
    NewCollider2D jumpRefreshersController;
    Player player;
    bool collidingWithWarp = false;
    
    void Start()
    {
        NewCollider2D[] newColliders = GetComponents<NewCollider2D>();
        dangersController = newColliders[0];
        savesController = newColliders[1];
        warpsController = newColliders[2];
        jumpRefreshersController = newColliders[3];
        player = transform.parent.GetComponent<Player>();
    }
    
    void FixedUpdate()
    {
        dangersController.Move(player.Velocity * Mathf.Epsilon);
        savesController.Move(player.Velocity * Mathf.Epsilon);
        warpsController.Move(player.Velocity * Mathf.Epsilon);
        jumpRefreshersController.Move(player.Velocity * Mathf.Epsilon);
    }

    void Update()
    {
        // If colliding with killer object - die
        if (dangersController.collisions.below || dangersController.collisions.above ||
            dangersController.collisions.left || dangersController.collisions.right)
        {
            player.Die();
        }
        
        // If colliding with a save - store it if not already
        if ((savesController.collisions.left || savesController.collisions.right ||
            savesController.collisions.above || savesController.collisions.below) &&
            savesController.collisions.target.tag != "BulletBlocker")
        {
            if (player.collidingSave == null)
            {
                player.collidingSave = savesController.collisions.target;

                // Stop lights out gimmick
                if (GameObject.FindGameObjectWithTag("LightsOutController") != null)
                {
                    GameObject.FindGameObjectWithTag("LightsOutController").GetComponent<LightsOutController>().StopFade();
                }
            }
        }
        else
        {
            // Reset save if not already
            if (player.collidingSave != null)
            {
                player.collidingSave = null;

                // Begin lights out gimmick
                if (GameObject.FindGameObjectWithTag("LightsOutController") != null)
                {
                    GameObject.FindGameObjectWithTag("LightsOutController").GetComponent<LightsOutController>().BeginFade(lightsOutFadeTime);
                }
            }
        }
        
        // If colliding with warp - warp
        if ((warpsController.collisions.below || warpsController.collisions.above ||
            warpsController.collisions.left || warpsController.collisions.right) && !collidingWithWarp)
        {
            // Save time and death data first
            SaveLoadManager.SaveCurrentData();

            // Freeze before transtition animation
            player.isFrozen = true;
            collidingWithWarp = true;

            // Then actually warp
            warpsController.collisions.target.GetComponent<Warp>().DoWarp();
        }
        
        // If colliding with a jump refresher - gain +1 jump and reset jump refresher
        if ((jumpRefreshersController.collisions.below || jumpRefreshersController.collisions.above ||
            jumpRefreshersController.collisions.left || jumpRefreshersController.collisions.right))
        {
            if (player.jumpCount == 0)
            {
                player.jumpCount++;
            }

            jumpRefreshersController.collisions.target.GetComponent<JumpRefresher>().ResetRefresher();
        }
    }
}
