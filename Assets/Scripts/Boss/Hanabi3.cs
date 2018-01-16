///////////////////////////////////////////////////////////////////////
//
//      Hanabi3.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Hanabi3 : MonoBehaviour
{
    GMComponent gmc;

    [HideInInspector]
    public int t = 0;
    float p1 = GM.offsetX + 400;
    float p2 = GM.offsetY - 304;
    float spd = 20;
    float pd = 0.0f;
    float d = 0.0f;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0.0f;
        gmc.ImageScaleX = 1.2f;
        gmc.ImageScaleY = 1.2f;
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
        t = 1;
        pd = GMComponent.PointDistance(p1, p2, transform.position.x, transform.position.y);
        d = GMComponent.PointDirection(p1, p2, transform.position.x, transform.position.y);
    }
    
    void FixedUpdate()
    {
        if (t == 1)
        {
            Vector2 pos = transform.position;
            pos.x = p1 + pd * Mathf.Cos(d * Mathf.Deg2Rad);
            pos.y = p2 - pd * Mathf.Sin(d * Mathf.Deg2Rad);

            transform.position = pos;

            d += spd;
        }
    }
}
