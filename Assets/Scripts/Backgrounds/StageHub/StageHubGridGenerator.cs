///////////////////////////////////////////////////////////////////////
//
//      StageHubGridGenerator.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Generates a fancy grid in a stage hub room
public class StageHubGridGenerator : MonoBehaviour
{
    int length = 20;
    public GameObject decoGrid;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int i = 0; i < length; i++)
        {
            Instantiate(decoGrid, new Vector3(transform.position.x + 64 * i, transform.position.y, 150), Quaternion.identity);
        }

        Invoke("GenerateGrid", 1.0f/GM.fps * 64.0f);
    }
}
