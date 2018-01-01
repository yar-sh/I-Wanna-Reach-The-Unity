///////////////////////////////////////////////////////////////////////
//
//      DecoFallingSquare.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class DecoFallingSquare : MonoBehaviour
{
    float rotationSpeed = 0.0f;

    void Start()
    {
        rotationSpeed = Random.Range(3.0f, 7.0f);
        rotationSpeed *= (Random.Range(0, 2) == 1 ? -1 : 1);
    }

    void FixedUpdate()
    {
        Quaternion rot = transform.rotation;
        rot.eulerAngles += new Vector3(0, 0, rotationSpeed);
        transform.rotation = rot;
    }
}
