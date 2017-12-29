///////////////////////////////////////////////////////////////////////
//
//      NewSceneManager.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine.SceneManagement;

public static class NewSceneManager
{
    public static int SceneIndex
    {
        get
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }

    public static string SceneName
    {
        get
        {
            return SceneManager.GetActiveScene().name;
        }
    }

    public static void NextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > index)
        {
            GotoScene(index);
        }
    }

    public static void PrevScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex - 1;
        if (SceneManager.sceneCountInBuildSettings > index && index >=0)
        {
            GotoScene(index);
        }
    }
    
    public static void GotoScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static void GotoScene(string index)
    {
        SceneManager.LoadScene(index);
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
