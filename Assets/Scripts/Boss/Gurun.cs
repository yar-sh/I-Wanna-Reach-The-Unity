///////////////////////////////////////////////////////////////////////
//
//      Gurun.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Gurun : MonoBehaviour
{
    public GameObject hanabi;
    public GameObject object871;
    public GameObject object915;

    float a = 180;
    float b = 0;
    float s = 10;

    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();
        Invoke("Alarm1", 1.0f / GM.fps);
    }

    public void StartAlarm(string alarmName, float frames)
    {
        Invoke(alarmName, 1.0f / GM.fps * frames);
    }

    public void StopAlarm(string alarmName)
    {
        CancelInvoke(alarmName);
    }

    public void Alarm1()
    {
        a += s;
        b += s;
        
        GMComponent gmcObj =
            Instantiate(hanabi, transform.position, Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 8;
        gmcObj.Direction = a;


        gmcObj =
            Instantiate(hanabi, transform.position, Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 8;
        gmcObj.Direction = b;

        Invoke("Alarm1", 1.0f / GM.fps);
    }

    public void Alarm2()
    {
        float t = Random.Range(0.5f, 0.9f);

        GMComponent gmcObj =
            Instantiate(object871, new Vector2(GM.offsetX + 400, GM.offsetY - 10), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = Random.Range(4.0f,8.0f);
        gmcObj.Direction = Random.Range(224.0f, 316.0f);
        gmcObj.ImageScaleX = t;
        gmcObj.ImageScaleY = t;

        Invoke("Alarm2", 1.0f / GM.fps);
    }

    public void Alarm3()
    {
        float a = Random.Range(0.0f, 6.0f);
        float asd = 0;

        for (int i = 0; i<50;i++)
        {
            GMComponent gmcObj =
                Instantiate(object915, new Vector2(GM.offsetX + 400, GM.offsetY - 80), Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Speed = 4;
            gmcObj.Direction = a + asd;
            asd += 360.0f / 50.0f;
        }

        Invoke("Alarm3", 1.0f / GM.fps * 15);
    }
}
