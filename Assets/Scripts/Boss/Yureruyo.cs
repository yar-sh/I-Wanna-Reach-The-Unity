///////////////////////////////////////////////////////////////////////
//
//      Yureruyo.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Yureruyo : MonoBehaviour
{
    new Camera camera;
    Player player;

    void Start()
    {
        camera = FindObjectOfType<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        Invoke("Alarm0", 1.0f / GM.fps);
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

        Vector3 pos = new Vector3(544 + Random.Range(-50.0f, 50.0f), 272 + Random.Range(-50.0f, 50.0f), camera.transform.position.z);

        camera.transform.position = pos;

        Invoke("Alarm0", 1.0f / GM.fps);
    }
}
