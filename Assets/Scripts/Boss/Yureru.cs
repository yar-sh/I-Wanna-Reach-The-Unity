///////////////////////////////////////////////////////////////////////
//
//      Yureru.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Yureru : MonoBehaviour
{
    [HideInInspector]
    public bool preventAlarm0 = false;

    new Camera camera;
    Player player;

    void Start()
    {
        camera = FindObjectOfType<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

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
        if (preventAlarm0 || player.isDead)
        {
            return;
        }

        Vector3 pos = new Vector3(544 + Random.Range(-10.0f, 10.0f), 272 + Random.Range(-10.0f, 10.0f), camera.transform.position.z);

        camera.transform.position = pos;

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    public void Alarm1()
    {
        if (player.isDead)
        {
            return;
        }

        Vector3 pos = camera.transform.position;
        pos.x += 3;

        camera.transform.position = pos;

        Invoke("Alarm1", 1.0f / GM.fps);
    }

    public void Alarm2()
    {
        if (player.isDead)
        {
            return;
        }

        Vector3 pos = camera.transform.position;
        pos.x -= 3;

        camera.transform.position = pos;

        Invoke("Alarm2", 1.0f / GM.fps);
    }
}
