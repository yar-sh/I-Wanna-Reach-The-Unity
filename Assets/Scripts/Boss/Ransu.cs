///////////////////////////////////////////////////////////////////////
//
//      Ransu.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Ransu : MonoBehaviour
{
    [HideInInspector]
    public uint nachi = 0;

    GMComponent gmc;
    
    void Start()
    {
        gmc = GetComponent<GMComponent>();
        
        gmc.ImageSpeed = 0.0f;
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
        gmc.ImageAlpha -= 0.05f;

        Invoke("Alarm0", 1.0f / GM.fps);
    }
    
    void FixedUpdate()
    {
        if (nachi == 1)
        {
            gmc.Direction += 3;
        }

        if (nachi == 2)
        {
            gmc.Direction -= 3;
        }
    }
}
