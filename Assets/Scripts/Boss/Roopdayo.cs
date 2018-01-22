///////////////////////////////////////////////////////////////////////
//
//      Roopdayo.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Roopdayo : MonoBehaviour
{
    public GameObject hanabi;

    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();
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
        GMComponent gmcObj =
            Instantiate(hanabi, transform.position, Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = Random.Range(8.0f,12.0f);
        gmcObj.Direction = Random.Range(0.0f, 360.0f);

        Invoke("Alarm1", 1.0f / GM.fps);
    }
}
