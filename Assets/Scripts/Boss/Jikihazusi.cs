///////////////////////////////////////////////////////////////////////
//
//      Jikihazusi.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Jikihazusi : MonoBehaviour
{
    public GameObject object724;

    [HideInInspector]
    public bool preventAlarm0 = false;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

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

        float a = GMComponent.PointDirection(GM.offsetX + 800, GM.offsetY - 0, player.transform.position.x, player.transform.position.y);
        GMComponent gmcObj = 
            Instantiate(object724, new Vector2(GM.offsetX + 800, GM.offsetY - 0), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 30;
        gmcObj.Direction = a;


        a = GMComponent.PointDirection(GM.offsetX + 0, GM.offsetY - 0, player.transform.position.x, player.transform.position.y);
        gmcObj =
            Instantiate(object724, new Vector2(GM.offsetX + 0, GM.offsetY - 0), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 30;
        gmcObj.Direction = a;

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    public void Alarm2()
    {
        float a = GMComponent.PointDirection(GM.offsetX + 800, GM.offsetY - 0, player.transform.position.x, player.transform.position.y);
        GMComponent gmcObj =
            Instantiate(object724, new Vector2(GM.offsetX + 800, GM.offsetY - 0), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 20;
        gmcObj.Direction = a;


        a = GMComponent.PointDirection(GM.offsetX + 0, GM.offsetY - 0, player.transform.position.x, player.transform.position.y);
        gmcObj =
            Instantiate(object724, new Vector2(GM.offsetX + 0, GM.offsetY - 0), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 20;
        gmcObj.Direction = a;

        Invoke("Alarm2", 1.0f / GM.fps);
    }
}