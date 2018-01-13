///////////////////////////////////////////////////////////////////////
//
//      KaraHurudan.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class KaraHurudan : MonoBehaviour
{
    GMComponent gmc;

    void Start()
    {
        gmc = GetComponent<GMComponent>();

        gmc.ImageSpeed = 0.0f;
        gmc.ImageIndex = (uint)Random.Range(0, 7 + 1);
    }
}
