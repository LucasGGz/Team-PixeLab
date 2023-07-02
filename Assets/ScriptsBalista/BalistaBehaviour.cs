using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalistaBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject bala;
    [SerializeField]
    private float initTime;
    [SerializeField]
    public float RepeatTime;
    public Deteccion deteccion;
    private float randomTime = 0;
    void Start()
    {
        //InvokeRepeating("DisparoBala",initTime,RepeatTime);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void disparoDeteccion()
    {

        Invoke("DisparoBala", randomTime);
        /*  if (deteccion.estarAlerta)
          {
             // InvokeRepeating("DisparoBala", initTime, RepeatTime);

              /*   Invoke("DisparoBala", randomTime);
                 randomTime = Random.Range(1, 3);
          }

           Debug.Log("disparando");*/
    }
    
    public void DisparoBala()
    {
        
        Instantiate(bala, transform.position, transform.rotation);
        //  Debug.Log("bala");
        if (deteccion.estarAlerta)
        {
            Invoke("DisparoBala", randomTime);
            
        }

        randomTime = Random.Range(1, 3);

    }
}
