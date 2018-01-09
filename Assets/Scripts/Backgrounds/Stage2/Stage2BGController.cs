///////////////////////////////////////////////////////////////////////
//
//      Stage2BGController.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Controls the background for stage 2
// Spawns decorative spirographs randomly
public class Stage2BGController : MonoBehaviour
{

    public GameObject decoSpiro;
    public GameObject backgroundObject;

    void Start()
    {
        Instantiate(backgroundObject);
        SpawnSpiro();
    }

    void SpawnSpiro()
    {
        Instantiate(
            decoSpiro,
            new Vector3(
                Random.Range(0, GM.N_TILES_HOR * GM.TILE_SIZE_UNITS),
                Random.Range(0, GM.N_TILES_VER * GM.TILE_SIZE_UNITS),
                decoSpiro.transform.position.z
            ),
            Quaternion.Euler(0.0f,0.0f, Random.Range(0.0f, 360.0f))
        );

        Invoke("SpawnSpiro", 1.0f / GM.fps * 55.0f);
    }
}
