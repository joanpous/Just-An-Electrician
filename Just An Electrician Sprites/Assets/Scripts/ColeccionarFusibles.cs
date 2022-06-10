using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColeccionarFusibles : MonoBehaviour
{
    // Start is called before the first frame update

    public float fusibles = 0;

    public Text texto;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ///Debug.Log(fusibles);
        ActualizaTexto();
    }

    public void ActualizaTexto()
    {
        if (fusibles == 0)
        {
            texto.text = "fusibles 0/3";
        }

        if (fusibles == 1)
        {
            texto.text = "fusibles 1/3";
        }

        if (fusibles == 2)
        {
            texto.text = "fusibles 2/3";
        }

        if (fusibles == 3)
        {
            texto.text = "fusibles 3/3";
        }
    }
}
