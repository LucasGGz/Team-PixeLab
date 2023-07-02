using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingeniero : MonoBehaviour
{
    public Inventario inventario;
    public int limiteBallestas = 6;
    public int costoMadera = 10;
    public int costoPiedra = 6;
    public int costoHierro = 5;


    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entraste a la zona del ingeniero.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && PuedeComprarBallesta())
            {
                ComprarBallesta();
            }
        }
    }

    bool PuedeComprarBallesta()
    {
        return inventario.cantBallestas + inventario.BallestasDes < limiteBallestas && inventario.cantHierro >= costoHierro && inventario.cantPiedra >= costoPiedra && inventario.cantMadera >= costoMadera;
    }

    void ComprarBallesta()
    {
        inventario.cantBallestas++;
        inventario.cantHierro -= costoHierro;
        inventario.cantPiedra -= costoPiedra;
        inventario.cantMadera -= costoMadera;
        Debug.Log("Has comprado una ballesta.");
    }
}