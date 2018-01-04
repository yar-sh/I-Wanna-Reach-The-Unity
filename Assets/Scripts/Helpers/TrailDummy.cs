///////////////////////////////////////////////////////////////////////
//
//      TrailDummy.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class TrailDummy : MonoBehaviour
{
    public float startAlpha = 0.9f;
    public float endAlpha = 0.0f;
    public float decreaseAlphaRate = 0.1f;
    public float decreaseAlphaEveryNFrames = 1.0f;
    public Sprite sprite;

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        Invoke("DecreaseAlpha", 0.0f);
    }

    void DecreaseAlpha()
    {
        Color c = sr.color;

        if (c.a <= endAlpha)
        {
            Destroy(gameObject);
            return;
        }

        c.a -= decreaseAlphaRate;

        sr.color = c;
        
        Invoke("DecreaseAlpha", 1.0f / GM.fps * decreaseAlphaEveryNFrames);
    }
}
