using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public int vidaMax;
    public float vidaActual;
    public Image imgBarraVida;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarBarra();
        //if (vidaActual <= 0)
        //{
        //    gameObject.SetActive(false);
        //}
    }
    public void ActualizarBarra()
    {
        imgBarraVida.fillAmount = vidaActual / vidaMax; //se hace una division porque el mayor valor de fillAmount es 1
    }
}
