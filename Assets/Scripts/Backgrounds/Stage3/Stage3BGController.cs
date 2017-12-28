///////////////////////////////////////////////////////////////////////
//
//      Stage3BGController.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Stage3BGController : MonoBehaviour
{
    public GameObject decoStar;
    public GameObject decoIris;
    public GameObject backgroundObject;

    float rotationSpeedBG = 1.0f;
    GameObject BG;

    void Start()
    {
        Invoke("GeneralDecoStarSpawn", Random.Range(0.0f, 1.0f / GM.fps * 5));
        Invoke("GeneralDecoStarSpawn", Random.Range(1.0f / GM.fps * 5, 1.0f / GM.fps * 5 * 2));
        Invoke("GeneralDecoIrisSpawn", 1.0f / GM.fps * 10);
        BG = Instantiate(backgroundObject);
    }

    void Update()
    {
        Quaternion rot = BG.transform.rotation;
        rot.eulerAngles += new Vector3(0, 0, rotationSpeedBG * Time.deltaTime);
        BG.transform.rotation = rot;
    }

    void GeneralDecoStarSpawn()
    {
        int n = Random.Range(0, 100);

        Vector3 pos = transform.position;

        if (n > 70)
        {
            pos.x -= 16;
            pos.y -= 16;

            GameObject star = Instantiate(decoStar, pos, Quaternion.identity);
            star.transform.localScale = new Vector3(0.125f, 0.125f, 1.0f);
        }
        else if (n > 20)
        {
            pos.x -= 32;
            pos.y -= 32;

            GameObject star = Instantiate(decoStar, pos, Quaternion.identity);
            star.transform.localScale = new Vector3(0.25f, 0.25f, 1.0f);
        }
        else if (n > 8)
        {
            pos.x -= 64;
            pos.y -= 64;

            GameObject star = Instantiate(decoStar, pos, Quaternion.identity);
            star.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        }
        else if (n > 2)
        {
            pos.x -= 96;
            pos.y -= 96;

            GameObject star = Instantiate(decoStar, pos, Quaternion.identity);
            star.transform.localScale = new Vector3(0.75f, 0.75f, 1.0f);
        }
        else
        {
            pos.x -= 128;
            pos.y -= 128;
            GameObject star = Instantiate(decoStar, pos, Quaternion.identity);
            star.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        Invoke("GeneralDecoStarSpawn", Random.Range(1.0f / GM.fps * 10, 1.0f / GM.fps * 25));
    }
    
    void GeneralDecoIrisSpawn()
    {
        Vector3 pos = transform.position;
        pos.x -= 32;
        pos.y -= 32;

        GameObject iris = Instantiate(decoIris, pos, Quaternion.identity);
        Invoke("GeneralDecoIrisSpawn", Random.Range(1.0f / GM.fps * 10, 1.0f / GM.fps * 20));
    }
}
