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
    public float rotationSpeed = -0.5f;
    public string levelName = "";
    public int levelNumber = -1;

    // When player collides with the warp this is called
    public void DoWarp()
    {
        GameManager.Instance.PlaySound("Warp");

        if (levelName.Length > 0)
        {
            NewSceneManager.GotoScene(levelName);
            return;
        }

        if (levelNumber >= 0)
        {
            NewSceneManager.GotoScene(levelNumber);
            return;
        }

        NewSceneManager.NextScene();
        return;
    }

    void FixedUpdate()
    {
        // Rotation animation
        Quaternion rot = transform.rotation;
        rot.eulerAngles += new Vector3(0,0, rotationSpeed * Time.deltaTime);
        transform.rotation = rot;
    }
}
