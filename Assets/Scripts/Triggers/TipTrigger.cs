///////////////////////////////////////////////////////////////////////
//
//      TipTrigger.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Displays a tip on the screen when triggered
public class TipTrigger : MonoBehaviour
{
    float fadeSpeed = 0.024f;
    bool doFading = false;
    SpriteRenderer sr;

    void Start()
    {
        sr = transform.parent.GetComponent<SpriteRenderer>();
        sr.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    public void Trigger()
    {
        transform.position += Vector3.down * 5000;
        doFading = true;
    }

    void FixedUpdate()
    {
        if (!doFading)
        {
            return;
        }

        Color c = sr.color;

        if (c.a <= 0.99f)
        {
            c = new Color(1.0f, 1.0f, 1.0f, c.a+fadeSpeed);
        }
        else if (c.a > 0.99f)
        {
            c = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            doFading = false;
        }

        sr.color = c;
    }
}
