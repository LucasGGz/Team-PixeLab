using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioMusic : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        audioSource.Play();
        audioSource.volume = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
