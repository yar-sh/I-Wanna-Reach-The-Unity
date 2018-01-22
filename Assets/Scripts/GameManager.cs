///////////////////////////////////////////////////////////////////////
//
//      GameManager.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public static bool debugMode = true;

    [HideInInspector]
    public DisplayManager DisplayManager;
    [HideInInspector]
    public SoundManager soundManager;
    [HideInInspector]
    public static bool playerIsInvincible = false;


    static GameManager _instance = null;

    void Awake()
    {
        if (NewSceneManager.SceneIndex != 0)
        {
            Debug.LogError("Game must be started from sInit scene!");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        // Typical singleton
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Create black transition shader at runtime
        // For the actual source of this see https://answers.unity.com/answers/119951/view.html
#if UNITY_EDITOR
        var resDir = new System.IO.DirectoryInfo(System.IO.Path.Combine(Application.dataPath, "Resources"));
        if (!resDir.Exists)
            resDir.Create();
        Shader s = Shader.Find("Plane/No zTest");
        if (s == null)
        {
            string shaderText = "Shader \"Plane/No zTest\" { SubShader { Pass { Blend SrcAlpha OneMinusSrcAlpha ZWrite Off Cull Off Fog { Mode Off } BindChannels { Bind \"Color\",color } } } }";
            string path = System.IO.Path.Combine(resDir.FullName, "Plane_No_zTest.shader");
            System.IO.File.WriteAllText(path, shaderText);
            UnityEditor.AssetDatabase.Refresh(UnityEditor.ImportAssetOptions.ForceSynchronousImport);
            UnityEditor.AssetDatabase.LoadAssetAtPath<Shader>("Resources/Plane_No_zTest.shader");
            s = Shader.Find("Plane/No zTest");
        }
        Material mat = new Material(s);
        mat.name = "Plane_No_zTest";
        UnityEditor.AssetDatabase.CreateAsset(mat, "Assets/Resources/Plane_No_zTest.mat");
#endif

        soundManager = transform.GetChild(0).GetComponent<SoundManager>();

        DontDestroyOnLoad(this);

        SaveLoadManager.LoadGame();
    }

    void OnLevelWasLoaded()
    {
        // Recreate display manager for each level, since we always have a new camera object
        DisplayManager = new DisplayManager(Screen.resolutions, FindObjectOfType<Camera>().GetComponent<CameraAdjuster>());

        // Now we can extract data from playerprefs regarding game settings
        if (PlayerPrefs.HasKey("FullscreenFlag"))
        {
            DisplayManager.fullscreen = PlayerPrefs.GetInt("FullscreenFlag") == 1;
        }

        if (PlayerPrefs.HasKey("ResolutionIndex"))
        {
            DisplayManager.ApplyResolution((uint)PlayerPrefs.GetInt("ResolutionIndex"));
        }
        
        if (soundManager != null)
        {
            if (PlayerPrefs.HasKey("SoundVolume"))
            {
                soundManager.SoundVolume = PlayerPrefs.GetFloat("SoundVolume");
            }

            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                soundManager.MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
            }

            soundManager.PlayLevelMusic(NewSceneManager.SceneName);
        }
    }

    void Update()
    {
        // On the first update in the sInit go to the appropriate scene. This ensures that
        // SoundManager and all other objects have their Start method executed
        if (NewSceneManager.SceneIndex == 0)
        {
            // Go to the main menu
            NewSceneManager.NextScene(0.0f, 4.0f);
        }
        
        // DEBUG/TEST CODE (BUT ALSO UNSKIPPABLE CREDITS LUL):
        if (!debugMode || NewSceneManager.SceneName == "sCredits")
        {
            return;
        }
        
        // Go to the next scene
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            NewSceneManager.NextScene();
        }

        // Go to the previous scene
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            NewSceneManager.PrevScene();
        }

        // Toggle player invincibility
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerIsInvincible = !playerIsInvincible;

            if (playerIsInvincible)
            {
                soundManager.PlaySound("Item");
            }
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
