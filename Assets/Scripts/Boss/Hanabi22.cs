///////////////////////////////////////////////////////////////////////
//
//      Hanabi22.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Hanabi22 : MonoBehaviour
{
    public GameObject hanabi33;

    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0.0f;
        gmc.ImageScaleX = 1.2f;
        gmc.ImageScaleY = 1.2f;

        Invoke("Alarm0", 1.0f / GM.fps * 2.5f);
    }

    public void Alarm0()
    {
        Instantiate(hanabi33, transform.position, Quaternion.identity);
        Invoke("Alarm0", 1.0f / GM.fps * 1.5f);
    }
}
