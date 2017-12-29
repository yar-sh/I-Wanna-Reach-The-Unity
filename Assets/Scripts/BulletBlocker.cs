///////////////////////////////////////////////////////////////////////
//
//      BulletBlocker.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Blocks bullets from travelling. Prevents saving from unwanted locations
public class BulletBlocker : MonoBehaviour
{
    float transitionSpeed = 0.05f;
    bool isHidden = true;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // Not visible at the start
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    // Shows the bullet blocker (when bullet collides with it)
    public void Show()
    {
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        isHidden = false;
        
        GameManager.Instance.PlaySound("BulletBlocker");
    }

    void FixedUpdate()
    {
        // Optimizations. Do not do anything if bullet blocker is hidden
        if (isHidden)
        {
            return;
        }

        Color c = sr.color;

        // Slowly decrease the alpha of the color
        if (sr.color.a > 0.01f)
        {
            c = new Color(1.0f, 1.0f, 1.0f, sr.color.a - transitionSpeed);
        }
        else if(sr.color.a <= 0.01f)
        {
            // Alpha is close to zero - mark as completely hidden
            c = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            isHidden = true;
        }

        // Update the alpha on the sprite
        sr.color = c;
    }
}
