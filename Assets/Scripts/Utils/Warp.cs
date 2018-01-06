///////////////////////////////////////////////////////////////////////
//
//      Warp.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Warp object. Moves you to the next level unless otherwise specified
public class Warp : MonoBehaviour
{
    public string levelName = "";
    public int levelNumber = -1;
    public float fadeOutTime = 0.3f;
    public float fadeInTime = 0.2f;

    float rotationSpeed = -0.8f;

    // When player collides with the warp this is called
    public void DoWarp()
    {
        GameManager.Instance.PlaySound("Warp");
        
        // If this warp is the last one - mark the game as completed
        if(tag == "GameClearWarp")
        {
            SaveLoadManager.data.gameClear = true;
            SaveLoadManager.SaveCurrentData();
        }

        if (levelName.Length > 0)
        {
            NewSceneManager.GotoScene(levelName,fadeOutTime, fadeInTime);
            return;
        }

        if (levelNumber >= 0)
        {
            NewSceneManager.GotoScene(levelNumber, fadeOutTime, fadeInTime);
            return;
        }

        NewSceneManager.NextScene(fadeOutTime, fadeInTime);
        return;
    }

    void FixedUpdate()
    {
        // Rotation animation
        Quaternion rot = transform.rotation;
        rot.eulerAngles += new Vector3(0,0, rotationSpeed);
        transform.rotation = rot;
    }
}
