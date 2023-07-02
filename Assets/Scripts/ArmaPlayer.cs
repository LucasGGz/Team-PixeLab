using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaPlayer : MonoBehaviour
{
    public GameObject arma;
    private ThirdPersonMovement playerScript;
    private bool tengoArma;
    private bool armaEquipada;
    private Animator animator;

    public BoxCollider arma1BoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponent<ThirdPersonMovement>();
        animator = GetComponent<Animator>();
        DesactivarColliderArmas();//se desactivan los boxColliders del puño y de la espada
        tengoArma = true;      //al iniciar la escena el player no tiene un arma
        armaEquipada = false;   //por lo tanto tampoco la tendria equipada
    }

    // Update is called once per frame
    void Update()
    {
        //este if sirve para equiparse y desaquiparse el arma cuando se apreta la tecla especificada
        if (tengoArma && Input.GetKeyDown(KeyCode.K)) //también como condición tiene que antes se tendria que haber agarrado un arma
        {
            if (armaEquipada)       //evalúa si tiene o no equipada el arma
            {
                DesactivarArma();
            }
            else
            {
                ActivateArma();
            }
        }
    }
    public void DesactivarColliderArmas()
    {
        if (arma1BoxCollider != null)
        {
            arma1BoxCollider.enabled = false;
        }
        //punioBoxCollider.enabled = false;
    }

    //Activa los colliders del puño y de la espada
    public void ActivarColliderArmas()
    {
        if (playerScript.conArma)
        {
            if (arma1BoxCollider != null)
            {
                arma1BoxCollider.enabled = true;
            }
        }
        //else
        //{
        //    punioBoxCollider.enabled = true;
        //}

    }

    public void ActivateArma()
    {
        tengoArma = true;
        arma.SetActive(true);   //activa el arma del player
        armaEquipada = true;
        animator.SetBool("armaEquipada", true);
        playerScript.speed = 4f;     //disminuye la velocidad del player para aparentar que el arma es pesada y le cuesta moverse
        playerScript.conArma = true; //cambia el estado de una variable correspondiente al Script PlayerBehaviour
    }

    public void DesactivarArma()
    {
        arma.SetActive(false);              //desactiva el arma del player
        armaEquipada = false;
        animator.SetBool("armaEquipada", false);
        playerScript.speed = 6f;         //aumenta la velocidad del player
        playerScript.conArma = false;
    }
}
