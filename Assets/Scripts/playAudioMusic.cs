using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioMusic : MonoBehaviour
{
    public AudioSource audioSource;
    private void Awake()
    {
        audioSource.Play();
        audioSource.volume = 0.3f;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
