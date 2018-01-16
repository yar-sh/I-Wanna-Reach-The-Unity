///////////////////////////////////////////////////////////////////////
//
//      Meiten.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Meiten : MonoBehaviour
{
    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageAlpha = 0.9f;

        Invoke("Alarm0", 1.0f / GM.fps);
    }

    public void Alarm0()
    {
        gmc.ImageAlpha -= 0.1f;
        Invoke("Alarm0", 1.0f / GM.fps * 2.0f);
    }

    void FixedUpdate()
    {
        if (Mathf.Approximately(gmc.ImageAlpha, 0.0f))
        {
            Destroy(gameObject);
        }
    }
}
