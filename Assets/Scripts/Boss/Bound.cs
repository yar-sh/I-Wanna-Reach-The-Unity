///////////////////////////////////////////////////////////////////////
//
//      Bound.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Bound : MonoBehaviour
{
    [HideInInspector]
    public bool collide = true;

    GMComponent gmc;
    NewCollider2D obstacles;

    void Start()
    {
        gmc = GetComponent<GMComponent>();
        obstacles = GetComponent<NewCollider2D>();

        gmc.ImageSpeed = 0.0f;
        gmc._applySpeed = false;
    }
    
    void FixedUpdate()
    {
        if (!collide)
        {
            if (!gmc._applySpeed)
            {
                gmc._applySpeed = true;
            }

            return;
        }

        obstacles.Move(gmc.Velocity);

        if (obstacles.collisions.above || obstacles.collisions.below)
        {
            gmc.Direction = -gmc.Direction;
        }
        else if (obstacles.collisions.left || obstacles.collisions.right)
        {
            gmc.Direction = -gmc.Direction + 180.0f;
        }
    }
}
