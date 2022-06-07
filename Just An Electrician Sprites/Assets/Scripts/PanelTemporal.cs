using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class PanelTemporal : MonoBehaviour
{


    [SerializeField] GameObject Luz;
    [SerializeField] GameObject LuzZona;
    [SerializeField] GameObject Texto;
    [SerializeField] GameObject PanelElectrico;
    [SerializeField] AudioSource sonidoTimer;

    Stopwatch tiempo = new Stopwatch();

    bool activarPermitido = false;
    bool mecanismoActivado = false;

    public float DelayTemp = 5000;


     // Start is called before the first frame update
    void Start()
    {
        Luz.gameObject.SetActive(false);
        LuzZona.gameObject.SetActive(false);
        Texto.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activarPermitido && Input.GetKeyDown(KeyCode.E))
        {
            mecanismoActivado = true;
            tiempo.Start();
            sonidoTimer.Play();
            activarPermitido = false;
        }

        if (mecanismoActivado)
        {
            Texto.gameObject.SetActive(false);
            Luz.gameObject.SetActive(true);
            LuzZona.gameObject.SetActive(true);
        }
        else
        {
            Luz.gameObject.SetActive(false);
            if (PanelElectrico.GetComponent<PanelElectrico>().fusibleAzulPuesto == false)
            {
                 LuzZona.gameObject.SetActive(false);
            }

        }

        if (tiempo.ElapsedMilliseconds >= DelayTemp)
        {
            mecanismoActivado = false;
            tiempo.Reset();
        }
    }

     void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.CompareTag("Player") && !mecanismoActivado)
        {
            Texto.gameObject.SetActive(true);
            activarPermitido = true;
        }
        
    }

     void OnTriggerExit2D(Collider2D other) 
    {

        if (other.CompareTag("Player"))
        {
            Texto.gameObject.SetActive(false);
            activarPermitido = false;
        }

    }
}
