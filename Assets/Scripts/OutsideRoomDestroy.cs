///////////////////////////////////////////////////////////////////////
//
//      OutsideRoomDestroy.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Destroyes gameObject when outside of the room bounds
public class OutsideRoomDestroy : MonoBehaviour
{
    public float outerMargin = 64.0f;

    void Update()
    {
        if (transform.position.x < -outerMargin ||
            transform.position.x > (GM.N_TILES_HOR) * GM.TILE_SIZE_UNITS + outerMargin ||
            transform.position.y > (GM.N_TILES_VER) * GM.TILE_SIZE_UNITS + outerMargin ||
            transform.position.y < -outerMargin)
        {
            Destroy(gameObject);
        }
    }
}
