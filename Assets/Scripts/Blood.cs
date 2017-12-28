///////////////////////////////////////////////////////////////////////
//
//      Blood.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Blood : MonoBehaviour
{
    bool landed = false;
    NewCollider2D obstaclesController;
    Vector3 velocity;

    void Start()
    {
        obstaclesController = GetComponent<NewCollider2D>();
        velocity.x = Random.Range(-6.0f, 6.0f);
        velocity.y = Random.Range(-6.0f, 6.0f);
    }
    
    void FixedUpdate()
    {
        if (landed)
        {
            return;
        }

        velocity.y += GM.gravity * (0.3f + Random.Range(0.1f,0.4f));
        obstaclesController.Move(velocity);

        if (obstaclesController.collisions.below || obstaclesController.collisions.above ||
            obstaclesController.collisions.left || obstaclesController.collisions.right)
        {
            landed = true;
        }
    }
}
