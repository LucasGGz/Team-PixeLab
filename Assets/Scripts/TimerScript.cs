using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    public GeneradorEnemigos generador;
    public float timer = 0;

    public Text textoTimer;


    void Start()
    {
        
    }
    void Update()
    {
        timer = generador.tiempoRestante;
        
        if (timer >= 0)
        {
            textoTimer.text = "" + timer.ToString("f0");
        }
        else
        {
            textoTimer.text = "--" ;
        }
    }

}
