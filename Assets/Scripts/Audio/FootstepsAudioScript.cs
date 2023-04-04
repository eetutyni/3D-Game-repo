using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudioScript : MonoBehaviour
{
    [SerializeField] private AudioClip walkAudio;
    [SerializeField] private AudioClip runAudio;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWalkAudio()
    {
        if (audioSource.clip != walkAudio)
        {
            audioSource.clip = walkAudio;
        }
        audioSource.Play();
    }

    public void PlayRunAudio()
    {
        if (audioSource.clip != runAudio)
        {
            audioSource.clip = runAudio;
        }
        audioSource.Play();
    }
}
