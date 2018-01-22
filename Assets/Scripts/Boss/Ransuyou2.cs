///////////////////////////////////////////////////////////////////////
//
//      Ransuyou2.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Ransuyou2 : MonoBehaviour
{
    public GameObject object832;
    public GameObject object833;

    [HideInInspector]
    public bool cancelAlarm0 = false;
    float a = 0.0f;

    void Start()
    {
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
        if (cancelAlarm0)
        {
            return;
        }
        
        GMComponent gmcObj =
            Instantiate(object832, new Vector2(GM.offsetX +1100, GM.offsetY - Random.Range(30.0f,600.0f)), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = Random.Range(12.0f, 14.0f);
        gmcObj.Direction = Random.Range(170.0f, 190.0f);

        Invoke("Alarm0", 1.0f / GM.fps * Random.Range(1, 3));
    }

    public void Alarm1()
    {
        GMComponent gmcObj =
            Instantiate(object833, new Vector2(GM.offsetX -300, GM.offsetY - Random.Range(50.0f, 600.0f)), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = Random.Range(12.0f, 14.0f);
        gmcObj.Direction = Random.Range(-10.0f, 10.0f);

        Invoke("Alarm1", 1.0f / GM.fps * Random.Range(1, 3));
    }
}
