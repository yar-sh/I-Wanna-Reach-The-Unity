///////////////////////////////////////////////////////////////////////
//
//      Ransuyou.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Ransuyou : MonoBehaviour
{
    public GameObject object724;
    public GameObject ransu;
    public GameObject hanteinai;
    public GameObject hanteinaiyo;
    public GameObject hanabi;

    [HideInInspector]
    public bool cancelAlarm0 = false;
    float b = 180.0f;

    void Start()
    {
        Invoke("Alarm0", 1.0f / GM.fps);
    }

    public void StartAlarm(string alarmName, float frames)
    {
        Invoke(alarmName, 1.0f / GM.fps * frames);
    }

    public void StopAlarm(string alarmName)
    {
        CancelInvoke(alarmName);
    }

    public void Alarm0()
    {
        if (cancelAlarm0)
        {
            return;
        }

        GMComponent gmcObj =
            Instantiate(object724, new Vector2(GM.offsetX + Random.Range(0.0f, 800.0f), GM.offsetY - 0.0f), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = Random.Range(10.0f, 14.0f);
        gmcObj.Direction = Random.Range(260.0f, 280.0f);

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    public void Alarm1()
    {
        b += 2.0f;

        GMComponent gmcObj =
            Instantiate(ransu, new Vector2(GM.offsetX + 800.0f, GM.offsetY - Random.Range(0.0f,608.0f)), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = Random.Range(10.0f, 12.0f);
        gmcObj.Direction = b;


        gmcObj =
            Instantiate(ransu, new Vector2(GM.offsetX + Random.Range(0.0f, 800.0f), GM.offsetY - 0.0f), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = Random.Range(10.0f, 12.0f);
        gmcObj.Direction = b;


        gmcObj =
            Instantiate(ransu, new Vector2(GM.offsetX, GM.offsetY - Random.Range(0.0f, 608.0f)), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = Random.Range(10.0f, 12.0f);
        gmcObj.Direction = b;


        Invoke("Alarm1", 1.0f / GM.fps * 2.5f);
    }

    public void Alarm2()
    {
        GMComponent gmcObj =
            Instantiate(object724, new Vector2(GM.offsetX + Random.Range(0.0f, 800.0f), GM.offsetY - 0.0f), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = Random.Range(8.0f, 10.0f);
        gmcObj.Direction = 270.0f;

        Invoke("Alarm2", 1.0f / GM.fps);
    }

    public void Alarm4()
    {
        GMComponent gmcObj =
            Instantiate(hanteinai, new Vector2(GM.offsetX + Random.Range(0.0f, 800.0f), GM.offsetY - 0.0f), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 16.5f;
        gmcObj.Direction = 270.0f;

        Invoke("Alarm4", 1.0f / GM.fps);
    }

    public void Alarm5()
    {
        GMComponent gmcObj =
            Instantiate(hanteinaiyo, new Vector2(GM.offsetX, GM.offsetY - 0.0f), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 14.5f;
        gmcObj.Direction = Random.Range(270.0f,325.0f);


        gmcObj =
            Instantiate(hanteinaiyo, new Vector2(GM.offsetX + 800.0f, GM.offsetY - 0.0f), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 14.5f;
        gmcObj.Direction = Random.Range(215.0f, 270.0f);

        Invoke("Alarm5", 1.0f / GM.fps);
    }

    public void Alarm6()
    {
        GMComponent gmcObj =
            Instantiate(hanteinaiyo, new Vector2(GM.offsetX, GM.offsetY - 608.0f), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 4;
        gmcObj.Direction = Random.Range(0.0f, 35.0f);


        gmcObj =
            Instantiate(hanteinaiyo, new Vector2(GM.offsetX + 800.0f, GM.offsetY - 608.0f), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 4;
        gmcObj.Direction = Random.Range(145.0f, 180.0f);


        gmcObj =
            Instantiate(hanteinaiyo, new Vector2(GM.offsetX, GM.offsetY), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 8.5f;
        gmcObj.Direction = Random.Range(270.0f, 315.0f);


        gmcObj =
            Instantiate(hanteinaiyo, new Vector2(GM.offsetX + 800.0f, GM.offsetY), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 8.5f;
        gmcObj.Direction = Random.Range(225.0f, 270.0f);

        Invoke("Alarm6", 1.0f / GM.fps * 5.0f);
    }

    public void Alarm7()
    {
        GMComponent gmcObj =
            Instantiate(hanteinai, new Vector2(GM.offsetX + Random.Range(0.0f, 800.0f), GM.offsetY), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 6;
        gmcObj.Direction = 270.0f;


        Invoke("Alarm7", 1.0f / GM.fps);
    }

    public void Alarm8()
    {
        GMComponent gmcObj =
            Instantiate(object724, new Vector2(GM.offsetX + 800.0f, GM.offsetY - Random.Range(20.0f,300.0f)), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 28;
        gmcObj.Direction = 180.0f;


        gmcObj =
            Instantiate(object724, new Vector2(GM.offsetX , GM.offsetY - Random.Range(20.0f, 300.0f)), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 28;
        gmcObj.Direction = 0.0f;

        Invoke("Alarm8", 1.0f / GM.fps * Random.Range(1,3));
    }

    public void Alarm9()
    {
        GMComponent gmcObj =
            Instantiate(hanabi, new Vector2(GM.offsetX, GM.offsetY - 304), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 28;
        gmcObj.Direction = Random.Range(-30.0f,30.0f);


        gmcObj =
            Instantiate(hanabi, new Vector2(GM.offsetX, GM.offsetY - 304), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 26;
        gmcObj.Direction = Random.Range(-35.0f, 35.0f);

        Invoke("Alarm9", 1.0f / GM.fps);
    }

    public void Alarm10()
    {
        GMComponent gmcObj =
            Instantiate(hanteinai, new Vector2(GM.offsetX + Random.Range(0.0f, 800.0f), GM.offsetY - 0.0f), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 16.5f;
        gmcObj.Direction = 270.0f;

        Invoke("Alarm10", 1.0f / GM.fps * 2.0f);
    }
}
