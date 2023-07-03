using System.Collections;
using UnityEngine;

public class Herrero : MonoBehaviour
{
    public int limiteMejoras = 5;
    public float tiempoEspera = 3f;
    public float incrementoCosto = 1.5f;

    private Inventario inventario;
    private int costoHierro = 3;
    private int costoPiedra = 4;
    private int costoMadera = 6;
    private bool puedeComprar = true; 
    private float tiempoUltimaCompra;
    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && puedeComprar && PuedeComprarMejora())
            {
                soundManager.SeleccionAudio(5, 0.5f);
                ComprarMejora();
                StartCoroutine(EsperarTiempoCompra());
            }
        }
    }

    bool PuedeComprarMejora()
    {
        return inventario.cantMejora + inventario.mRealizada < limiteMejoras && inventario.cantHierro >= costoHierro && inventario.cantPiedra >= costoPiedra && inventario.cantMadera >= costoMadera;
    }

    void ComprarMejora()
    {
        inventario.cantHierro -= costoHierro;
        inventario.cantPiedra -= costoPiedra;
        inventario.cantMadera -= costoMadera;
        inventario.cantMejora++;
        costoHierro = Mathf.RoundToInt(costoHierro * incrementoCosto);
        costoPiedra = Mathf.RoundToInt(costoPiedra * incrementoCosto);
        costoMadera = Mathf.RoundToInt(costoMadera * incrementoCosto);

        Debug.Log("Has comprado una mejora para armas.");
        puedeComprar = false;
        tiempoUltimaCompra = Time.time;
    }

    IEnumerator EsperarTiempoCompra()
    {
        yield return new WaitForSeconds(tiempoEspera);

        puedeComprar = true; // Activar la posibilidad de comprar nuevamente
    }
}
