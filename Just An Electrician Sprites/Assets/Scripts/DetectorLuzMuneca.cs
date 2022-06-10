using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DetectorLuzMuneca : MonoBehaviour
{

    [SerializeField] public GameObject enemigo;

    Stopwatch stopwatchSale = new Stopwatch();

    public float Delay = 300;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

         if(stopwatchSale.ElapsedMilliseconds >= Delay)
         {
            enemigo.GetComponent<FollowPlayer>().recibeLuzLinterna = false;
            stopwatchSale.Reset();
         }
    }

        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Linterna")) 
         {
            enemigo.GetComponent<FollowPlayer>().recibeLuzLinterna = true;
            UnityEngine.Debug.Log("PillaLuzLinterna");
         }

         if (other.CompareTag("DetectorLuz")) //LUZ ZONA
         {
            UnityEngine.Debug.Log("Detectan");
            enemigo.GetComponent<FollowPlayer>().recibeLuzZona = true;
            enemigo.GetComponent<FollowPlayer>().muerta = true;
            enemigo.AddComponent<Rigidbody2D>();
            enemigo.GetComponent<Rigidbody2D>().mass = 4;
         }
    }

        void OnTriggerExit2D(Collider2D other)
    {
         if (other.CompareTag("DetectorLuz")) 
         {
            enemigo.GetComponent<FollowPlayer>().recibeLuzZona = false;
            enemigo.GetComponent<FollowPlayer>().muerta = false;
            Destroy(enemigo.GetComponent<Rigidbody2D>());
         }

         if (other.CompareTag("Linterna")) 
         {
           stopwatchSale.Start();
           UnityEngine.Debug.Log("NOPillaLuzLinterna");
         }
    }

}
