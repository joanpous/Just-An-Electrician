using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptPresentacion : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(FadeSalida), 37f);
    }

    void FadeSalida ()
    {
        animator.SetBool("Salida", true);
        Invoke(nameof(SalidaNivel), 1.5f);
    }

    void SalidaNivel () 
    {
        SceneManager.LoadScene("Nivel01");
    }
}
