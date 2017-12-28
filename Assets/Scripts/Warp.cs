///////////////////////////////////////////////////////////////////////
//
//      Warp.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Warp : MonoBehaviour
{
    public float rotationSpeed = -27.0f;
    public string levelName = "";
    public int levelNumber = -1;

    public void DoWarp()
    {
        if (levelName.Length > 0)
        {
            GameManager.Instance.NewSceneManager.GotoScene(levelName);
            return;
        }

        if (levelNumber >= 0)
        {
            GameManager.Instance.NewSceneManager.GotoScene(levelNumber);
            return;
        }

        GameManager.Instance.NewSceneManager.NextScene();
        return;
    }

    void Update()
    {
        Quaternion rot = transform.rotation;
        rot.eulerAngles += new Vector3(0,0, rotationSpeed * Time.deltaTime);
        transform.rotation = rot;
    }
}
