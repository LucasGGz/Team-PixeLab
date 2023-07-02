using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaBalista : MonoBehaviour
{
    public int damage;
    public int vidaBalista;
    public Slider barravidaBalista;

     void Update()
    {
        barravidaBalista.value = vidaBalista;

        /*  if (Input.GetKeyDown(KeyCode.E))
          {
              vidaBalista -= damage;
          }
          if (vidaBalista==0)
          {
              Destroy(this.gameObject);
          }*/
        if (vidaBalista == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            vidaBalista -= damage;
            Debug.Log("Hubo");
            
        }
        
    }
}
