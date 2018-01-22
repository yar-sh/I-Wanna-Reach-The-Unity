///////////////////////////////////////////////////////////////////////
//
//      Hanabidasu.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Hanabidasu : MonoBehaviour
{
    public GameObject hanabi;

    public static float s = 8;
    public static float a = 0;

    uint t = 0;
    float p1 = 400;
    float p2 = 80;
    float pd = 0;
    float d = 0;

    Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        t = 1;
        pd = GMComponent.PointDistance(
            GM.offsetX + p1, GM.offsetY - p2,
            player.transform.position.x, player.transform.position.y);
        d = GMComponent.PointDirection(
            GM.offsetX + p1, GM.offsetY - p2,
            player.transform.position.x, player.transform.position.y);
    }

    public void Alarm2()
    {
        for (int i = 0; i < 3; i++)
        {
            GMComponent gmcObj =
                Instantiate(hanabi, transform.position, Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Speed = 11.5f + a;
            gmcObj.Direction = Random.Range(0.0f, 360.0f);
        }

        Invoke("Alarm2", 1.0f / GM.fps * 5);
    }

    public void Alarm3()
    {
        a += 0.018f;
        s += 0.02f;

        Invoke("Alarm3", 1.0f / GM.fps);
    }

    public void Alarm4()
    {
        GMComponent gmcObj =
            Instantiate(hanabi, new Vector2(
                GM.offsetX + 400, GM.offsetY - 10), Quaternion.identity)
            .GetComponent<GMComponent>();

        gmcObj.Speed = 11 + a;
        gmcObj.Direction = Random.Range(-180.0f, 0.0f);

        Invoke("Alarm4", 1.0f / GM.fps * 2);
    }

    void FixedUpdate()
    {
        if (t == 1)
        {
            Vector2 pos = new Vector2(
                GM.offsetX + p1 + pd * Mathf.Cos(d * Mathf.Deg2Rad),
                GM.offsetY - (p2 - pd * Mathf.Sin(d * Mathf.Deg2Rad))
                );
        }
    }
}
