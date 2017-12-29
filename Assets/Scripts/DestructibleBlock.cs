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
        ParticleSystem ps = GetComponentInChildren<ParticleSystem>();

        ps.transform.parent = null;
        ps.Play();

        GameManager.Instance.PlaySound("Destruct");

        Destroy(gameObject);
    }
}
