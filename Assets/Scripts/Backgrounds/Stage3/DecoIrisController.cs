///////////////////////////////////////////////////////////////////////
//
//      DecoIris.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Decorative object for stage 3 background
// Sets random velocity in the top-right direction and moves the object
public class DecoIris : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        velocity.x = Random.Range(1.2f, 10.0f);
        velocity.y = Random.Range(0.4f, 8.0f);
    }

    void FixedUpdate()
    {
        transform.position += velocity;
    }
}
