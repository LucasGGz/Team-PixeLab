using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public int cantidadEnemigosHorda1 = 10;
    public int cantidadEnemigosHorda2 = 15;
    public int cantidadEnemigosHorda3 = 20;
    public float tiempoHorda1 = 10f;
    public float tiempoHorda2 = 10f;
    public float tiempoHorda3 = 10f;

    public float tiempoRestante;
    // Start is called before the first frame update
    void Start()
    {
        tiempoRestante = tiempoHorda1;
        Invoke("GenerarHorda1", tiempoRestante);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRestante -= Time.deltaTime;

        //if (tiempoRestante > 0)
        //{
        //    Debug.Log("Tiempo restante para la siguiente horda: " + Mathf.Ceil(tiempoRestante));
        //}
    }

    private void GenerarHorda1()
    {
        for (int i = 0; i < cantidadEnemigosHorda1; i++)
        {
            Instantiate(enemigoPrefab, transform.position, Quaternion.identity);
        }

        tiempoRestante = tiempoHorda2;
        Invoke("GenerarHorda2", tiempoRestante);
    }

    private void GenerarHorda2()
    {
        for (int i = 0; i < cantidadEnemigosHorda2; i++)
        {
            Instantiate(enemigoPrefab, transform.position, Quaternion.identity);
        }

        tiempoRestante = tiempoHorda3;
        Invoke("GenerarHorda3", tiempoRestante);
    }

    private void GenerarHorda3()
    {
        for (int i = 0; i < cantidadEnemigosHorda3; i++)
        {
            Instantiate(enemigoPrefab, transform.position, Quaternion.identity);
        }
    }
}
