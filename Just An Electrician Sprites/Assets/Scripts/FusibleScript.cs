using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FusibleScript : MonoBehaviour
{

    [SerializeField]
    private GameObject pickUpText;

    [SerializeField]
    AudioSource sonidoRecoger;

    private bool pickUpAllowed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        pickUpText.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(pickUpAllowed);

        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            sonidoRecoger.Play();
            PickUp();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
       if(other.gameObject.CompareTag("Player"))  //&& Input.GetKeyDown("e"
        {
        pickUpAllowed = true;
        pickUpText.gameObject.SetActive(true);
        } 
    }

        void OnTriggerExit2D(Collider2D other) 
    {
       if(other.gameObject.CompareTag("Player"))  //&& Input.GetKeyDown("e"
        {
        pickUpAllowed = false;
        pickUpText.gameObject.SetActive(false);
        } 
    }

    void PickUp()
    {
        
        
        if (gameObject.tag == "fusibleVerde")
        {   
            GameObject.Find("Panel Electrico").GetComponent<PanelElectrico>().fusibleVerde = true;
            GameObject.Find("Player").GetComponent<ColeccionarFusibles>().fusibles += 1;
        }

        if (gameObject.tag == "fusibleAzul")
        {   
            GameObject.Find("Panel Electrico").GetComponent<PanelElectrico>().fusibleAzul = true;
            GameObject.Find("Player").GetComponent<ColeccionarFusibles>().fusibles += 1;
        }

        if (gameObject.tag == "fusibleRojo")
        {   
            GameObject.Find("Panel Electrico").GetComponent<PanelElectrico>().fusibleRojo = true;
            GameObject.Find("Player").GetComponent<ColeccionarFusibles>().fusibles += 1;
        }
        Destroy(gameObject);
    }
}


