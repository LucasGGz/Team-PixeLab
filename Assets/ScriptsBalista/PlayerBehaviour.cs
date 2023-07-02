using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float speed;
    private float speedRotation;
    private float jumpForce;
    private Rigidbody physicBody;
    [SerializeField]
    private GameObject Ballesta;

    public Transform puntoCentral;
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        speed = 6f;
        speedRotation = 300f;
        jumpForce = 6f;
        physicBody = GetComponent<Rigidbody>();
       // Vector3 hi = new Vector3(transform.position.x+2.0f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento y Rotacion
        float posX = Input.GetAxis("Horizontal");
        float posZ = Input.GetAxis("Vertical");
        float rotationY = Input.GetAxis("Mouse X");

        transform.Translate(new Vector3(posX, 0f, posZ) * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0f, rotationY, 0f) * speedRotation * Time.deltaTime);

        //SALTO
        if (Input.GetKeyDown(KeyCode.Space))
        {
            physicBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(Ballesta, puntoCentral.transform.position, puntoCentral.transform.rotation);
        }


    }

    
}
