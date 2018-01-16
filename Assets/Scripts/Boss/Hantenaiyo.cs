///////////////////////////////////////////////////////////////////////
//
//      Hantenaiyo.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Hantenaiyo : MonoBehaviour
{
    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0.0f;
    }
    
    void FixedUpdate()
    {
        if (gmc.ImageIndex == 0 && gameObject.layer != LayerMask.NameToLayer("Dangers"))
        {
            gameObject.layer = LayerMask.NameToLayer("Dangers");
        }
        else
        {
            if (gameObject.layer != LayerMask.NameToLayer("Default"))
            {
                gameObject.layer = LayerMask.NameToLayer("Default");
            }

            if (Mathf.Approximately(gmc.Speed, 0.0f))
            {
                gmc.ImageIndex = 4;
                gmc.ImageAlpha = 0.2f;
            }
            else if (Mathf.Approximately(gmc.Speed, 6))
            {
                gmc.ImageIndex = 0;
                gmc.ImageAlpha = 1;
            }
        }

        gmc.ImageAngle = gmc.Direction;
    }
}
