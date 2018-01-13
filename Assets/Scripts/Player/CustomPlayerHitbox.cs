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
    public float lightsOutFadeTime = 5.0f;

    NewCollider2D dangersController;
    NewCollider2D savesController;
    NewCollider2D warpsController;
    NewCollider2D jumpRefreshersController;
    NewCollider2D triggersController;
    LightsOutController lightsOut;
    Player player;
    bool collidingWithWarp = false;
    
    void Start()
    {
        NewCollider2D[] newColliders = GetComponents<NewCollider2D>();
        dangersController = newColliders[0];
        savesController = newColliders[1];
        warpsController = newColliders[2];
        jumpRefreshersController = newColliders[3];
        triggersController = newColliders[4];
        player = transform.parent.GetComponent<Player>();

        if (GameObject.FindGameObjectWithTag("LightsOutController") != null)
        {
            lightsOut = GameObject.FindGameObjectWithTag("LightsOutController").GetComponent<LightsOutController>();
        }
    }
    
    void FixedUpdate()
    {
        dangersController.Move(player.Velocity * Mathf.Epsilon);
        savesController.Move(player.Velocity * Mathf.Epsilon);
        warpsController.Move(player.Velocity * Mathf.Epsilon);
        jumpRefreshersController.Move(player.Velocity * Mathf.Epsilon);
        triggersController.Move(player.Velocity * Mathf.Epsilon);

        transform.position = player.transform.position;
    }

    void Update()
    {
        if (player.isDead)
        {
            return;
        }

        // Start lights out when starting not on save
        if (lightsOut != null && player.collidingSave == null && !lightsOut.doFading)
        {
            lightsOut.BeginFade(SaveLoadManager.data.lastLightsOutTime);
        }

        // If colliding with killer object (which is not transparent) - die
        if (dangersController.collisions.below || dangersController.collisions.above ||
            dangersController.collisions.left || dangersController.collisions.right)
        {
            if (dangersController.collisions.target != null)
            {
                SpriteRenderer sr = dangersController.collisions.target.GetComponent<SpriteRenderer>();

                if (sr != null && Mathf.Approximately(sr.color.a, 1.0f))
                {
                    player.Die();
                }
            }
        }
        
        // If colliding with a save - store it if not already
        if ((savesController.collisions.left || savesController.collisions.right ||
            savesController.collisions.above || savesController.collisions.below) &&
            savesController.collisions.target.tag != "BulletBlocker")
        {
            if (player.collidingSave == null || (lightsOut != null && lightsOut.doFading))
            {
                player.collidingSave = savesController.collisions.target;

                // Stop lights out gimmick
                if (lightsOut != null)
                {
                    SaveLoadManager.data.lastLightsOutTime = savesController.collisions.target.GetComponent<Save>().lightsOutFadeTime;
                    lightsOut.StopFade();
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
                if (lightsOut != null && !lightsOut.doFading)
                {
                    lightsOut.BeginFade(SaveLoadManager.data.lastLightsOutTime);
                }
            }
        }

        // If colliding with trigger - activate it
        if (triggersController.collisions.below || triggersController.collisions.above ||
            triggersController.collisions.left || triggersController.collisions.right)
        {
            if (triggersController.collisions.target != null)
            {
                // Based on trigger tag activate different events
                switch (triggersController.collisions.target.tag)
                {
                    case "HyenaTrigger":
                        triggersController.collisions.target.GetComponent<HyenaTrigger>().Trigger();
                        break;

                    case "TipTrigger":
                        triggersController.collisions.target.GetComponent<TipTrigger>().Trigger();
                        break;

                    case "SadTromboneTrigger":
                        triggersController.collisions.target.GetComponent<SadTromboneTrigger>().Trigger();
                        break;

                    case "Stage4TrollWarp":
                        triggersController.collisions.target.GetComponent<Stage4TrollWarp>().Trigger();
                        break;

                    default:
                        break;
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
                player.affectedByJumpRefresher = true;
            }

            jumpRefreshersController.collisions.target.GetComponent<JumpRefresher>().ResetRefresher();
        }
    }
}
