///////////////////////////////////////////////////////////////////////
//
//      AudioEffects.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

// Allows for audio source manipulations like fadeIn/fadeOut
public static class AudioEffects
{
    // Fades the audio source from 'from' volume to 'to' volume in a 'fadeTime' amount of time
    public static IEnumerator Fade(AudioSource audioSource, float from, float to, float fadeTime)
    {
        /*
        // TODO: maybe fix someday. Not really needed
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

        // For now just instantly sets to the 'to' volume
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
