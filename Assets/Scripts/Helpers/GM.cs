///////////////////////////////////////////////////////////////////////
//
//      GM.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Since this game/project is based on IWBTG fangames, it is also based
// on a GameMaker:Studio engine. I have this class a helper substituion
// for GM:S functions/constants/etc
public static class GM
{
    // Constants for scene/screen/display/room/tile sizes
    public const uint TILE_SIZE_UNITS = 32;
    public const uint N_TILES_HOR = 34;
    public const uint N_TILES_VER = 19;
    public const uint fps = 50;
    public const float gravity = -0.4f;
    public const float offsetX = 144.0f;
    public const float offsetY = 576.0f;


    // MAJYK speed constant. Use it in Update() instead of just deltaTime
    // to get the same speed as in GameMaker
    public static float Constant
    {
        get
        {
            return fps * Time.deltaTime * Time.timeScale;
        }
    }
}
