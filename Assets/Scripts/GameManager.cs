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
    public SaveLoadManager SaveLoadManager = null;
    public NewSceneManager NewSceneManager = null;

    void Awake()
    {
        SaveLoadManager = new SaveLoadManager();
        NewSceneManager = new NewSceneManager();
        
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

        DontDestroyOnLoad(this);
        //Time.timeScale = 0.2f;
        // After initialization go to the next scene (Main Menu)
        SaveLoadManager.LoadGame();
        
        if (SaveLoadManager.data.valid)
        {
            NewSceneManager.GotoScene(SaveLoadManager.data.sceneIndex);
        }
        else
            NewSceneManager.NextScene();
    }

    void OnLevelWasLoaded()
    {
        DisplayManager = new DisplayManager(Screen.resolutions, FindObjectOfType<Camera>());
    }

    void Update()
    {
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
            RestartGame();
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

    void RestartGame()
    {
        NewSceneManager.GotoScene(0);
    }
}
