///////////////////////////////////////////////////////////////////////
//
//      Hantenai.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Hantenai : MonoBehaviour
{
    [HideInInspector]
    public int nachi = 0;

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
        gmc.ImageAlpha -= 0.1f;

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    public void Alarm1()
    {
        gmc.MoveTowardsPoint(GM.offsetX + 400, GM.offsetY - 100, 17.0f);

        Invoke("Alarm1", 1.0f / GM.fps);
    }

    void FixedUpdate()
    {
        if (gmc.ImageIndex == 0 && gameObject.layer != LayerMask.NameToLayer("Dangers"))
        {
            gameObject.layer = LayerMask.NameToLayer("Dangers");
        }
        else
        {
            if (gameObject.layer != LayerMask.NameToLayer("Default"))
            {
                gameObject.layer = LayerMask.NameToLayer("Default");
            }

            if (Mathf.Approximately(gmc.Speed, 0.0f))
            {
                gmc.ImageIndex = 6;
                gmc.ImageAlpha = 0.2f;
            }
            else if (Mathf.Approximately(gmc.Speed, 16.5f))
            {
                gmc.ImageIndex = 0;
                gmc.ImageAlpha = 1;
            }
            else if (Mathf.Approximately(gmc.Speed, 6))
            {
                gmc.ImageIndex = 0;
                gmc.ImageAlpha = 1;
            }
            else if (nachi == 1)
            {
                gmc.Direction -= 1;
            }
        }

        gmc.ImageAngle = gmc.Direction;
    }
}
