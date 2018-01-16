///////////////////////////////////////////////////////////////////////
//
//      Object724.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Object724 : MonoBehaviour
{
    [HideInInspector]
    public bool nachi = false;

    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0;
        gmc.ImageAngle = gmc.Direction;
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
        gmc.ImageAlpha -= 0.08f;

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    public void Alarm1()
    {
        gmc.MoveTowardsPoint(GM.offsetX + 400, GM.offsetY - 100, 17.0f);
        Invoke("Alarm1", 1.0f / GM.fps);
    }

    void FixedUpdate()
    {
        if (gmc.ImageAlpha <= 0)
        {
            Destroy(gameObject);
        }
        else if (nachi)
        {
            gmc.Direction -= 0.7f;
        }

        gmc.ImageAngle = gmc.Direction;
    }
}
