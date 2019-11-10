using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAudio : MonoBehaviour
{
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(0.6f, 1.2f);
    }
}
