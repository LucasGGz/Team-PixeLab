using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvTrigo : MonoBehaviour
{
   [SerializeField]
    private GameObject trigo;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InvocarTrigo",0,5);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void InvocarTrigo()
    {
        Instantiate(trigo, transform.position, transform.rotation);
    }
}
