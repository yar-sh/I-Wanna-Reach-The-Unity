///////////////////////////////////////////////////////////////////////
//
//      NewCollider2D.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//      Heavily based on https://github.com/SebLague/2DPlatformer-Tutorial
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Struct for storing information about collision event
public struct CollisionInfo
{
    public bool above, below, left, right;
    public int faceDir;
    public Vector2 moveAmountOld;
    public GameObject target;

    public void Reset()
    {
        above = below = left = right = false;
        target = null;
    }
}

// Custom collision system based on raycasting
public class NewCollider2D : RaycastController
{
    [HideInInspector]
    public CollisionInfo collisions;
    
    public override void Start()
    {
        base.Start();
        collisions.faceDir = 1;
    }

    // Move by moveAmount in the direction and update where collisions happen
    public void Move(Vector2 moveAmount)
    {
        UpdateRaycastOrigins();

        collisions.Reset();
        collisions.moveAmountOld = moveAmount;
        
        if (moveAmount.x != 0)
        {
            collisions.faceDir = (int)Mathf.Sign(moveAmount.x);
        }

        HorizontalCollisions(ref moveAmount);
        VerticalCollisions(ref moveAmount);
        
        transform.Translate(moveAmount);
    }

    // Calculate collisions with horizontal surfaces
    void HorizontalCollisions(ref Vector2 moveAmount)
    {
        float directionX = collisions.faceDir;
        float rayLength = Mathf.Abs(moveAmount.x) + smallValue;

        if (Mathf.Abs(moveAmount.x) < smallValue)
        {
            rayLength = 2 * smallValue;
        }

        for (int i = 0; i < hRayCount; i++)
        {
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (hRaySpacing * i);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            if (!hit)
            {
                continue;
            }
            
            moveAmount.x = (hit.distance - smallValue) * directionX;
            rayLength = hit.distance;
                
            collisions.target = hit.collider.gameObject;

            collisions.left = directionX == -1;
            collisions.right = directionX == 1;
        }
    }

    // Calculate collisions with vertical surfaces
    void VerticalCollisions(ref Vector2 moveAmount)
    {
        float directionY = Mathf.Sign(moveAmount.y);
        float rayLength = Mathf.Abs(moveAmount.y) + smallValue;

        for (int i = 0; i < vRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (vRaySpacing * i + moveAmount.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            if (!hit)
            {
                continue;
            }
            
            moveAmount.y = (hit.distance - smallValue) * directionY;
            rayLength = hit.distance;
            
            collisions.target = hit.collider.gameObject;

            collisions.below = directionY == -1;
            collisions.above = directionY == 1;
        }
    }
}