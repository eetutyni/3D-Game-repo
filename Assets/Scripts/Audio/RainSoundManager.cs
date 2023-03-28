using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Audio;

public class RainSoundManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private LayerMask shelterLayer;

    [SerializeField] private AudioMixerGroup mainGroup;
    [SerializeField] private AudioMixerGroup shelterGroup;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(playerTransform.position, playerTransform.up, 3f, shelterLayer)) audioSource.outputAudioMixerGroup = shelterGroup;
        else audioSource.outputAudioMixerGroup = mainGroup;
    }
}
