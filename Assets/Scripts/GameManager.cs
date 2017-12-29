///////////////////////////////////////////////////////////////////////
//
//      GameManager.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public DisplayManager DisplayManager = null;

    SoundManager soundManager = null;

    void Awake()
    {
        if (NewSceneManager.SceneIndex != 0)
        {
            Debug.LogError("Game must be started from sInit scene!");
            Application.Quit();
        }

        // Make sure there is only one GameManager object
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        soundManager = transform.GetChild(0).GetComponent<SoundManager>();

        DontDestroyOnLoad(this);

        SaveLoadManager.LoadGame();
    }

    void OnLevelWasLoaded()
    {
        DisplayManager = new DisplayManager(Screen.resolutions, FindObjectOfType<Camera>());
        soundManager.PlayLevelMusic(NewSceneManager.SceneName);
    }

    void Update()
    {
        // On the first update in the sInit go to the appropriate scene. This ensures that
        // SoundManager and all other objects have their Start method executed
        if (NewSceneManager.SceneIndex == 0)
        {
            if (SaveLoadManager.data.valid)
            {
                NewSceneManager.GotoScene(SaveLoadManager.data.sceneIndex);
            }
            else
                NewSceneManager.NextScene();
        }

        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            NewSceneManager.NextScene();
        }
        
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            NewSceneManager.PrevScene();
        }

        //DEBUG/TEST CODE:
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Restars game from sInit
        if (Input.GetKeyDown(KeyCode.F2))
        {
            NewSceneManager.GotoScene(0);
        }

        // Go to the next available resolution
        if (Input.GetKeyDown(KeyCode.F8))
        {
            DisplayManager.ApplyResolution(DisplayManager.NextResolution());
        }
        
        // Go to the previous available resolution
        if (Input.GetKeyDown(KeyCode.F7))
        {
            DisplayManager.ApplyResolution(DisplayManager.PrevResolution());
        }

        // Switch fullscreen mode
        if (Input.GetKeyDown(KeyCode.F4))
        {
            DisplayManager.fullscreen = !DisplayManager.fullscreen;
        }
    }
    
    public void PlaySound(string sound)
    {
        soundManager.PlaySound(sound);
    }

    public void StopAllSounds()
    {
        soundManager.StopAllSounds();
    }

    public void FadeOutLevelMusic()
    {
        soundManager.FadeOutLevelMusic();
    }
}
