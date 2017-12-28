///////////////////////////////////////////////////////////////////////
//
//      BulletBlocker.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class BulletBlocker : MonoBehaviour
{
    public float transitionSpeed = 4.0f;
    bool isHidden = true;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    public void Show()
    {
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        
        isHidden = false;
    }

    void Update()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color c = sr.color;

        if (!isHidden && sr.color.a > 0.01f)
        {
            c = new Color(1.0f, 1.0f, 1.0f, sr.color.a - transitionSpeed * Time.deltaTime);
        }
        else if(!isHidden && sr.color.a <= 0.01f)
        {
            c = new Color(1.0f, 1.0f, 1.0f, 0.0f);

            isHidden = true;
        }

        sr.color = c;
    }
}
