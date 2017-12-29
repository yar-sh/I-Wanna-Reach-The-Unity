///////////////////////////////////////////////////////////////////////
//
//      RaycastController.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//      Heavily based on https://github.com/SebLague/2DPlatformer-Tutorial
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public struct RaycastOrigins
{
    public Vector2 topLeft, topRight, bottomLeft, bottomRight;
}

// Raycasting monstrosity to detect collisions
public class RaycastController : MonoBehaviour
{
    public LayerMask collisionMask;

    [HideInInspector]
    public const float smallValue = 0.015f;
    [HideInInspector]
    public RaycastOrigins raycastOrigins;
    [HideInInspector]
    public int hRayCount;
    [HideInInspector]
    public int vRayCount;
    [HideInInspector]
    public float hRaySpacing;
    [HideInInspector]
    public float vRaySpacing;
    [HideInInspector]
    public BoxCollider2D boxCollider;

    const float dstBetweenRays = 1.0f;

    public virtual void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public virtual void Start()
    {
        CalculateRaySpacing();
    }

    // Recalculate the ray collisions
    public void UpdateRaycastOrigins()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(smallValue * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    // Place the ray somewhere relative to the boxcollider
    public void CalculateRaySpacing()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(smallValue * -2);

        float boundsWidth = bounds.size.x;
        float boundsHeight = bounds.size.y;

        hRayCount = Mathf.RoundToInt(boundsHeight / dstBetweenRays);
        vRayCount = Mathf.RoundToInt(boundsWidth / dstBetweenRays);

        hRaySpacing = bounds.size.y / (hRayCount - 1);
        vRaySpacing = bounds.size.x / (vRayCount - 1);
    }
}
