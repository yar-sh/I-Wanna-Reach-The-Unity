///////////////////////////////////////////////////////////////////////
//
//      DecoGrid.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// A decorative grid for stage hub level.
// Moves 50 times a second by 1 pixel in the top left direction
public class DecoGrid : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position += Vector3.up;
        transform.position += Vector3.left;

        if (transform.position.x < 0 || transform.position.y > 640)
        {
            Destroy(gameObject);
        }
    }
}
