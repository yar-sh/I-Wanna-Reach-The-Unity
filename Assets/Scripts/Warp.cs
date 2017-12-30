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

    float rotationSpeed = -0.8f;

    // When player collides with the warp this is called
    public void DoWarp()
    {
        GameManager.Instance.PlaySound("Warp");

        if (levelName.Length > 0)
        {
            NewSceneManager.GotoScene(levelName, 0.3f, 0.2f);
            return;
        }

        if (levelNumber >= 0)
        {
            NewSceneManager.GotoScene(levelNumber, 0.3f, 0.2f);
            return;
        }

        NewSceneManager.NextScene(0.3f, 0.2f);
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
