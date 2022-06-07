using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaEscalera : MonoBehaviour
{

    public bool haEntrado = false;

    AudioSource Sonido;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(haEntrado);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            haEntrado = true;
        }
    }
}
