///////////////////////////////////////////////////////////////////////
//
//      Shower.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Shower : MonoBehaviour
{
    public GameObject ransu;
    public GameObject object724;

    void Start()
    {
        Invoke("Alarm0", 1.0f / GM.fps);
        Invoke("Alarm1", 1.0f / GM.fps);
    }

    public void StopAlarm(string alarmName)
    {
        CancelInvoke(alarmName);
    }

    public void Alarm0()
    {
        GMComponent gmcObj =
            Instantiate(ransu, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 608), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 30;
        gmcObj.Direction = Random.Range(50.0f, 130.0f);

        
        gmcObj =
            Instantiate(ransu, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 608), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 28;
        gmcObj.Direction = Random.Range(50.0f, 130.0f);

        Invoke("Alarm0", 1.0f / GM.fps);
    }
    
    public void Alarm1()
    {
        GMComponent gmcObj =
            Instantiate(object724, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 608), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = Random.Range(12.0f,14.0f);
        gmcObj.Direction = Random.Range(70.0f, 110.0f);
        gmcObj.gravity = -0.2f;

        Invoke("Alarm1", 1.0f / GM.fps * 2.0f);
    }
}
