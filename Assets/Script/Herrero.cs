using System.Collections;
using UnityEngine;

public class Herrero : MonoBehaviour
{
    public int limiteMejoras = 5;
    public float tiempoEspera = 5f;
    public float incrementoCosto = 1.5f;

    private Inventario inventario;
   // private int cantMejoras = 0;
    private int costoHierro = 3;
    private int costoPiedra = 4;
    private int costoMadera = 6;
    private bool esperandoCompra = false;

    private void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && !esperandoCompra && PuedeComprarMejora())
            {
                ComprarMejora();
            }
        }
    }

    bool PuedeComprarMejora()
    {
        return inventario.cantMejora + inventario.mRealizada < limiteMejoras && inventario.cantHierro >= costoHierro && inventario.cantPiedra >= costoPiedra && inventario.cantMadera >= costoMadera;
    }

    void ComprarMejora()
    {
        esperandoCompra = true;

        StartCoroutine(EsperarTiempo());

        inventario.cantHierro -= costoHierro;
        inventario.cantPiedra -= costoPiedra;
        inventario.cantMadera -= costoMadera;
        inventario.cantMejora++;
        costoHierro = Mathf.RoundToInt(costoHierro * incrementoCosto);
        costoPiedra = Mathf.RoundToInt(costoPiedra * incrementoCosto);
        costoMadera = Mathf.RoundToInt(costoMadera * incrementoCosto);

        Debug.Log("Has comprado una mejora para armas.");

    }

    IEnumerator EsperarTiempo()
    {
        yield return new WaitForSeconds(tiempoEspera);
        esperandoCompra = false;
    }
}
