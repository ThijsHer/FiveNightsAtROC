using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam8audio : MonoBehaviour
{
    public GameObject cam8; // Reference to your cam8 GameObject
    public AudioClip audioClip; // Audio clip reference

    private AudioSource audioSource; // Audio source component reference

    private void Start()
    {
        // Ensure that cam8 is assigned
        if (cam8 == null)
        {
            Debug.LogError("Please assign the cam8 GameObject in the inspector.");
            return;
        }

        // Get or add the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the loaded audio clip to the AudioSource component
        audioSource.clip = audioClip;

        // Disable play on awake to handle audio manually
        audioSource.playOnAwake = false;

        // Set initial volume to 0
        audioSource.volume = 0f;

        // If you want the audio to loop, you can uncomment the line below
        // audioSource.loop = true;

        // Play the audio if cam8 is initially active
        if (cam8.activeSelf)
        {
            audioSource.Play();
        }
    }

    private void Update()
    {
        // Check if cam8 is active
        if (cam8.activeSelf)
        {
            // Ensure the volume is set to 1
            audioSource.volume = 0.7f;

            // If audio is not playing, start playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Ensure the volume is set to 0
            audioSource.volume = 0f;
        }
    }
}