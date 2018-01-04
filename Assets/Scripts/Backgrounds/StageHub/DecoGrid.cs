///////////////////////////////////////////////////////////////////////
//
//      DecoGrid.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

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
