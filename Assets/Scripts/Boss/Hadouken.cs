///////////////////////////////////////////////////////////////////////
//
//      Hadouken.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Hadouken : MonoBehaviour
{
    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0.0f;
        gmc.ImageAlpha = 0.7f;

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
        gmc.ImageAlpha -= 0.1f;

        Invoke("Alarm1", 1.0f / GM.fps);
    }
}
