///////////////////////////////////////////////////////////////////////
//
//      KaitenDekai.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class KaitenDekai : MonoBehaviour
{
    public GameObject karaHurudan;
    public GameObject object724;

    GMComponent gmc;
    GameObject player;

    [HideInInspector]
    public int t = 0;
    float p1 = GM.offsetX + 400;
    float p2 = GM.offsetY - 304;
    float spd = -10;
    float pd = 0.0f;
    float d = 0.0f;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0;
        gmc.ImageScaleX = 2.0f;
        gmc.ImageScaleY = 2.0f;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StartAlarm(string alarmName, float frames)
    {
        Invoke(alarmName, 1.0f / GM.fps * frames);
    }

    public void StopAlarm(string alarmName)
    {
        CancelInvoke(alarmName);
    }

    void Alarm0()
    {
        t = 1;
        pd = GMComponent.PointDistance(p1, p2, transform.position.x, transform.position.y);
        d = GMComponent.PointDirection(p1, p2, transform.position.x, transform.position.y);
    }
    
    void Alarm2()
    {
        if (player != null)
        {
            float a = GMComponent.PointDirection(
                transform.position.x,
                transform.position.y,
                player.transform.position.x + 20,
                player.transform.position.y - 20
                );

            float asd = 0.0f;

            for (int i =0; i < 8; i++)
            {
                GMComponent gmcObj =
                    Instantiate(karaHurudan, transform.position, Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 25;
                gmcObj.Direction = a + asd;

                asd += 360 / 8;
            }

            Invoke("Alarm2", 1.0f / GM.fps * 1.75f);
        }
    }

    void Alarm3()
    {
        for (int i = 0; i < 10; i++)
        {

            GMComponent gmcObj =
                Instantiate(object724, transform.position, Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Speed = Random.Range(11.0f,13.0f);
            gmcObj.Direction = Random.Range(60.0f, 100.0f);
            gmcObj.gravity = -0.3f;
        }

        Invoke("Alarm3", 1.0f / GM.fps);
    }

    void FixedUpdate()
    {
        if (t == 1)
        {
            Vector2 pos = transform.position;
            pos.x = p1 + pd * Mathf.Cos(d * Mathf.Deg2Rad);
            pos.y = p2 - pd * Mathf.Sin(d * Mathf.Deg2Rad);

            transform.position = pos;

            d += spd;
        }
    }
}
