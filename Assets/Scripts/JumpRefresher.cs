///////////////////////////////////////////////////////////////////////
//
//      JumpRefresher.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Jump refresher gimmick
// Gives player the second jump back if it was used
public class JumpRefresher : MonoBehaviour
{
    public bool oneTimeUse = false;

    GameObject childParticleSystem;
    Vector3 defaultPos = Vector3.zero;

    void Start()
    {
        defaultPos = transform.position;
        childParticleSystem = transform.GetChild(0).gameObject;
    }

    // Player picked up the jump refresher - reset it
    public void ResetRefresher()
    {
        ParticleSystem ps = childParticleSystem.GetComponent<ParticleSystem>();
        ps.transform.parent = null;
        ps.Play();

        GameManager.Instance.PlaySound("JumpRefresher");

        if (!oneTimeUse)
        {
            // Hide the jump refresher on cooldown
            transform.position = defaultPos + new Vector3(-1, -1) * 1000;
            Invoke("BringRefresherBack", 2.0f);
        }
        else
        {
            // Destroy it completely
            Destroy(gameObject);
        }
    }

    // Brings jump refresher back to its original coords when cooldown ended
    void BringRefresherBack()
    {
        transform.position = defaultPos;
        childParticleSystem.transform.parent = transform;
    }
}
