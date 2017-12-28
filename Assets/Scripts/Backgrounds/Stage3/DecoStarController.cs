///////////////////////////////////////////////////////////////////////
//
//      DecoStarController.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class DecoStarController : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    Vector3 rotVel = Vector3.zero;

    void Start()
    {
        velocity.x = Random.Range(1.2f, 8.0f);
        velocity.y = Random.Range(0.2f, 6.0f);
        rotVel.z = Random.Range(-5.0f, 5.0f);
    }

    void FixedUpdate()
    {
        transform.position += velocity;

        Quaternion rot = transform.rotation;
        rot.eulerAngles += rotVel;
        transform.rotation = rot;
    }
}
