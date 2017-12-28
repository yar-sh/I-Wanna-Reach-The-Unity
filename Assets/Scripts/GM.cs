///////////////////////////////////////////////////////////////////////
//
//      GM.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public static class GM
{
    // Constants for scene/screen/display/room/tile sizes
    public const uint TILE_SIZE_UNITS = 32;
    public const uint N_TILES_HOR = 34;
    public const uint N_TILES_VER = 19;
    public const uint fps = 50;
    public const float gravity = -0.4f;

    public static float Constant
    {
        get
        {
            return fps * Time.deltaTime * Time.timeScale;
        }
    }
}
