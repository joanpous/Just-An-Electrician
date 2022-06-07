using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaSonido : MonoBehaviour
{

    bool SonidoUsado = false;
    [SerializeField] AudioSource sonido;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other) //cuando tope con COLLIDER MALO
    {
       if(other.gameObject.CompareTag("Player") && !SonidoUsado){
            SonidoUsado = true;
            sonido.Play();
        }
    }
}
