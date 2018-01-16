///////////////////////////////////////////////////////////////////////
//
//      Kurai.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Kurai : MonoBehaviour
{
    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();
        
        gmc.ImageAlpha = 0.5f;
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
        gmc.ImageAlpha += 0.05f;

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    void FixedUpdate()
    {
        if (gmc.ImageAlpha > 0.7f)
        {
            gmc.ImageAlpha = 0.4f;
        }
    }
}
