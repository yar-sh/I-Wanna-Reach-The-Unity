///////////////////////////////////////////////////////////////////////
//
//      Kabetukuru.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Kabetukuru : MonoBehaviour
{
    public GameObject kabeninaru;

    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0.0f;

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
        Instantiate(kabeninaru, transform.position, Quaternion.identity);

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    void FixedUpdate()
    {
        if (transform.position.y <= GM.offsetY - 608)
        {
            Destroy(gameObject);
            return;
        }


        if (transform.position.x >= GM.offsetX + 800)
        {
            Destroy(gameObject);
            return;
        }
    }
}
