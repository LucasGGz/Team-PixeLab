using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.InputSystem;

public class Aliado : MonoBehaviour
{
    public Transform playerFollow;
    public float stopDistance;
    public float speedAliado;
    public Animator animacionA;
    private Vector3 correr = Vector3.zero;

    private bool enemigoDetectado;
    public float stopDistanceEnemy;
    public float rangoDeteccion = 5.0f;
    //private float distanceEnemy;
    private Vector3 direccionEnemy = Vector3.zero;
    //public float velocidadMovimiento = 5.0f;

    private GameObject objetivo;

    public ThirdPersonMovement playerScript;

    public int hpAliado;
    public int danioEnemigo;
    public BarraVida barraVida;
    //public int danio;

    private bool muerto;
    private SoundManager soundManager;
    // Start is called before the first frame update

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Start()
    {
        animacionA = GetComponent<Animator>();
        muerto = false;
        barraVida.vidaMax = hpAliado;               //asigna el hp del player a una variable del script BarraVidaBehaviour
        barraVida.vidaActual = hpAliado;
    }

    // Update is called once per frame
    void Update()
    {
        if (!muerto)
        {
            if (!enemigoDetectado && playerScript.aliadoSeguir)
            {
                seguirPlayer();
            }

            if (!playerScript.aliadoSeguir)
            {
                correr = Vector3.zero;
            }

            buscarEnemigos();
            animacionA.SetFloat("AliadoWalkVelocity", correr.magnitude * speedAliado);
        }
        
       
    }

    public void seguirPlayer()
    {
        if (playerFollow != null)
        {
            // Calcula la distancia entre los dos objetos
            float distance = Vector3.Distance(transform.position, playerFollow.position);

            // Si la distancia es mayor que la distancia m�nima, mueve el objeto hacia el objeto a seguir
            if (distance > stopDistance)
            {
                Vector3 direccion = (playerFollow.position - transform.position).normalized;
                transform.position += direccion * speedAliado * Time.deltaTime;
                correr = direccion;
                // Calcula la rotaci�n sin la rotaci�n en el eje X
                Quaternion targetRotation = Quaternion.LookRotation(direccion);
                targetRotation.eulerAngles = new Vector3(0, targetRotation.eulerAngles.y, 0);

                // Aplica la rotaci�n al objeto
                transform.rotation = targetRotation;
            }
            else
            {
                correr = Vector3.zero;
            }
            //animacionA.SetFloat("AliadoWalkVelocity", correr.magnitude * speedAliado);
            // Haz que el objeto que sigue mire hacia el objeto perseguido
            //transform.LookAt(playerFollow);
        }
    }

    public void atacarEnemigo()
    {
        animacionA.SetTrigger("atacar");
    }

    public void buscarEnemigos()
    {
        // Si ya hay un objetivo, perseguirlo y atacarlo
        if (objetivo != null)
        {
            // Calcula la distancia entre los dos objetos
            float distanceEnemy = Vector3.Distance(transform.position, objetivo.transform.position);
            if (distanceEnemy > stopDistanceEnemy) 
            {
                direccionEnemy = (objetivo.transform.position - transform.position).normalized;
                transform.position += direccionEnemy * speedAliado * Time.deltaTime;
                correr = direccionEnemy;
                
            }
            else
            {
                correr = Vector3.zero;
                animacionA.SetTrigger("atacar");
                //atacarEnemigo();
            }
            transform.LookAt(objetivo.transform);
            /*/ Calcula la rotaci�n sin la rotaci�n en el eje X
            Quaternion targetRotation = Quaternion.LookRotation(direccionEnemy);
            targetRotation.eulerAngles = new Vector3(0, targetRotation.eulerAngles.y, 0);

            // Aplica la rotaci�n al objeto
            transform.rotation = targetRotation;*/
            //animacionA.SetFloat("AliadoWalkVelocity", correr.magnitude * speedAliado);

            // Aqu� puedes a�adir tu l�gica de ataque al objetivo
            // ...

            return; // Salir de la funci�n para evitar la detecci�n de nuevos objetivos
        }
        // Buscar los objetos con el tag "Enemy" dentro del rango de detecci�n
        Collider[] colliders = Physics.OverlapSphere(transform.position, rangoDeteccion);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemigo"))
            {
                enemigoDetectado = true;
                // Establecer el primer objeto con el tag "Enemy" como objetivo
                objetivo = collider.gameObject;
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
        if (!muerto)
        {
            if (other.gameObject.tag == "ataqueEnemy")
            {
                hpAliado -= danioEnemigo;//disminuye el hp del player
                barraVida.vidaActual = hpAliado;//se asigna el hp Actual a una variable del script BarraVidaBehaviour
            }
            if (hpAliado <= 0)
            {
                animacionA.SetTrigger("muerto");//esta animación se llama al cambiar la variable de tipo Trigger "estoyMuerto" que esta en el animator del Player
                muerto = true;          //cambia el estado de muerto a true
            }
        }
        /*if (other.gameObject.tag == "Finish")
        {
            hpPlayer -= danio;//disminuye el hp del player
            barraVida.vidaActual = hpPlayer;//se asigna el hp Actual a una variable del script BarraVidaBehaviour
            if (!muerto)
            {
                transform.position = new Vector3(62f, 62f, 42f);//mueve al player a una posicion
            }

        }*/

    }
    public void DestruirAliado()
    {
        Destroy(gameObject);
    }

    public void ataqueAliado()
    {
        soundManager.SeleccionAudio(14, 0.6f);
    }
    public void muerteAliado()
    {
        soundManager.SeleccionAudio(15, 0.6f);
    }
}
