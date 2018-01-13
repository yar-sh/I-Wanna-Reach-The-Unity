///////////////////////////////////////////////////////////////////////
//
//      Huwa.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Huwa : MonoBehaviour
{
    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0.0f;
        gmc.ImageScaleX = 1.6f;
        gmc.ImageScaleY = 1.6f;
        gmc.ImageAlpha = 0.9f;

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    public void Alarm0()
    {
        gmc.ImageAlpha -= 0.1f;
        gmc.ImageScaleX += 0.1f;
        gmc.ImageScaleY += 0.1f;

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    void FixedUpdate()
    {
        if (Mathf.Approximately(gmc.ImageAlpha, 0.0f))
        {
            Destroy(gameObject);
        }
    }
}
