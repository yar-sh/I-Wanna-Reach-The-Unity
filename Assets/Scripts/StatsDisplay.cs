///////////////////////////////////////////////////////////////////////
//
//      StatsDisplay.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using System;
using UnityEngine;
using UnityEngine.UI;

// Stats display that displays deaths and time during the game
public class StatsDisplay : MonoBehaviour
{
    float transitionSpeed = 0.02f;
    bool preventHiding = true;
    Text statsText;
    SpriteRenderer sr;
    CameraAdjuster camAdjuster;
    Vector3 pos = Vector3.zero;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        statsText = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        camAdjuster = FindObjectOfType<Camera>().GetComponent<CameraAdjuster>();
    }

    // Shows the stats
    public void Show()
    {
        pos = camAdjuster.transform.position;
        pos.z = transform.position.z;
        pos.y = 30;
        transform.position = pos;

        transform.position = pos;
        preventHiding = true;
        sr.color = new Color(1.0f, 1.0f, 1.0f, 0.85f);
        statsText.color = new Color(1.0f, 1.0f, 1.0f, 0.85f);
    }
    
    // Hides the stats with transition
    public void Hide()
    {
        preventHiding = false;
    }

    void FixedUpdate()
    {
        // Optimizations. Do not do anything if stats are completely hidden
        if (sr.color.a < Mathf.Epsilon)
        {
            return;
        }

        // Update position and follow the camera
        pos = camAdjuster.transform.position;
        pos.z = transform.position.z;
        pos.y = 30;
        transform.position = pos;

        // Update the stats if they are even slightly seen
        Color c = sr.color;
        TimeSpan t = TimeSpan.FromSeconds(SaveLoadManager.data.time);

        statsText.text = string.Format("TIME: {0:D2}:{1:D2}:{2:D2}s\n\nDEATHS: {3}",
                t.Hours,
                t.Minutes,
                t.Seconds,
                SaveLoadManager.data.deaths);
        
        if (preventHiding)
        {
            return;
        }

        // Slowly decrease the alpha of the color
        if (sr.color.a > 0.01f)
        {
            c = new Color(1.0f, 1.0f, 1.0f, sr.color.a - transitionSpeed);
        }
        else if (sr.color.a <= 0.01f)
        {
            // Alpha is close to zero - mark as completely hidden
            c = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            preventHiding = true;
        }

        // Update the alpha on the sprite and text
        sr.color = c;
        statsText.color = c;
    }
}
