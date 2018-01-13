///////////////////////////////////////////////////////////////////////
//
//      Kabe.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Kabe : MonoBehaviour
{
    public GameObject HuwaKabe;
    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0.0f;
        gmc.ImageScaleX = 1.4f;
        gmc.ImageScaleY = 1.4f;
        gmc.ImageAlpha = 0.0f;
    }

    public void Alarm0()
    {
        Instantiate(HuwaKabe, transform.position, Quaternion.identity);
        Invoke("Alarm0", 1.0f / GM.fps);
    }
    
    public void Alarm1()
    {
        gmc.ImageAlpha -= 0.01f;
        Invoke("Alarm1", 1.0f / GM.fps);
    }
}
