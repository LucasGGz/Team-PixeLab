using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvPiedra : MonoBehaviour
{
[SerializeField]
    private GameObject Piedra;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InvocarPiedra",0,2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void InvocarPiedra()
    {
        Instantiate(Piedra, transform.position, transform.rotation);
    }
}
