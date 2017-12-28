///////////////////////////////////////////////////////////////////////
//
//      NewSceneManager.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine.SceneManagement;

public class NewSceneManager
{
    public int SceneIndex
    {
        get
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }

    public void NextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > index)
        {
            GotoScene(index);
        }
    }

    public void PrevScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex - 1;
        if (SceneManager.sceneCountInBuildSettings > index && index >=0)
        {
            GotoScene(index);
        }
    }
    
    public void GotoScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void GotoScene(string index)
    {
        SceneManager.LoadScene(index);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
