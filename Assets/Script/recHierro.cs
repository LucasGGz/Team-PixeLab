using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recHierro : MonoBehaviour
{
    public Inventario inventario;
    // Start is called before the first frame update
    void Start()
    {
        inventario= GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }
 private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        Debug.Log("Detecto la colision");
        inventario.cantHierro = inventario.cantHierro + 1;
        Destroy(gameObject);
        }
    }
}
