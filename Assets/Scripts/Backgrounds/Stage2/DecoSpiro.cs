///////////////////////////////////////////////////////////////////////
//
//      DecoSpiro.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Decorative object for stage 2 background
// Sets random rotation speed and increases and then decreases the spirograph's size
public class DecoSpiro : MonoBehaviour
{
    float alphaSpeed = 0.014f;
    float scaleSpeed = 0.016f;
    float rotationSpeed = 0.0f;
    bool fadeFlag = false;
    SpriteRenderer sr;

    void Start()
    {
        rotationSpeed = Random.Range(0.5f, 1.5f);
        rotationSpeed *= (Random.Range(0, 2) == 1 ? -1 : 1);

        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Color c = sr.color;

        if (c.a < 0.5f && !fadeFlag)
        {
            c.a += alphaSpeed;
            sr.color = c;
        }
        else if(c.a >=0.5f && !fadeFlag)
        {
            fadeFlag = true;
        }
        else if (c.a > 0.0f && fadeFlag)
        {
            c.a -= alphaSpeed;
            sr.color = c;
        }
        else if (c.a <= 0.0f && fadeFlag)
        {
            Destroy(gameObject);
            return;
        }

        transform.localScale += (Vector3)Vector2.one * scaleSpeed;

        Quaternion rot = transform.rotation;
        rot.eulerAngles += new Vector3(0, 0, rotationSpeed);
        transform.rotation = rot;
    }
}
