///////////////////////////////////////////////////////////////////////
//
//      PlayerDangerCollider.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Controls the collider that makes player recieve fatal damage (get killed)
// UPD: also detects collisions with save, since for some reason it doesn't work
//   on actual player object
public class PlayerDangerCollider : MonoBehaviour
{
    NewCollider2D dangersController;
    NewCollider2D savesController;
    Player player;

    void Start()
    {
        NewCollider2D[] newColliders = GetComponents<NewCollider2D>();
        dangersController = newColliders[0];
        savesController = newColliders[1];
        player = transform.parent.GetComponent<Player>();
    }
    
    void FixedUpdate()
    {
        dangersController.Move(player.Velocity * Mathf.Epsilon);
        savesController.Move(player.Velocity * Mathf.Epsilon);
    }

    void Update()
    {
        // If colliding with killer object - die
        if (dangersController.collisions.below || dangersController.collisions.above ||
            dangersController.collisions.left || dangersController.collisions.right)
        {
            player.Die();
        }
        
        // If colliding with a save - store it
        if ((savesController.collisions.left || savesController.collisions.right ||
            savesController.collisions.above || savesController.collisions.below) &&
            savesController.collisions.target.tag != "BulletBlocker")
        {
            player.collidingSave = savesController.collisions.target;
        }
        else
        {
            player.collidingSave = null;
        }
    }
}
