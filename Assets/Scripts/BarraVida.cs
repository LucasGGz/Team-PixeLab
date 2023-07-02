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
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarBarra();
    }
    public void ActualizarBarra()
    {
        imgBarraVida.fillAmount = vidaActual / vidaMax; //se hace una division porque el mayor valor de fillAmount es 1
    }
}
