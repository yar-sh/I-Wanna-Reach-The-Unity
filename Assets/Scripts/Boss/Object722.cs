///////////////////////////////////////////////////////////////////////
//
//      Object722.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Object722 : MonoBehaviour
{
    [HideInInspector]
    public int nachi = 0;

    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0.0f;
    }

    void FixedUpdate()
    {
        if (nachi == 1)
        {
            gmc.Direction += 1.3f;
        }
        else if (nachi == 2)
        {
            gmc.Direction -= 1.3f;
        }
    }
}
