using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetivoBeahaviour : MonoBehaviour
{
    public bool perdio;
    // Start is called before the first frame update
    void Start()
    {
        perdio = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Enemigo")
            {
                perdio = true;
            }
    }
}
