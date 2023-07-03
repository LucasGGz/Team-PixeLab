using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvHierro : MonoBehaviour
{
   [SerializeField]
    private GameObject Hierro;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InvocarHierro",0,3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void InvocarHierro()
    {
        Instantiate(Hierro, transform.position, transform.rotation);
    }
}
