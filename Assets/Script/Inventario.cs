using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
   
   public int cantTrigo = 0;
   public int cantMadera = 0;
   public int cantHierro = 0;
   public int cantPiedra = 0;
   public int cantBallestas = 0;
   public int BallestasDes = 0;
   public int cantMejora = 0;
   public int cantPan = 0;
   public int mRealizada = 0;
   public Text Trigo;
   public Text Madera;
   public Text Hierro;
   public Text Piedra;
   public Text Ballesta;
   public Text BallestasDesplegadas;
   public Text Mejora;
   public Text Pan;
   public Text MejoraRealizada;
void Update(){
   Trigo.text = "" + cantTrigo.ToString() + " Trigo";
   Madera.text = "" + cantMadera.ToString() + " Madera";
   Hierro.text = "" + cantHierro.ToString() + " Hierro";
   Piedra.text = "" + cantPiedra.ToString()+ " Piedra";
   Ballesta.text = "" + cantBallestas.ToString() + " Ballestas";
   Mejora.text = "" + cantMejora.ToString() + " Mejoras disponibles";
   Pan.text = "" + cantPan.ToString() + " Pan";
   MejoraRealizada.text = "" + mRealizada.ToString()+ " Mejoras realizadas";
   BallestasDesplegadas.text = "" + BallestasDes.ToString()+ " Ballestas Desplegadas ";
}
}
