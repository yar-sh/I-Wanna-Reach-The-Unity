///////////////////////////////////////////////////////////////////////
//
//      Kabeda.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Kabeda : MonoBehaviour
{
    public GameObject kabedayou;

    void Start()
    {
        Invoke("Alarm0", 1.0f / GM.fps);
    }

    public void StopAlarm(string alarmName)
    {
        CancelInvoke(alarmName);
    }

    public void Alarm0()
    {
        Instantiate(kabedayou, transform.position, Quaternion.identity);

        Invoke("Alarm0", 1.0f / GM.fps);
    }
}
