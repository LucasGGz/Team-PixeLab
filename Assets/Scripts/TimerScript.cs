using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timerHorda1 = 0;
    public float timerHorda2 = 0;
    public float timerHorda3 = 0;
    public float orda = 0;
    public float timer = 0;

    public Text textoTimer;


    void Start(){
        orda = 1;
    }
    void Update()
    {
        contar();
    }   
    public void contar(){
        switch(orda) {
    case 1:
        timerHorda1 -= Time.deltaTime;
        timer = timerHorda1;
        textoTimer.text = "" + timer.ToString("f0");
        if(timerHorda1<0){
            textoTimer.text ="--";
           // Debug.Log("la orda" + orda  +"se invoco");
            orda = 2;
            timer = 0;
        }
         break;
    case 2:
        timerHorda2 -= Time.deltaTime;
        timer = timerHorda2;
        textoTimer.text = "" + timer.ToString("f0");
        if(timerHorda2<0){
            textoTimer.text ="--";
            //Debug.Log("la orda" + orda  +"se invoco");
            orda = 3;
            timer = 0;
        }
         break;
    case 3:
        timerHorda3 -= Time.deltaTime;
        timer = timerHorda3;
        textoTimer.text = "" + timer.ToString("f0");
        if(timerHorda3<0){
            textoTimer.text ="--";
            //Debug.Log("la orda" + orda  +"se invoco");
            orda = 4;
            timer = 0;
        }
         break;
        default:
        Debug.Log("Fin de las Hordas");
        break;
        }
    }
}
