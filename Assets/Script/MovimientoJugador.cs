using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimietoJugador : MonoBehaviour
{
    private float speed;
    private float speedRotation;
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        speed = 6f;
        speedRotation = 1000f;
    }
    void Update()
    {
        float posX = Input.GetAxis("Horizontal");
        float posZ = Input.GetAxis("Vertical");
        float rotationY = Input.GetAxis("Mouse X");
        transform.Translate(new Vector3(posX, 0f, posZ) * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0f, rotationY, 0f) * speedRotation * Time.deltaTime);
    }

    
}
