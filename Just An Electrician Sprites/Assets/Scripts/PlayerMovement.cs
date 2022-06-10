using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using UnityEngine;

using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public Animator animatorCamera;
    public Animator animatorBlackFade;
    public Animator animatorBarras;
    public Animator animatorCamera3;
    public Animator animatorCamera4;
    [SerializeField] AudioSource landSound;
    [SerializeField] AudioSource deathSound;
    [SerializeField] AudioSource audioCorrer;
    [SerializeField] AudioSource sonidoEscalera;
    [SerializeField] AudioSource DialogoLargo;
    [SerializeField] AudioSource SoloquedaUno;
    [SerializeField] AudioSource Dimitir;
    [SerializeField] AudioSource Resucita01;
    [SerializeField] AudioSource Resucita02;

    int EligeSonidoResucita = 1;

    [SerializeField] GameObject barras;

    Stopwatch tempCharla = new Stopwatch();

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    public bool isDeath = false; // Cuando golpea el killCollider
    public bool haMuerto = false; // Cuando ha pasado el tiempo de muerte

    bool sonidoEscaleraUsado = false;
    bool sonidoSoloUnoUsado = false;
    bool sonidoDimitirUsado = false;

    bool AudioCorrerActivo = false;

    bool DisparaUnaVez = true;

    bool CharlaUsada = false;

    bool cinematica = false;
    float tiempoEntradaPlanoMonstruo = 4f;
    float tiempoPlanoMonstruo = 3f;
    //public float tiempoPlanoCara = 64f;

    float tiempoPlanoCara1 = 40f;
    float tiempoCutscene3 = 20f;
    float tiempoPlanoCara2 = 3.5f;

    bool isJumping = false;

    public Vector3 Checkpoint;


    void Start()
    {
        Checkpoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {  

        if (GameObject.Find("Panel Electrico").GetComponent<PanelElectrico>().fusibleRojoPuesto == true && !sonidoSoloUnoUsado)
        {
            SoloquedaUno.Play();
            sonidoSoloUnoUsado = true;
        }

        if (GameObject.Find("Panel Electrico").GetComponent<PanelElectrico>().fusibleAzulPuesto == true && !sonidoDimitirUsado)
        {
            Dimitir.Play();
            sonidoDimitirUsado = true;
            Invoke(nameof(SalidaNivel), 5f);
        }
        
        if (GameObject.Find("Player").GetComponent<ColeccionarFusibles>().fusibles == 2 && !CharlaUsada)
        {   
            UnityEngine.Debug.Log("DialogoIn");
            Invoke(nameof(PlayDialogo), 2.4f);
            CharlaUsada = true;
        }

        if (haMuerto)
        {
            transform.position = Checkpoint;

            if(EligeSonidoResucita > 0)
            {
                Resucita01.Play();
            }
            else
            {
                Resucita02.Play();
            }
            EligeSonidoResucita = EligeSonidoResucita * -1;

            haMuerto = false;
        }

       if (isDeath == false && cinematica == false){
           Movimiento();
       }


            if (GameObject.Find("Player").GetComponent<ColeccionarFusibles>().fusibles == 2 && DisparaUnaVez)
            {
                cinematica = true;
                animatorBarras.SetBool("cinematica", true);
                Invoke(nameof(EntraCutscene1), tiempoEntradaPlanoMonstruo);
                barras.SetActive(true);
                DisparaUnaVez = false;
            }
             
    }

    void SalidaNivel ()
    {
        animatorBlackFade.SetBool("Salida", true);
        Invoke(nameof(VuelveMenu), 5f);
    }

    void VuelveMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void EntraCutscene1 ()
    {
        animatorCamera.SetBool("cutscene1", true);
        Invoke(nameof(EntraCutscene2), tiempoPlanoMonstruo);
    }

    void EntraCutscene2 ()
    {
        animatorCamera.SetBool("cutscene2", true);
        animatorCamera.SetBool("cutscene1", false);

        animatorCamera3.SetBool("planoCara", true);

        Invoke(nameof(EntraCutscene3), tiempoPlanoCara1);
    }

    void EntraCutscene3 ()
    {
        animatorCamera.SetBool("cutscene3", true);
        animatorCamera4.SetBool("AnimCutscene3", true);
        Invoke(nameof(VuelveCutscene2), tiempoCutscene3);
    }

    void VuelveCutscene2 ()
    {
        animatorCamera.SetBool("cutscene3", false);
        Invoke(nameof(SaleCutscene), tiempoPlanoCara2);
    }
    void SaleCutscene ()
    {
        animatorCamera.SetBool("cutscene2", false);
        barras.SetActive(false);
        cinematica = false;
        animatorBarras.SetBool("cinematica", false);
    }

    public void OnLanding () {
        animator.SetBool("IsJumping", false);
        isJumping = false;
        landSound.Play();
        UnityEngine.Debug.Log("Land");
    }

    void FixedUpdate (){

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
 
    }

    void OnTriggerEnter2D(Collider2D other) //cuando tope con COLLIDER MALO
    {
       if(other.gameObject.CompareTag("Kill")){
            isDeath = true;
            deathSound.Play();
        }

        if(other.CompareTag("DetectorLadder") && GameObject.Find("DetectorSala1").GetComponent<ActivaEscalera>().haEntrado == true)
        {
//            Debug.Log("Funciona");
            GameObject.Find("Ladder (1)").GetComponent<Animator>().SetBool("escaleraActivada", true);

            if(!sonidoEscaleraUsado)
            {
                sonidoEscalera.Play();
                sonidoEscaleraUsado = true;
            }
            
        }
    }

    void Movimiento () {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        

        if(Mathf.Abs(horizontalMove) != 0 && !isJumping) // si está corriendo
        {
            if (!AudioCorrerActivo && !isJumping)
          {
            audioCorrer.Play();
            AudioCorrerActivo = true;
          }
        }
        else
        {
            audioCorrer.Pause();
            AudioCorrerActivo = false;
        }

         if (Input.GetButtonDown("Jump"))
         {
            jump = true;
            isJumping = true;
            animator.SetBool("IsJumping", true);
            audioCorrer.Pause();
            AudioCorrerActivo = false;
         }

        // UnityEngine.Debug.Log(isJumping);
    }

    void PlayDialogo ()
    {
        DialogoLargo.Play();
    }
}
