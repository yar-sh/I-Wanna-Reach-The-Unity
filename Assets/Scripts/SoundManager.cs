///////////////////////////////////////////////////////////////////////
//
//      SoundManager.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct AudioClipData
{
    public string name;
    public AudioClip clip;
}

// Controls music and sounds. Has a different AudioSource for each music/sound.
// Has separate variables for music and sound volume control
public class SoundManager : MonoBehaviour
{
    float _soundVolume = 1.0f;
    float _musicVolume = 1.0f;

    public float SoundVolume
    {
        get
        {
            return _soundVolume;
        }

        set
        {
            _soundVolume = Mathf.Clamp01(value);
            foreach (KeyValuePair<string, AudioSource> pair in soundsDict)
            {
                pair.Value.volume = _soundVolume;
            }
        }
    }

    public float MusicVolume
    {
        get
        {
            return _musicVolume;
        }

        set
        {
            _musicVolume = Mathf.Clamp01(value);
            foreach (KeyValuePair<string, AudioSource> pair in musicDict)
            {
                pair.Value.volume = _musicVolume;
            }
        }
    }

    public AudioClipData[] sounds = new AudioClipData[5];
    public AudioClipData[] music = new AudioClipData[5];

    string currentLevelMusicName = "MusicEmpty";
    Dictionary<string, AudioSource> soundsDict = new Dictionary<string, AudioSource>();
    Dictionary<string, AudioSource> musicDict = new Dictionary<string, AudioSource>();

    void Start()
    {
        // Add AudioSource component for each uniquely named sound with global sound volume setting
        foreach(AudioClipData acd in sounds)
        {
            if (soundsDict.ContainsKey(acd.name))
            {
                continue;
            }

            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
            source.clip = acd.clip;
            source.loop = false;
            source.volume = Mathf.Clamp01(_soundVolume);

            soundsDict.Add(acd.name, source);
        }

        // Add AudioSource component for each uniquely named music with global music volume setting
        foreach (AudioClipData acd in music)
        {
            if (musicDict.ContainsKey(acd.name))
            {
                continue;
            }

            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
            source.clip = acd.clip;
            source.loop = true;
            source.volume = Mathf.Clamp01(_musicVolume);

            musicDict.Add(acd.name, source);
        }
    }

    // Plays the sound if it exists
    public void PlaySound(string sound)
    {
        if (soundsDict.ContainsKey(sound))
        {
            soundsDict[sound].Play();
        }
    }

    // Stops all sounds from playing
    public void StopAllSounds()
    {
        foreach (KeyValuePair<string, AudioSource> pair in soundsDict)
        {
            pair.Value.Stop();
        }
    }

    // Plays music for the 'level' level
    public void PlayLevelMusic(string level)
    {
        // Get what music to play for this level
        string levelMusic = GetLevelMusic(level);
        // Do a bunch of checks that currently playing music and the music you want to play
        // exist. And that they are not the same (to prevent song restart on restart of the room)
        if (musicDict.ContainsKey(levelMusic) && 
            musicDict.ContainsKey(currentLevelMusicName) && 
            (!musicDict[currentLevelMusicName].isPlaying || currentLevelMusicName != levelMusic))
        {
            // Stop previously playing music
            if (currentLevelMusicName != levelMusic)
            {
                musicDict[currentLevelMusicName].Stop();
                currentLevelMusicName = levelMusic;
            }
            
            // Play new music
            StopAllCoroutines();
            StartCoroutine(AudioEffects.Fade(
                musicDict[currentLevelMusicName], 
                0.0f, 
                _musicVolume,
                0.5f)
            );
        }
    }

    // Fadeout currently playing level music
    public void FadeOutLevelMusic()
    {
        if (musicDict.ContainsKey(currentLevelMusicName))
        {
            StopAllCoroutines();
            StartCoroutine(AudioEffects.Fade(
                musicDict[currentLevelMusicName],
                musicDict[currentLevelMusicName].volume,
                0.0f,
                0.5f)
            );
        }
    }

    // Get what music to play for 'level' level
    string GetLevelMusic(string level)
    {
        // Level-Music Names dictionary kinda
        switch (level)
        {
            case "sMainMenu":
                return "Menu";

            case "sCutscene0":
            case "sCutscene1":
            case "sCutscene2":
            case "sCutscene3":
            case "sCutscene4":
            case "sCutsceneBoss":
                return "Eerie";

            case "sLevel0_1":
            case "sLevel0_2":
            case "sLevel0_3":
                return "Stage0";

            case "sLevel1_1":
            case "sLevel1_2":
            case "sLevel1_3":
                return "Stage1";

            case "sLevel2_1":
            case "sLevel2_2":
            case "sLevel2_3":
                return "Stage2";

            case "sLevel3_1":
            case "sLevel3_2":
            case "sLevel3_3":
                return "Stage3";

            case "sLevel4_1":
            case "sLevel4_2":
            case "sLevel4_3":
                return "Stage4";
                
            // Music for the boss fight is starting in BossController
            case "sBoss":
                return "MusicEmpty";

            case "sStageHub":
                return "StageHub";

            case "sCredits":
                return "Credits";

            default:
                return "MusicEmpty";
        }
    }
}
