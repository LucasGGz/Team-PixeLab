using UnityEngine;

public class Panadero : MonoBehaviour
{
    public int costoPan = 20;

    private Inventario inventario;

    private void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.F) && PuedeComprarPan())
            {
                ComprarPan();
            }
        }
    }

    bool PuedeComprarPan()
    {
        return inventario.cantTrigo >= costoPan;
    }

    void ComprarPan()
    {
        inventario.cantTrigo -= costoPan;
        inventario.cantPan++;
        Debug.Log("Has comprado un pan.");
    }
}
