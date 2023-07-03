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
    private SoundManager soundManager;
    private bool puedeComprar = true; 
    private float tiempoUltimaCompra;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

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
            if (Input.GetKeyDown(KeyCode.F) && puedeComprar && PuedeComprarBallesta())
            {
                soundManager.SeleccionAudio(5, 0.5f);
                ComprarBallesta();
                StartCoroutine(EsperarTiempoCompra());
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
        puedeComprar = false; 
        tiempoUltimaCompra = Time.time; 
    }

    IEnumerator EsperarTiempoCompra()
    {
        yield return new WaitForSeconds(3f);

        puedeComprar = true;
    }
}
