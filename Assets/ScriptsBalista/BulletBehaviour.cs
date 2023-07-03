using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        Destroy(this.gameObject, 20f);
    }

     /*private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "Enemigo")
         {
             Destroy(collision.gameObject);
             Debug.Log("Eliminar");
         }
     }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            Destroy(other.gameObject);
            Debug.Log("Eliminar");
        }
    }

}
