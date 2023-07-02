using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //esto hace que el frente(forward) del canvas de los enemigos coincida con el frente de la cámara
        transform.forward = Camera.main.transform.forward;
    }
}
