///////////////////////////////////////////////////////////////////////
//
//      GameOverAnimation.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Controls gameover overlay animation
public class GameOverAnimation : MonoBehaviour
{
    public GameObject redBackground;
    public GameObject blackBar;

    bool animationFinished = false;
    float textFadeSpeed = 0.03f;
    float redBGFadeSpeed = 0.007f;
    float barMoveSpeed = 2.8f;
    GameObject topBar;
    GameObject bottomBar;
    GameObject redBG;

    void Start()
    {
        // Create all needed compinents
        redBG = Instantiate(redBackground);
        topBar = Instantiate(blackBar);
        bottomBar = Instantiate(blackBar, new Vector3(1160, -192, -8), Quaternion.Euler(0,0,180));
    }

    void FixedUpdate()
    {
        // Optimizations
        if (animationFinished)
        {
            return;
        }

        //
        //
        // Do stuff to make things do things
        //
        //

        SpriteRenderer srText = GetComponent<SpriteRenderer>();
        SpriteRenderer srBG = redBG.GetComponent<SpriteRenderer>();

        if (srText.color.a < 1.0f)
        {
            srText.color = new Color(1.0f, 1.0f, 1.0f, srText.color.a + textFadeSpeed);
        }

        if (srBG.color.a < 0.45f)
        {
            srBG.color = new Color(1.0f, 1.0f, 1.0f, srBG.color.a + redBGFadeSpeed );
        }

        if (topBar.transform.position.y > 585.0f)
        {
            topBar.transform.localScale += new Vector3(0, barMoveSpeed /800.0f );
            bottomBar.transform.localScale += new Vector3(0, barMoveSpeed / 800.0f);
            topBar.transform.position += new Vector3(0, -barMoveSpeed);
            bottomBar.transform.position += new Vector3(0, barMoveSpeed);
        }
        else
        {
            // Animation is finished when topBar reaches specific MAJYK coordinates
            animationFinished = true;
        }
    }
}
