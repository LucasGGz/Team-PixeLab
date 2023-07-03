using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class navMeshControler : MonoBehaviour
{
    public Transform objetivo;
    private bool enBatalla;
    private NavMeshAgent agente;

    //<<<<Variables para atacar a los que tengan tag Player
    public Animator animacionE;
    private Vector3 correr = Vector3.zero;

    private bool enemigoDetectado;
    public float stopDistanceEnemy;
    public float rangoDeteccion = 5.0f;
    //private float distanceEnemy;
    private Vector3 direccionEnemy = Vector3.zero;
    //public float velocidadMovimiento = 5.0f;
    private float speedEnemy;

    private GameObject objeto;

    public GameObject arma;
    public BoxCollider armaCollider;
    // Start is called before the first frame update
    void Start()
    {
        objetivo = GameObject.Find("Objetivo").GetComponent<Transform>();
        agente = GetComponent<NavMeshAgent>();
        animacionE = GetComponent<Animator>();

        //StartCoroutine(MarchaAtaque());
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemigoDetectado)
        {
            marchar();
        }

        buscarPlayer();
        
        animacionE.SetFloat("walkVelocity", agente.speed);
        /*if (Input.GetKey("space"))
        {
            enBatalla = true;
        }else{
            enBatalla = false; 
        }
        verificarAccion();*/
    }
    public void verificarAccion(){
        if(enBatalla){
            //atacar();
        }else if(!enBatalla){
            marchar();
        }
    }
 
    public void atacar(){
        Debug.Log("Introduzca bloque de codigo de ataque y batalla");
        agente.destination = transform.position;
    }
    public void marchar(){
        //if(!enBatalla){
            agente.destination = objetivo.position;
        //}
    }
    public void perdida(){
        if((transform.position == objetivo.position)){
            Debug.Log("Perdio");
            // en realida aqui va un ontrigerenter
        }
    }
    public void buscarPlayer()
    {
        // Si ya hay un objetivo, perseguirlo y atacarlo
        if (objeto != null)
        {
            // Calcula la distancia entre los dos objetos
            float distanceEnemy = Vector3.Distance(transform.position, objeto.transform.position);
            if (distanceEnemy > stopDistanceEnemy)
            {
                agente.destination = objeto.transform.position;
                //direccionEnemy = (objeto.transform.position - transform.position).normalized;
                //transform.position += direccionEnemy * speedEnemy * Time.deltaTime;
                //correr = direccionEnemy;

            }
            else
            {
                agente.destination = transform.position;
                //correr = Vector3.zero;
                animacionE.SetTrigger("attack");
                //atacarEnemigo();
            }
            transform.LookAt(objeto.transform);

            return; // Salir de la funci�n para evitar la detecci�n de nuevos objetivos
        }
        // Buscar los objetos con el tag "Enemy" dentro del rango de detecci�n
        Collider[] colliders = Physics.OverlapSphere(transform.position, rangoDeteccion);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player") || collider.CompareTag("aliado"))
            {
                enemigoDetectado = true;
                // Establecer el primer objeto con el tag "Player" como objetivo
                objeto = collider.gameObject;
                break;
            }
            else
            {
                enemigoDetectado = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "armaImpacto")
        {
            //animacionE.SetBool("muerto", true); 
            animacionE.SetTrigger("dead");
        }
    }

    public void DestruirEnemigo()
    {
        Destroy(gameObject);
    }

    public void DesactivarColliderArmas()
    {
        if (armaCollider != null)
        {
            armaCollider.enabled = false;
        }
        //punioBoxCollider.enabled = false;
    }

    //Activa los colliders del puño y de la espada
    public void ActivarColliderArmas()
    {
        
         if (armaCollider != null)
            {
                armaCollider.enabled = true;
            }
        //else
        //{
        //    punioBoxCollider.enabled = true;
        //}

    }
}
