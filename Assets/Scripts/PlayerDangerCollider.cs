///////////////////////////////////////////////////////////////////////
//
//      PlayerDangerCollider.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class PlayerDangerCollider : MonoBehaviour
{
    NewCollider2D dangersController;
    Player player;

    void Start()
    {
        dangersController = GetComponent<NewCollider2D>();
        player = transform.parent.GetComponent<Player>();
    }

    // Called 50 times a second
    void FixedUpdate()
    {
        dangersController.Move(player.Velocity * Mathf.Epsilon);
    }

    void Update()
    {
        // If colliding with killer object - die
        if (dangersController.collisions.below || dangersController.collisions.above ||
            dangersController.collisions.left || dangersController.collisions.right)
        {
            player.Die();
        }
    }
}
