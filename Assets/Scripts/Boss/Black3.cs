///////////////////////////////////////////////////////////////////////
//
//      Black3.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Black3 : MonoBehaviour
{
    GMComponent gmc;
    GameObject idx;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0.0f;
        gmc.ImageScaleX = 3.0f;
        gmc.ImageScaleY = 3.0f;

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    public void Alarm0()
    {

        gmc.ImageScaleX -= 0.2f;
        gmc.ImageScaleY -= 0.2f;
        Invoke("Alarm0", 1.0f / GM.fps);
    }
    
    public void Alarm1()
    {
        gmc.Speed = 3;
        //Invoke("Alarm1", 0.0f);
    }

    public void Alarm2()
    {
        gmc.ImageAlpha -= 0.05f;
        Invoke("Alarm2", 1.0f / GM.fps);
    }
    
    void FixedUpdate()
    {
        if (Mathf.Approximately(gmc.ImageScaleX, 1.2f))
        {
            Invoke("Alarm0", 0.0f);
        }
    }
}
