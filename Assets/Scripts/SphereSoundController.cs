using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSoundController : MonoBehaviour
{
    public AudioClip point_sound, bounce_sound;
    public AudioSource audio_source;

    // Start is called before the first frame update
    void Start()
    {
        this.audio_source = GetComponent<AudioSource>();
    }

    public void PlayPointSound()
    {
        this.audio_source.pitch = 1f;
        this.audio_source.PlayOneShot(point_sound);
    }

    public void PlayBounceSound()
    {
        this.audio_source.pitch = 3f;
        this.audio_source.PlayOneShot(point_sound);
    }
}
