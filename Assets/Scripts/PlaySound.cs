using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour {

    public List<AudioSource> Sources;

    public void Play(int index)
    {
        Sources[index].Play();
    }
}
