using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour {

    public List<AudioSource> Sources;
    private int playingSound = -1;
    private int nextSound = -1;
    private float playingVolume = 1f;

    private bool fade = false;
    private bool fadeIn = true;

    public void Play(int index)
    {
        Sources[index].Play();
    }

    public void PlayFade(int index, float volume = 1f)
    {
        if (playingSound == -1)
        {
            playingSound = index;
            fadeIn = true;
            fade = true;

            playingVolume = volume;
            Sources[playingSound].volume = 0f;
            Sources[playingSound].Play();
        }
        else
        {
            fadeIn = false;
            playingVolume = volume;
            nextSound = index;
            fade = true;
        }
    }

    void FixedUpdate()
    {
        if (fade)
        {
            if (fadeIn)
            {
                Sources[playingSound].volume = Mathf.Lerp(Sources[playingSound].volume, 0.3f, Time.fixedDeltaTime * 4);

                if (Sources[playingSound].volume == playingVolume)
                    fade = false;
            }
            else
            {
                Sources[playingSound].volume = Mathf.Lerp(Sources[playingSound].volume, 0f, Time.fixedDeltaTime * 4);

                if (Sources[playingSound].volume < 0.001f)
                {
                    Sources[playingSound].Stop();
                    playingSound = nextSound;

                    playingVolume = Sources[playingSound].volume;
                    Sources[playingSound].volume = 0f;
                    Sources[playingSound].Play();

                    fadeIn = true;
                }
            }
        }
    }
}
