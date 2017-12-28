///////////////////////////////////////////////////////////////////////
//
//      BloodEmitter.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class BloodEmitter : MonoBehaviour
{
    public GameObject bloodParticle;
    public uint maxFrames = 13;
    public uint maxParticlesPerFrame = 20;
    uint frameCounter = 0;
    
    void FixedUpdate()
    {
        if (frameCounter > maxFrames)
        {
            return;
        }

        for (uint i =0; i < maxParticlesPerFrame; i++)
        {
            Vector3 pos = transform.position;
            pos.z = -3;

            Instantiate(bloodParticle, pos, Quaternion.identity);
        }

        frameCounter++;
    }
}
