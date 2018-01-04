///////////////////////////////////////////////////////////////////////
//
//      NewSceneManager.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

// Wrapper around Unity's scene management
// Has ability to change rooms with fadeIn/fadeOut transitions
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

    public static void NextScene(float fadeOut = 0.0f, float fadeIn = 0.0f)
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > index)
        {
            GotoScene(index,fadeOut, fadeIn);
        }
    }

    public static void PrevScene(float fadeOut = 0.0f, float fadeIn = 0.0f)
    {
        int index = SceneManager.GetActiveScene().buildIndex - 1;
        if (SceneManager.sceneCountInBuildSettings > index && index >=0)
        {
            GotoScene(index, fadeOut, fadeIn);
        }
    }
    
    public static void GotoScene(int index, float fadeOut = 0.0f, float fadeIn = 0.0f)
    {
        if (fadeOut > Mathf.Epsilon || fadeIn > Mathf.Epsilon)
        {
            LevelTransition.LoadLevel(index, fadeOut, fadeIn, Color.black);
        }
        else
        {
            SceneManager.LoadScene(index);
        }
    }

    public static void GotoScene(string index, float fadeOut = 0.0f, float fadeIn = 0.0f)
    {
        if (fadeOut > Mathf.Epsilon || fadeIn > Mathf.Epsilon)
        {
            LevelTransition.LoadLevel(index, fadeOut, fadeIn, Color.black);
        }
        else
        {
            SceneManager.LoadScene(index);
        }
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
