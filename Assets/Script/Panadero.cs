using UnityEngine;

public class Panadero : MonoBehaviour
{
    public int costoPan = 20;

    private Inventario inventario;
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
            if (Input.GetKey(KeyCode.F) && PuedeComprarPan())
            {
                ComprarPan();
                soundManager.SeleccionAudio(5, 0.5f);
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
