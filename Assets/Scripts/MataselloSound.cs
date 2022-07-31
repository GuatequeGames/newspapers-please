using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MataselloSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip audioPaper;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Paper()
    {
        audioSource.PlayOneShot(audioPaper, 1);
    }

}
