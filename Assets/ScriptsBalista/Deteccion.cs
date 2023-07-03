using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccion : MonoBehaviour
{
    public float rangoAlerta;
    public float rangoAlerta2;
    public LayerMask capaEnemigo;
    public bool estarAlerta;
    public Transform Enemigo;
    private GameObject objetivoDetectado;
    public BalistaBehaviour balistaBehaviour;
    //private bool estaDetectando = false;
    private bool one;
    //private Transform puntoMedio;
    private Vector3 mirar;
    private float ejeY=1.5F;
    void Start()
    {
        one = true;
    }

    void Update()
    {
        mirar = new Vector3(0, ejeY, 0);
        estarAlerta = Physics.CheckSphere(transform.position, rangoAlerta2, capaEnemigo);
        if (estarAlerta)
        {
            disparo();
            oneShoot();
        }
        else
        {
            objetivoDetectado = null; // Reiniciar el objetivo detectado cuando no hay enemigos en el rango de alerta
            one = true; // Permitir un nuevo disparo cuando se detecte un enemigo nuevamente
        }
    }

    public void disparo()
    {
        if (objetivoDetectado == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, rangoAlerta, capaEnemigo);
            if (colliders.Length > 0)
            {
                objetivoDetectado = colliders[0].gameObject;
            }
        }
        else
        {
            OrientarHaciaObjetivo();
        }
    }

    private void OrientarHaciaObjetivo()
    {
        if (objetivoDetectado != null)
        {
            transform.LookAt(objetivoDetectado.transform.position + mirar);
        }
    }

    private void oneShoot()
    {
        if (one)
        {
            balistaBehaviour.disparoDeteccion();
            one = false;
        }
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta2);
    }
}

/*{
    public float rangoAlerta;
    public float rangoAlerta2;
    public LayerMask capaEnemigo;
    public bool estarAlerta;
    public Transform Enemigo;
    private GameObject objetivoDetectado;
    public BalistaBehaviour balistaBehaviour;
    private bool estaDetectando = false;
    private bool one;
    void Start()
    {
        one = true;

    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoAlerta2, capaEnemigo);
        if (estarAlerta)
        {
            disparo();
            oneShoot();
        }
        Debug.Log(estarAlerta);

    }

    public void disparo()
    {
       

        if (objetivoDetectado == null)
        {
          // Detectar los GameObjects en el área de detección
            Collider[] colliders = Physics.OverlapSphere(transform.position, rangoAlerta, capaEnemigo);
            Debug.Log(colliders);
            // Verificar si se detectó algún GameObject
            if (colliders.Length > 0)
            {

                // Obtener el primer GameObject detectado
                objetivoDetectado = colliders[0].gameObject;
                // Realizar acciones con el GameObject detectado
                /*  if (estarAlerta)
                  {
                      balistaBehaviour.disparoDeteccion();
                  }

               
                
            }
        }
        else
        {
            // Orientar la torreta hacia el objetivo detectado
            OrientarHaciaObjetivo();
           // Debug.Log(objetivoDetectado);
        }

    }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, rangoAlerta);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta2);
    }

    private void OrientarHaciaObjetivo()
    {
        if (objetivoDetectado != null)
        {
            transform.LookAt(objetivoDetectado.transform);
        }
    }

    private void oneShoot()
    {
        if (one)
        {
            balistaBehaviour.disparoDeteccion();
            one = false;
        }
    }


}*/

//balistaBehaviour.disparoDeteccion();