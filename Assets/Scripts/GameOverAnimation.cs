///////////////////////////////////////////////////////////////////////
//
//      GameOverAnimation.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class GameOverAnimation : MonoBehaviour
{
    public GameObject redBackground;
    public GameObject blackBar;

    bool animationFinished = false;
    float textFadeSpeed = 4.0f;
    float redBGFadeSpeed = 0.7f;
    float barMoveSpeed = 127.0f;
    GameObject topBar;
    GameObject bottomBar;
    GameObject redBG;

    void Start()
    {
        redBG = Instantiate(redBackground);
        topBar = Instantiate(blackBar);
        bottomBar = Instantiate(blackBar, new Vector3(1160, -192, -8), Quaternion.Euler(0,0,180));
    }

    void Update()
    {
        if (animationFinished)
        {
            return;
        }

        SpriteRenderer srText = GetComponent<SpriteRenderer>();
        SpriteRenderer srBG = redBG.GetComponent<SpriteRenderer>();

        if (srText.color.a < 1.0f)
        {
            srText.color = new Color(1.0f, 1.0f, 1.0f, srText.color.a + textFadeSpeed * Time.deltaTime);
        }

        if (srBG.color.a < 0.45f)
        {
            srBG.color = new Color(1.0f, 1.0f, 1.0f, srBG.color.a + redBGFadeSpeed * Time.deltaTime);
        }

        if (topBar.transform.position.y > 585.0f)
        {
            topBar.transform.localScale += new Vector3(0, barMoveSpeed /800.0f * Time.deltaTime);
            bottomBar.transform.localScale += new Vector3(0, barMoveSpeed / 800.0f * Time.deltaTime);
            topBar.transform.position += new Vector3(0, -barMoveSpeed * Time.deltaTime);
            bottomBar.transform.position += new Vector3(0, barMoveSpeed * Time.deltaTime);
        }
        else
        {
            animationFinished = true;
        }
    }
}
