using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPuerta2 : MonoBehaviour
{
   // bool fusibles;
    [SerializeField] Animator animator2;
    // Start is called before the first frame update
    void Start()
    {
     //   fusibles = GameObject.Find("Panel Electrico").GetComponent<PanelElectrico>().fusibleVerde;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Panel Electrico").GetComponent<PanelElectrico>().fusibleRojoPuesto == true)
        {
            animator2.SetBool("abrePuerta", true);
        }
    }
}
