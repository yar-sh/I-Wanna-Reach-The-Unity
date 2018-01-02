///////////////////////////////////////////////////////////////////////
//
//      LightsOutController.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Lights Out gimmick controller
// When player leaves a save point, foreground starts to black out
public class LightsOutController : MonoBehaviour
{
    [HideInInspector]
    public bool doFading = false;
    float timeToFade = 0.1f;
    SpriteRenderer sr;
    Player player = null;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Enables when player leaves the save point
    public void BeginFade(float timeToFullFading)
    {
        doFading = true;
        timeToFade = timeToFullFading; 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Disables when player enters the save point
    public void StopFade()
    {
        doFading = false;
        sr.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    void Update()
    {
        // Optimizations
        if (!doFading || player == null || player.isDead)
        {
            return;
        }

        Color c = sr.color;

        // Slowly increase the alpha of the color
        if (sr.color.a < 0.99f)
        {
            c = new Color(1.0f, 1.0f, 1.0f, sr.color.a + Time.deltaTime / timeToFade);
        }
        else if (sr.color.a >= 0.99f)
        {
            // Alpha is close to max
            c = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            doFading = false;

            // Full blackout - kill player
            player.Die();
        }

        sr.color = c;
    }
}
