using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvMadera : MonoBehaviour
{
    [SerializeField]
    private GameObject Madera;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InvocarMadera",0,5);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void InvocarMadera()
    {
        Instantiate(Madera, transform.position, transform.rotation);
    }
}
