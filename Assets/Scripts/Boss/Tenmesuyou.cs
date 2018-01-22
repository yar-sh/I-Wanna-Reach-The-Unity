///////////////////////////////////////////////////////////////////////
//
//      Tenmesuyou.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Tenmesuyou : MonoBehaviour
{
    public GameObject tenmetsuda;

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
        Instantiate(tenmetsuda);

        Invoke("Alarm1", 1.0f / GM.fps * 5);
    }
}
