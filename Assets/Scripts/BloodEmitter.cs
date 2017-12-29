///////////////////////////////////////////////////////////////////////
//
//      BloodEmitter.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Spawns when player dies. Produces a lot of blood particles
public class BloodEmitter : MonoBehaviour
{
    public GameObject bloodParticle;

    uint maxFixedFrames = 13;
    uint maxParticlesPerFixedFrame = 20;
    uint fixedFrameCount = 0;
    
    void FixedUpdate()
    {
        // Spawn particles for a limited amount of fixed frames
        if (fixedFrameCount > maxFixedFrames)
        {
            return;
        }

        // Each fixed frame spawn 'maxParticlesPerFrame' particles
        for (uint i = 0; i < maxParticlesPerFixedFrame; i++)
        {
            Vector3 pos = transform.position;
            pos.z = -3;

            Instantiate(bloodParticle, pos, Quaternion.identity);
        }

        fixedFrameCount++;
    }
}
