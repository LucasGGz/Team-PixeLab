using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pantallaPerdidaDerrota : MonoBehaviour
{
    public Text textoVictoriaDerrota;
    public ThirdPersonMovement script;
    public LayerMask targetLayer;
    public objetivoBeahaviour objetivoScript;
    
    //public bool muerteJugador;

    void Start()
    {

        DesactivarElemento();

    }
    void Update()
    {
        //muerteJugador = script.muerto;
        int elementCount = CountElementsInLayer();
        if(script.muerto||objetivoScript.perdio){
            ActivarElemento();
            textoVictoriaDerrota.text = "PERDISTE";
        }else if(elementCount<1&&script.muerto){
            ActivarElemento();
            textoVictoriaDerrota.text = "VICTORIA";
        }else{
            textoVictoriaDerrota.text = "  ";
        }
    }

    void DesactivarElemento()
    {
        textoVictoriaDerrota.gameObject.SetActive(false);
    }

    void ActivarElemento()
    {
        textoVictoriaDerrota.gameObject.SetActive(true);
    }


    int CountElementsInLayer()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        int count = 0;

        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == targetLayer)
            {
                count++;
            }
        }
        return count;
    }
    
}