///////////////////////////////////////////////////////////////////////
//
//      AudioEffects.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public static class AudioEffects
{
    //TODO maybe fix someday
    public static IEnumerator Fade(AudioSource audioSource, float from, float to, float fadeTime)
    {
        /*
        audioSource.volume = from;

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (from > to)
        {
            while (audioSource.volume > to)
            {
                audioSource.volume += -Time.deltaTime / fadeTime;
                yield return null;
            }
        }
        else
        {
            while (audioSource.volume < to)
            {
                audioSource.volume += Time.deltaTime / fadeTime;
                yield return null;
            }
        }

        audioSource.volume = to;
        */

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (to < Mathf.Epsilon)
        {
            audioSource.Pause();
        }

            audioSource.volume = to;
        
        yield return null;
    }
}
