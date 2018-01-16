///////////////////////////////////////////////////////////////////////
//
//      Kaiten.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Kaiten : MonoBehaviour
{
    public GameObject gurugurusuru;

    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

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
        float b = 36;
        float asd = 0.0f;

        for (int i =0; i < 10; i++)
        {
            GMComponent gmcObj =
                Instantiate(gurugurusuru,
                new Vector2(transform.position.x, transform.position.y),
                Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Direction = b + asd;
            gmcObj.gravity = -0.25f;
            gmcObj.Speed = 18;

            asd += 36;
        }

        Invoke("Alarm0", 1.0f / GM.fps * 5);
    }
    
    public void Alarm1()
    {
        float a = 18;
        float asd = 0.0f;

        for (int i = 0; i < 20; i++)
        {
            GMComponent gmcObj =
                Instantiate(gurugurusuru,
                new Vector2(transform.position.x, transform.position.y),
                Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Direction = a + asd;
            gmcObj.acceleration = -0.3f;
            gmcObj.Speed = 14;

            asd += 360.0f / 20.0f;
        }

        Invoke("Alarm1", 1.0f / GM.fps * 4);
    }
}
