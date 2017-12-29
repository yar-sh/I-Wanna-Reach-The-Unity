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

public class SoundManager : MonoBehaviour
{
    public float _soundVolume = 1.0f;
    public float _musicVolume = 1.0f;

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

    string currentLevelMusicName = "";
    Dictionary<string, AudioSource> soundsDict = new Dictionary<string, AudioSource>();
    Dictionary<string, AudioSource> musicDict = new Dictionary<string, AudioSource>();

    void Start()
    {
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

    public void PlaySound(string sound)
    {
        if (soundsDict.ContainsKey(sound))
        {
            soundsDict[sound].Play();
        }
    }

    public void StopAllSounds()
    {
        foreach (KeyValuePair<string, AudioSource> pair in soundsDict)
        {
            pair.Value.Stop();
        }
    }

    public void PlayLevelMusic(string level)
    {
        string levelMusic = GetLevelMusic(level);

        if (musicDict.ContainsKey(levelMusic) && 
            musicDict.ContainsKey(currentLevelMusicName) && 
            (!musicDict[currentLevelMusicName].isPlaying || currentLevelMusicName != levelMusic))
        {
            if (currentLevelMusicName != levelMusic)
            {
                musicDict[currentLevelMusicName].Stop();
                currentLevelMusicName = levelMusic;
            }

            StopAllCoroutines();
            StartCoroutine(AudioEffects.Fade(
                musicDict[currentLevelMusicName], 
                0.0f, 
                _musicVolume,
                0.5f)
            );
        }
    }

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

    string GetLevelMusic(string level)
    {
        switch (level)
        {
            case "sLevel3_1":
            case "sLevel3_2":
            case "sLevel3_3":
                return "Stage3";

            default:
                return "";
        }
    }
}
