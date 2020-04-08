using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAudioContorller : MonoBehaviour, IPointerEnterHandler
{

    public AudioClip click_sound, hover_sound;
    public AudioSource audio_source;

    // Start is called before the first frame update
    void Start()
    {
        audio_source = GetComponent<AudioSource>();
    }

    public void PlayHoverSound()
    {
        audio_source.PlayOneShot(hover_sound);
    }

    public void PlayClickSound()
    {
        audio_source.PlayOneShot(click_sound);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayHoverSound();
    }
}
