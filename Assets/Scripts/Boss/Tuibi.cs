///////////////////////////////////////////////////////////////////////
//
//      Tuibi.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Tuibi : MonoBehaviour
{
    public GameObject object724;

    GMComponent gmc;
    Player player;

    void Start()
    {
        gmc = GetComponent<GMComponent>();
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
        gmc.MoveTowardsPoint(player.transform.position.x, player.transform.position.y, 4);
        
        GMComponent gmcObj = Instantiate(object724, transform.position, Quaternion.identity).GetComponent<GMComponent>();

        gmcObj.Speed = Random.Range(10.0f,14.0f);
        gmcObj.Direction = Random.Range(0.0f, 360.0f);

        Invoke("Alarm0", 1.0f / GM.fps);
    }
}
