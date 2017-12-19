///////////////////////////////////////////////////////////////////////
//
//      TestFillerBlock.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class TestFillerBlock : MonoBehaviour
{
    public GameObject FillBlock;

    void Start()
    {
        // Vertical outside borders
        for (int i = 0; i < GM.N_TILES_VER; i++)
        {
            Instantiate(FillBlock, new Vector3(0, i * GM.TILE_SIZE_PX), Quaternion.identity);
            Instantiate(FillBlock, new Vector3(GM.TILE_SIZE_PX * (GM.N_TILES_HOR - 1), i * GM.TILE_SIZE_PX), Quaternion.identity);
        }

        // Horizontal outside borders
        for (int i = 0; i < GM.N_TILES_HOR; i++)
        {
            Instantiate(FillBlock, new Vector3(i * GM.TILE_SIZE_PX, 0), Quaternion.identity);
            Instantiate(FillBlock, new Vector3(i * GM.TILE_SIZE_PX, GM.TILE_SIZE_PX * (GM.N_TILES_VER-1)), Quaternion.identity);
        }

        // Inner vertical borders
        for (int i = 0; i < GM.N_TILES_VER; i++)
        {
            Instantiate(FillBlock, new Vector3(GM.TILE_SIZE_PX * 6, i * GM.TILE_SIZE_PX), Quaternion.identity);
            Instantiate(FillBlock, new Vector3(GM.TILE_SIZE_PX * (GM.N_TILES_HOR - 6), i * GM.TILE_SIZE_PX), Quaternion.identity);
        }
    }
}
