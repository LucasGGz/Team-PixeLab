using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class navMeshControler : MonoBehaviour
{
    public Transform objetivo;
    private bool enBatalla;
    private NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        objetivo = GameObject.Find("Objetivo").GetComponent<Transform>();
        agente = GetComponent<NavMeshAgent>();
        //StartCoroutine(MarchaAtaque());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            enBatalla = true;
        }else{
            enBatalla = false; 
        }
        verificarAccion();
    }
    public void verificarAccion(){
        if(enBatalla){
            atacar();
        }else if(!enBatalla){
            marchar();
        }
    }
 
    public void atacar(){
        Debug.Log("Introduzca bloque de codigo de ataque y batalla");
        agente.destination = transform.position;
    }
    public void marchar(){
        if(!enBatalla){
            agente.destination = objetivo.position;
        }
    }
    public void perdida(){
        if((transform.position == objetivo.position)){
            Debug.Log("Perdio");
            // en realida aqui va un ontrigerenter
        }
    }
}
