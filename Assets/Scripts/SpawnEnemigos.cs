using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject enemigoInst;
    public TimerScript timer;
    public bool estadoOrda;
    public float tiempoOrda1;
    public float tiempoOrda2;
    public float tiempoOrda3;


    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<TimerScript>();
        tiempoOrda2 = timer.timerHorda2;
        tiempoOrda3 = timer.timerHorda3;
        
    }

    // Update is called once per frame
    void Update()
    {
        seleccionarOrda();
    }
    public void seleccionarOrda(){

        switch(timer.orda) {
    case 1:
        Instantiate(enemigoInst,transform.position,transform.rotation);
            Debug.Log("la orda" + timer.orda  +"se invoco");
         break;
    case 2:
            Debug.Log("la orda" + timer.orda  +"se invoco");
         break;
    case 3:
            Debug.Log("la orda" + timer.orda  +"se invoco");
         break;
        default:
        Debug.Log("Fin de las Hordas");
        break;
        }
    }
}
