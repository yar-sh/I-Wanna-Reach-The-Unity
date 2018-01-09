///////////////////////////////////////////////////////////////////////
//
//      Stage4BGController.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Controls the background for stage 4
// Spawns decorative falling squares 
public class Stage4BGController : MonoBehaviour
{
    public GameObject square1;
    public GameObject square2;

    void Start()
    {
        InvokeRepeating("SpawnRandomSquare", 0.0f, 1.0f / GM.fps * 20.0f);
    }

    void SpawnRandomSquare()
    {
        GameObject sqr = Instantiate(
            (Random.Range(0, 2) == 1 ? square1 : square2), 
            new Vector3(
                Random.Range(-40.0f, GM.N_TILES_HOR * GM.TILE_SIZE_UNITS + 40.0f),
                GM.N_TILES_VER * GM.TILE_SIZE_UNITS + 40.0f,
                1.0f
            ),
            Quaternion.identity
        );

        sqr.transform.localScale *= Random.Range(1.0f, 1.75f);
        sqr.GetComponent<GMComponent>().Direction = 270.0f;
        sqr.GetComponent<GMComponent>().Speed = Random.Range(2.0f, 5.0f);
    }
}
