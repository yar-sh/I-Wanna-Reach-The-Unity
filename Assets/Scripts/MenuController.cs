///////////////////////////////////////////////////////////////////////
//
//      MenuController.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using System;
using UnityEngine;
using UnityEngine.UI;

/*
 * Я периодически вообще адовый код ебашу. Ну вот такой рецепт усредненный,
 * потому что вариаций масса. Берется идея, она не продумывается, думать - 
 * это не про меня. Я беру эту идею, закатываюсь в редактор кода и начинаю
 * говнокодить. Добавляю в него огромное количество анти-паттернов,
 * функционального программирования, менеджеров и контроллеров, ВЛОЖЕНИЯ
 * КОДА НА 10 УРОВНЕЙ! для пущей картины, ноль комментариев. Всё это 
 * кодится до трёх тысяч строк в одном файле. Потом я останавливаюсь и даю
 * коду отлежаться до следующего дня. Потом на трезвую голову я начинаю
 * всё это рефакторить. Рефакторю и приговариваю полушепотом ух бля. При 
 * этом у меня на лбу аж пот выступает. Я любезно тиммейтам предлагаю, но
 * они отказываются. Надо ли говорить о том, какая дичайшая головная боль
 * потом? Голова болит так, что я пушу сразу в мастер ветку. 
 */
// A thing that controls entire main menu. Everything is in one file. It is a mess
// But hey, I'm in LudumDare Extreme mode. If it works - it is good enough.
public class MenuController : MonoBehaviour
{
    public GameObject title;
    public GameObject pressZKey;
    public GameObject bg1;
    public GameObject bg2;
    public GameObject newGameButton;
    public GameObject loadGameButton;
    public GameObject optionsButton;
    public GameObject quitButton;
    public GameObject gameStats;
    public GameObject soundVolume;
    public GameObject musicVolume;
    public GameObject backButton;
    public GameObject resolutionButton;
    public GameObject fullscreenButton;
    public Sprite newGameAlt1;
    public Sprite loadGameAlt1;
    public Sprite loadGameAlt2;
    public Sprite optionsAlt1;
    public Sprite quitAlt1;
    public Sprite soundVolumeAlt1;
    public Sprite musicVolumeAlt1;
    public Sprite backAlt1;
    public Sprite resolutionAlt1;
    public Sprite fullscreenAlt1;

    float pressZKeyWobbleStrength = 0.07f;
    float titleWobbleStrength= 0.1f;
    float bgRotationSpeed = 0.1f;
    float bgScaleStrength = 0.0035f;
    float bgSpeedMultiplier = 0.35f;
    uint menuState = 0;
    uint state1SelectedOption = 0;
    uint state2SelectedOption = 0;
    bool lockControls = false;

    // Create and set all menu objects including backgrounds
    void Start()
    {
        bg1 = Instantiate(bg1);
        bg1.transform.localScale *= 0.85f;

        title = Instantiate(title);
        pressZKey = Instantiate(pressZKey);
        bg2 = Instantiate(bg2);
        newGameButton = Instantiate(newGameButton);
        loadGameButton = Instantiate(loadGameButton);
        optionsButton = Instantiate(optionsButton);
        quitButton = Instantiate(quitButton);
        gameStats = Instantiate(gameStats);
        soundVolume = Instantiate(soundVolume);
        musicVolume = Instantiate(musicVolume);
        backButton = Instantiate(backButton);
        resolutionButton = Instantiate(resolutionButton);
        fullscreenButton = Instantiate(fullscreenButton);

        if (!SaveLoadManager.data.valid)
        {
            loadGameButton.GetComponent<SpriteRenderer>().sprite = loadGameAlt2;
        }
        else
        {
            TimeSpan t = TimeSpan.FromSeconds(SaveLoadManager.data.time);
            gameStats.transform.GetChild(0).GetComponent<Text>().text = 
                string.Format("TIME: {0:D2}:{1:D2}:{2:D2}s\n\nDEATHS: {3}",
                t.Hours,
                t.Minutes,
                t.Seconds,
                SaveLoadManager.data.deaths);
        }

        // All of them are hidden by default
        HideAll();
    }
    
    // Animate things to move
    void FixedUpdate()
    { 
        Vector3 titlePos = title.transform.position;
        titlePos.y += Mathf.Sin(Time.time + Mathf.PI) * titleWobbleStrength;
        title.transform.position = titlePos;

        if (pressZKey != null)
        {
            Vector3 pressZKeyPos = pressZKey.transform.position;
            pressZKeyPos.y += Mathf.Sin(Time.time) * pressZKeyWobbleStrength;
            pressZKey.transform.position = pressZKeyPos;
        }

        Quaternion rot1 = bg1.transform.rotation;
        rot1.eulerAngles += new Vector3(0, 0, bgRotationSpeed);
        bg1.transform.rotation = rot1;
        
        Quaternion rot2 = bg2.transform.rotation;
        rot2.eulerAngles += new Vector3(0, 0, -bgRotationSpeed);
        bg2.transform.rotation = rot2;

        Vector3 scale1 = bg1.transform.localScale;
        Color c1 = Color.HSVToRGB(Mathf.Abs(Mathf.Sin(bgSpeedMultiplier*Time.time)), 1.0f, 1.0f);
        c1.a = 0.4f;
        scale1.x += Mathf.Sin(0.5f * Time.time) * bgScaleStrength;
        scale1.y += Mathf.Sin(0.5f * Time.time) * bgScaleStrength;
        bg1.transform.localScale = scale1;
        bg1.GetComponent<SpriteRenderer>().color = c1;

        Vector3 scale2 = bg2.transform.localScale;
        Color c2 = Color.HSVToRGB(1.0f - Mathf.Abs(Mathf.Sin(bgSpeedMultiplier * Time.time + Mathf.PI)), 1.0f, 1.0f);
        c2.a = 0.4f;
        scale2.x += Mathf.Sin(0.5f * Time.time + Mathf.PI) * bgScaleStrength;
        scale2.y += Mathf.Sin(0.5f * Time.time + Mathf.PI) * bgScaleStrength;
        bg2.transform.localScale = scale2;
        bg2.GetComponent<SpriteRenderer>().color = c2;
    }

    void Update()
    {
        // Menu is divided into "states". 
        // 0 - press z key to continue
        // 1 - main menu
        // 2 - options menu
        // TODO: move this to enum when refactoring
        switch (menuState)
        {
            // In press z key to continue state
            case 0:
                // Go to the next state (main menu)
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    GameManager.Instance.PlaySound("MenuSelectOption");

                    Destroy(pressZKey);
                    menuState = 1;

                    newGameButton.GetComponent<Renderer>().enabled = true;
                    loadGameButton.GetComponent<Renderer>().enabled = true;
                    optionsButton.GetComponent<Renderer>().enabled = true;
                    quitButton.GetComponent<Renderer>().enabled = true;

                    State1ToggleOptions();
                }

                CheckGameExit();
                break;

            // In main menu state
            case 1:
                // Moving down the list
                if (Input.GetKeyDown(KeyCode.DownArrow) && !lockControls)
                {
                    GameManager.Instance.PlaySound("MenuMoveOption");
                    
                    State1ToggleOptions();

                    if (state1SelectedOption == 3)
                    {
                        state1SelectedOption = 0;
                    }
                    else if (state1SelectedOption == 0 && !SaveLoadManager.data.valid)
                    {
                        state1SelectedOption = 2;
                    }
                    else
                    {
                        state1SelectedOption++;
                    }

                    State1ToggleOptions();
                }

                // Moving up the list
                if (Input.GetKeyDown(KeyCode.UpArrow) && !lockControls)
                {
                    GameManager.Instance.PlaySound("MenuMoveOption");

                    State1ToggleOptions();

                    if (state1SelectedOption == 0)
                    {
                        state1SelectedOption = 3;
                    }
                    else if (state1SelectedOption == 2 && !SaveLoadManager.data.valid)
                    {
                        state1SelectedOption = 0;
                    }
                    else
                    {
                        state1SelectedOption--;
                    }

                    State1ToggleOptions();
                }

                // An option was chosen
                if (Input.GetKeyDown(KeyCode.Z) && !lockControls)
                {
                    State1ToggleOptions();
                    GameManager.Instance.PlaySound("MenuSelectOption");
                    State1OnOptionPress();
                }

                CheckGameExit();
                break;

            // In options state
            case 2:
                // Moving down the list
                if (Input.GetKeyDown(KeyCode.DownArrow) && !lockControls)
                {
                    GameManager.Instance.PlaySound("MenuMoveOption");

                    State2ToggleOptions();

                    if (state2SelectedOption == 4)
                    {
                        state2SelectedOption = 0;
                    }
                    else
                    {
                        state2SelectedOption++;
                    }

                    State2ToggleOptions();
                }

                // Moving up the list
                if (Input.GetKeyDown(KeyCode.UpArrow) && !lockControls)
                {
                    GameManager.Instance.PlaySound("MenuMoveOption");
                    
                    State2ToggleOptions();

                    if (state2SelectedOption == 0)
                    {
                        state2SelectedOption = 4;
                    }
                    else
                    {
                        state2SelectedOption--;
                    }

                    State2ToggleOptions();
                }
                
                // Decrease volume options
                if (Input.GetKey(KeyCode.LeftArrow) && !lockControls)
                {
                    State2OnOptionChange(-Time.deltaTime*0.25f);
                }

                // Increase volume options
                if (Input.GetKey(KeyCode.RightArrow) && !lockControls)
                {
                    State2OnOptionChange(Time.deltaTime * 0.25f);
                }

                // Controls get locked by resolution setting (and fullscreen), unlock them
                if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) && lockControls)
                {
                    lockControls = false;
                }

                // An option was chosen
                if (Input.GetKeyDown(KeyCode.Z) && !lockControls)
                {
                    State2OnOptionPress();
                }

                // Go back to the main menu
                if (Input.GetKeyDown(KeyCode.Escape) && !lockControls)
                {
                    GameManager.Instance.PlaySound("MenuSelectOption");
                    State2ToggleOptions();

                    menuState = 1;
                    HideAll();

                    newGameButton.GetComponent<Renderer>().enabled = true;
                    loadGameButton.GetComponent<Renderer>().enabled = true;
                    optionsButton.GetComponent<Renderer>().enabled = true;
                    quitButton.GetComponent<Renderer>().enabled = true;

                    State1ToggleOptions();
                }

                break;
        }
    }

    // When something is chosen in main menu
    void State1OnOptionPress()
    {
        // Do stuff based on selected menu option
        switch (state1SelectedOption)
        {
            // Start new game
            case 0:
                lockControls = true;
                SaveLoadManager.data = SaveLoadManager.defaultData;
                NewSceneManager.GotoScene("sCutscene0",1.0f,1.5f);
                break;
            
            // Load save file
            case 1:
                lockControls = true;
                NewSceneManager.GotoScene(SaveLoadManager.data.sceneIndex, 0.75f, 0.5f);
                break;
            
            // Go to options menu state
            case 2:
                menuState = 2;
                HideAll();

                fullscreenButton.GetComponent<Renderer>().enabled = true;
                resolutionButton.GetComponent<Renderer>().enabled = true;
                soundVolume.GetComponent<Renderer>().enabled = true;
                backButton.GetComponent<Renderer>().enabled = true;
                musicVolume.GetComponent<Renderer>().enabled = true;
                soundVolume.transform.GetChild(0).GetComponent<Canvas>().enabled = true;
                musicVolume.transform.GetChild(0).GetComponent<Canvas>().enabled = true;
                resolutionButton.transform.GetChild(0).GetComponent<Canvas>().enabled = true;
                fullscreenButton.transform.GetChild(0).GetComponent<Canvas>().enabled = true;

                fullscreenButton.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = 
                    GameManager.Instance.DisplayManager.fullscreen ? "ON" : "OFF";
                resolutionButton.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = 
                    GameManager.Instance.DisplayManager.Resolution.width + "x" + GameManager.Instance.DisplayManager.Resolution.height;
                soundVolume.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = 
                    (GameManager.Instance.soundManager.SoundVolume * 100).ToString("F0") + "%";
                musicVolume.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = 
                    (GameManager.Instance.soundManager.MusicVolume * 100).ToString("F0") + "%";

                State2ToggleOptions();

                break;
            
            // Guess what this does
            case 3:
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                Application.Quit(); 
                break;
        }
    }

    // Toggles on and off sprites for the main menu state based on selected option
    void State1ToggleOptions()
    {
        switch(state1SelectedOption)
        {
            case 0:
                Sprite t0 = newGameAlt1;
                newGameAlt1 = newGameButton.GetComponent<SpriteRenderer>().sprite;
                newGameButton.GetComponent<SpriteRenderer>().sprite = t0;
                break;

            case 1:
                Sprite t1 = loadGameAlt1;
                loadGameAlt1 = loadGameButton.GetComponent<SpriteRenderer>().sprite;
                loadGameButton.GetComponent<SpriteRenderer>().sprite = t1;
                gameStats.GetComponent<Canvas>().enabled = !gameStats.GetComponent<Canvas>().enabled;
                break;

            case 2:
                Sprite t2 = optionsAlt1;
                optionsAlt1 = optionsButton.GetComponent<SpriteRenderer>().sprite;
                optionsButton.GetComponent<SpriteRenderer>().sprite = t2;
                break;

            case 3:
                Sprite t3 = quitAlt1;
                quitAlt1 = quitButton.GetComponent<SpriteRenderer>().sprite;
                quitButton.GetComponent<SpriteRenderer>().sprite = t3;
                break;
        }
    }

    // Change volume options
    void State2OnOptionChange(float delta)
    {
        switch (state2SelectedOption)
        {
            // Fullscreen change
            case 0:
                lockControls = true;

                GameManager.Instance.DisplayManager.fullscreen = !GameManager.Instance.DisplayManager.fullscreen;
                fullscreenButton.transform.GetChild(0).GetChild(0).GetComponent<Text>().text =
                    GameManager.Instance.DisplayManager.fullscreen ? "OFF" : "ON";

                PlayerPrefs.SetInt("FullscreenFlag", GameManager.Instance.DisplayManager.fullscreen ? 1 : 0);

                GameManager.Instance.PlaySound("MenuMoveOption");
                break;

            // Resolution change
            case 1:
                lockControls = true;
                if (delta > 0.0f)
                {
                    GameManager.Instance.DisplayManager.ApplyResolution(GameManager.Instance.DisplayManager.NextResolution());
                }
                else
                {
                    GameManager.Instance.DisplayManager.ApplyResolution(GameManager.Instance.DisplayManager.PrevResolution());
                }
                
                resolutionButton.transform.GetChild(0).GetChild(0).GetComponent<Text>().text =
                     GameManager.Instance.DisplayManager.Resolution.width + "x" + GameManager.Instance.DisplayManager.Resolution.height;

                PlayerPrefs.SetInt("ResolutionIndex", (int)GameManager.Instance.DisplayManager.ResolutionIndex);

                GameManager.Instance.PlaySound("MenuMoveOption");
                break;

            // Sound volume change
            case 2:
                GameManager.Instance.soundManager.SoundVolume += delta;
                soundVolume.transform.GetChild(0).GetChild(0).GetComponent<Text>().text =
                    (GameManager.Instance.soundManager.SoundVolume * 100).ToString("F0") + "%";

                PlayerPrefs.SetFloat("SoundVolume", GameManager.Instance.soundManager.SoundVolume);

                break;
            
            // Music volume change
            case 3:
                GameManager.Instance.soundManager.MusicVolume += delta;
                musicVolume.transform.GetChild(0).GetChild(0).GetComponent<Text>().text =
                    (GameManager.Instance.soundManager.MusicVolume * 100).ToString("F0") + "%";

                PlayerPrefs.SetFloat("MusicVolume", GameManager.Instance.soundManager.MusicVolume);

                break;
        }
    }

    // When something is chosen in options menu state
    void State2OnOptionPress()
    {
        // Do stuff based on selected menu option
        switch (state2SelectedOption)
        {
            // If you press Z on soundVolume thingy you'll get a sound
            case 2:
                GameManager.Instance.PlaySound("MenuSelectOption");
                break;
            
            // Go back to the main menu state
            case 4:
                GameManager.Instance.PlaySound("MenuSelectOption");
                State2ToggleOptions();

                menuState = 1;
                HideAll();

                newGameButton.GetComponent<Renderer>().enabled = true;
                loadGameButton.GetComponent<Renderer>().enabled = true;
                optionsButton.GetComponent<Renderer>().enabled = true;
                quitButton.GetComponent<Renderer>().enabled = true;

                State1ToggleOptions();
                break;
        }
    }

    // Toggles on and off sprites for the options menu based on selected option
    void State2ToggleOptions()
    {
        switch (state2SelectedOption)
        {
            case 0:
                Sprite t0 = fullscreenAlt1;
                fullscreenAlt1 = fullscreenButton.GetComponent<SpriteRenderer>().sprite;
                fullscreenButton.GetComponent<SpriteRenderer>().sprite = t0;
                break;

            case 1:
                Sprite t1 = resolutionAlt1;
                resolutionAlt1 = resolutionButton.GetComponent<SpriteRenderer>().sprite;
                resolutionButton.GetComponent<SpriteRenderer>().sprite = t1;
                break;

            case 2:
                Sprite t2 = soundVolumeAlt1;
                soundVolumeAlt1 = soundVolume.GetComponent<SpriteRenderer>().sprite;
                soundVolume.GetComponent<SpriteRenderer>().sprite = t2;
                break;

            case 3:
                Sprite t3 = musicVolumeAlt1;
                musicVolumeAlt1 = musicVolume.GetComponent<SpriteRenderer>().sprite;
                musicVolume.GetComponent<SpriteRenderer>().sprite = t3;
                break;

            case 4:
                Sprite t4 = backAlt1;
                backAlt1 = backButton.GetComponent<SpriteRenderer>().sprite;
                backButton.GetComponent<SpriteRenderer>().sprite = t4;
                break;
        }
    }

    // Hides all of the menu elements and resets selected options for each state
    void HideAll()
    {
        PlayerPrefs.Save();

        state1SelectedOption = 0;
        state2SelectedOption = 0;

        newGameButton.GetComponent<Renderer>().enabled = false;
        loadGameButton.GetComponent<Renderer>().enabled = false;
        optionsButton.GetComponent<Renderer>().enabled = false;
        quitButton.GetComponent<Renderer>().enabled = false;
        soundVolume.GetComponent<Renderer>().enabled = false;
        musicVolume.GetComponent<Renderer>().enabled = false;
        backButton.GetComponent<Renderer>().enabled = false;
        resolutionButton.GetComponent<Renderer>().enabled = false;
        fullscreenButton.GetComponent<Renderer>().enabled = false;
        gameStats.GetComponent<Canvas>().enabled = false;
        soundVolume.transform.GetChild(0).GetComponent<Canvas>().enabled = false;
        musicVolume.transform.GetChild(0).GetComponent<Canvas>().enabled = false;
        resolutionButton.transform.GetChild(0).GetComponent<Canvas>().enabled = false;
        fullscreenButton.transform.GetChild(0).GetComponent<Canvas>().enabled = false;
    }

    void CheckGameExit()
    {
        // Escape - exit the game
        if (Input.GetKeyDown(KeyCode.Escape) && !lockControls)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

    }
}
