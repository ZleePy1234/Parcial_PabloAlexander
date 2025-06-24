using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip[] audioClips = new AudioClip[3]; // Array to hold audio clips
    private AudioSource audioSource; // AudioSource component to play sounds
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayExplosion()
    {
        audioSource.PlayOneShot(audioClips[0]);
    }
    public void PlayFire()
    {
        audioSource.PlayOneShot(audioClips[1]);
    }

    public void PlayDamage()
    {
        audioSource.PlayOneShot(audioClips[2], 10f);
    }
}
