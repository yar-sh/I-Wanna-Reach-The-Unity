///////////////////////////////////////////////////////////////////////
//
//      Yokoyure.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Yokoyure : MonoBehaviour
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

        Vector3 pos = new Vector3(544 + Random.Range(-10.0f, 10.0f), 272, camera.transform.position.z);

        camera.transform.position = pos;
    }
}
