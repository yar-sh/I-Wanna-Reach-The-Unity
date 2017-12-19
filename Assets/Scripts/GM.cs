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
    public const uint TILE_SIZE_PX = 32;
    public const uint N_TILES_HOR = 32;
    public const uint N_TILES_VER = 18;

    public static uint fps = 50;
    public static float constant
    {
        get
        {
            return Time.deltaTime * fps;
        }
    }
}
