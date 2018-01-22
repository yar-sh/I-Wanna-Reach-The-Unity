///////////////////////////////////////////////////////////////////////
//
//      Tateyure.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Tateyure : MonoBehaviour
{
    new Camera camera;
    Player player;

    void Start()
    {
        camera = FindObjectOfType<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        Invoke("Alarm1", 1.0f / GM.fps);
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
        if (player.isDead)
        {
            return;
        }

        Vector3 pos = new Vector3(544, 272 + Random.Range(-100.0f, 100.0f), camera.transform.position.z);

        camera.transform.position = pos;

        Invoke("Alarm1", 1.0f / GM.fps);
    }
}
