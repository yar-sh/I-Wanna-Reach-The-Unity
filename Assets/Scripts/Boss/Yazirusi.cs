///////////////////////////////////////////////////////////////////////
//
//      Yazirusi.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Yazirusi : MonoBehaviour
{
    [HideInInspector]
    public bool preventAlarm0;

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
        if (preventAlarm0)
        {
            return;
        }

        gmc.ImageAlpha -= 0.1f;

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    void FixedUpdate()
    {
        if (Mathf.Approximately(gmc.ImageAlpha,0.0f))
        {
            Destroy(gameObject);
        }
    }
}
