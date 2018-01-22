///////////////////////////////////////////////////////////////////////
//
//      Hadouyou.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Hadouyou : MonoBehaviour
{
    public GameObject hadouken;

    void Start()
    {
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
        float a = 6;
        float asd = 0;

        for (int i = 0; i < 60; i++)
        {
            GMComponent gmcObj = Instantiate(hadouken, transform.position, Quaternion.identity).GetComponent<GMComponent>();

            gmcObj.Speed = 40;
            gmcObj.Direction = a + asd;

            asd += 360 / 60;
        }

        Invoke("Alarm1", 1.0f / GM.fps * 5);
    }
}
