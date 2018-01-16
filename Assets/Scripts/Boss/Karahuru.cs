///////////////////////////////////////////////////////////////////////
//
//      Karahuru.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Karahuru : MonoBehaviour
{
    public GameObject murasaki;
    public GameObject mizu;
    public GameObject kiro;
    public GameObject midori;

    void Start()
    {
        Invoke("Alarm0", 1.0f / GM.fps);
    }

    public void Alarm0()
    {
        GMComponent gmcObj =
            Instantiate(murasaki, new Vector2(GM.offsetX, GM.offsetY - Random.Range(30.0f,160.0f)), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 36;
        gmcObj.Direction = 0.0f;


        gmcObj =
            Instantiate(mizu, new Vector2(GM.offsetX, GM.offsetY - Random.Range(30.0f, 160.0f)), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 36;
        gmcObj.Direction = 0.0f;


        gmcObj =
            Instantiate(kiro, new Vector2(GM.offsetX + 800.0f, GM.offsetY - Random.Range(30.0f, 160.0f)), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 36;
        gmcObj.Direction = 180.0f;


        gmcObj =
            Instantiate(midori, new Vector2(GM.offsetX + 800.0f, GM.offsetY - Random.Range(30.0f, 160.0f)), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 36;
        gmcObj.Direction = 180.0f;


        Invoke("Alarm0", 1.0f / GM.fps * 8.0f);
    }
}
