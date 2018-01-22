///////////////////////////////////////////////////////////////////////
//
//      Gamenmawaru.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Gamenmawaru : MonoBehaviour
{
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
        if (player.isDead)
        {
            return;
        }

        camera.transform.Rotate(new Vector3(0, 0, 36));

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    public void Alarm1()
    {
        if (player.isDead)
        {
            return;
        }

        camera.transform.Rotate(new Vector3(0, 0, 72));

        Invoke("Alarm1", 1.0f / GM.fps);
    }
}
