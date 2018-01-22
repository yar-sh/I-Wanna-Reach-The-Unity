///////////////////////////////////////////////////////////////////////
//
//      Object832.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Object832 : MonoBehaviour
{
    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0.0f;
        gmc.ImageAngle = gmc.Direction;
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
            else if (transform.position.x < GM.offsetX)
            {
                Destroy(gameObject);
                return;
            }
            else if (transform.position.y < 0)
            {
                Destroy(gameObject);
                return;
            }
        }

        gmc.ImageAngle = gmc.Direction;
    }

}
