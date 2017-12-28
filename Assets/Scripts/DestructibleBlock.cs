///////////////////////////////////////////////////////////////////////
//
//      DestructibleBlock.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class DestructibleBlock : MonoBehaviour
{
    public void Destruct()
    {
        // TODO: sounds
        ParticleSystem ps = GetComponentInChildren<ParticleSystem>();

        ps.transform.parent = null;
        ps.Play();

        Destroy(gameObject);
    }
}
