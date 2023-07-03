using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaAliado : MonoBehaviour
{
    public GameObject arma;

    public BoxCollider armaBoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        
        DesactivarColliderArmas();//se desactivan los boxColliders del puño y de la espada
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DesactivarColliderArmas()
    {
        if (armaBoxCollider != null)
        {
            armaBoxCollider.enabled = false;
        }
        //punioBoxCollider.enabled = false;
    }

    //Activa los colliders del puño y de la espada
    public void ActivarColliderArmas()
    {
        if (armaBoxCollider != null)
            {
                armaBoxCollider.enabled = true;
            }
        

    }
}
