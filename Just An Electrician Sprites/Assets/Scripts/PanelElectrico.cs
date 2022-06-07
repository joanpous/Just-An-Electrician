using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelElectrico : MonoBehaviour
{

    public bool fusibleAzul = false;
    public bool fusibleRojo = false;
    public bool fusibleVerde = false;

    public bool fusibleVerdePuesto = false;
    public bool fusibleRojoPuesto = false;
    public bool fusibleAzulPuesto = false;

    [SerializeField]  
    private GameObject Verde;
    [SerializeField] 
    private GameObject Azul;
    [SerializeField] 
    private GameObject Rojo;

    [SerializeField]  
    private GameObject Zona1;
    [SerializeField] 
    private GameObject Zona2;
    [SerializeField] 
    private GameObject Zona3;

    [SerializeField] 
    AudioSource sonidoFusible;
    [SerializeField] 
    AudioSource sonidoCompletado;

    bool AudioUsado1 = false;
    bool AudioUsado2 = false;
    bool AudioUsado3 = false;
    bool AudioUsado4 = false;

    // Start is called before the first frame update
    void Start()
    {
        Azul.gameObject.SetActive(false);
        Verde.gameObject.SetActive(false);
        Rojo.gameObject.SetActive(false);

        Zona1.gameObject.SetActive(false);
        Zona2.gameObject.SetActive(false);
        Zona3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(fusibleAzul);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
       if(other.gameObject.CompareTag("Player")) 
        {
            if (fusibleVerde)
            {
                Verde.gameObject.SetActive(true);
                Zona1.gameObject.SetActive(true);
                
                if(!AudioUsado2)
                {
                    sonidoFusible.Play();
                    AudioUsado2 = true;
                    fusibleVerdePuesto = true;

                    GameObject.Find("Player").GetComponent<PlayerMovement>().Checkpoint = GameObject.Find("Player").transform.position;
                }
            }

            if (fusibleAzul)
            {
                Azul.gameObject.SetActive(true);
                Zona3.gameObject.SetActive(true);

                if(!AudioUsado1)
                {
                    sonidoFusible.Play();
                    AudioUsado1 = true;
                    fusibleAzulPuesto = true;
                }
                
            }


            if (fusibleRojo)
            {
                Rojo.gameObject.SetActive(true);
                Zona2.gameObject.SetActive(true);
                
                if(!AudioUsado3)
                {
                    sonidoFusible.Play();
                    AudioUsado3 = true;
                    fusibleRojoPuesto = true;
                }
            }

            if (fusibleAzul && fusibleRojo && fusibleVerde && !AudioUsado4)
            {
                sonidoCompletado.Play();
                AudioUsado4 = true;
            }
        
        } 
    }
}
