using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;

using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    [SerializeField] Animator animator;

    Stopwatch tiempo = new Stopwatch();

    [SerializeField] float TiempoFade = 1000;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            tiempo.Start();
            animator.SetBool("Salida", true);
        }

        if (tiempo.ElapsedMilliseconds > TiempoFade)
        {
        SceneManager.LoadScene("Presentacion");
        }
    }
}
