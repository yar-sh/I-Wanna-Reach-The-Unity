///////////////////////////////////////////////////////////////////////
//
//      BulletBlocker.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class BulletBlocker : MonoBehaviour
{
    float transitionSpeed = 0.05f;
    bool isHidden = true;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    public void Show()
    {
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        isHidden = false;

        GameManager.Instance.PlaySound("BulletBlocker");
    }

    void FixedUpdate()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color c = sr.color;

        if (!isHidden && sr.color.a > 0.01f)
        {
            c = new Color(1.0f, 1.0f, 1.0f, sr.color.a - transitionSpeed);
        }
        else if(!isHidden && sr.color.a <= 0.01f)
        {
            c = new Color(1.0f, 1.0f, 1.0f, 0.0f);

            isHidden = true;
        }

        sr.color = c;
    }
}
