using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
 
 public class FollowPlayer : MonoBehaviour {
 
     private bool checkTrigger = false;
     public float speed;
     public Transform target;

     [SerializeField] public Animator animator;

     public AudioSource sonidoMonstruo;
 
     public bool Paralizado = false;
     public int Delay = 300;
     bool isFacingRight = true;
     bool isMoving = false;
     public bool muerta = false;
     public bool recibeLuz = false;
     public bool recibeLuzLinterna = false;
     public bool recibeLuzZona = false;
     bool DisparaUnaVez = true;
     bool PrimerSonidoUsado = false;
     bool SonidoUsado = false;

     float posicionX;
    
     float fusibles;

    [SerializeField] GameObject LuzOjos;

    [SerializeField] GameObject killCollider;

    Stopwatch stopwatchEntra = new Stopwatch();
    Stopwatch stopwatchSale = new Stopwatch();


     void Start () {
         
         target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
         posicionX = transform.position.x;
     }
     
     
     void Update () {

         fusibles = GameObject.Find("Player").GetComponent<ColeccionarFusibles>().fusibles;

        if (recibeLuzZona || recibeLuzLinterna)
        {
            recibeLuz = true;
        } 
        else
        {
            recibeLuz = false;
        }


            //UnityEngine.Debug.Log(recibeLuzLinterna);


         if (fusibles < 2 || muerta || recibeLuz) //fusibles < 2 || 
         {
             Paralizado = true;
             SonidoUsado = false;
             animator.SetBool("isActive", false);
            // UnityEngine.Debug.Log("NOOEstamoActivoPapi");
         }
         else
         {
             Paralizado = false;
             if (!SonidoUsado && PrimerSonidoUsado)
             {
                 sonidoMonstruo.Play();
                 SonidoUsado = true;
             }
             //UnityEngine.Debug.Log("EstamoActivoPapi");
             animator.SetBool("isActive", true);
         }
         
         if (fusibles == 2 && DisparaUnaVez)
         {
             Invoke(nameof(playSonido), 0.5f);
             DisparaUnaVez = false;
         }


//       UnityEngine.Debug.Log(Paralizado);

         if (Paralizado)
         {
            LuzOjos.SetActive(false);
            killCollider.SetActive(false);        
         } 
         else 
         {
             LuzOjos.SetActive(true);
             killCollider.SetActive(true);
         }

        if(posicionX == transform.position.x) //Si no se mueve
        {
            isMoving = false;
            animator.SetBool("isMoving", false);
        }

         if(posicionX != transform.position.x) //Si se mueve
         {
            isMoving = true;
            animator.SetBool("isMoving", true);

            posicionX = transform.position.x - posicionX; //si va hacia la derecha el valor es 1 (positivo)

             if (posicionX > 0 && !isFacingRight && !Paralizado) 
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (posicionX < 0 && isFacingRight && !Paralizado) 
			{
				// ... flip the player.
				Flip();
			}

            posicionX = transform.position.x;
         }
         

               /* if(stopwatchEntra.ElapsedMilliseconds >= Delay){
                    Paralizado = true;
                    stopwatchEntra.Reset();
                }
                */
/*
                if(stopwatchSale.ElapsedMilliseconds >= Delay){
                    recibeLuz = false;
                    stopwatchSale.Reset();
                }

             */   
 
         if (checkTrigger && Paralizado == false && transform.Find("KillCollider02").GetComponent<KillPlayer>().isDeath == false) //checkTrigger &&
        { //Si está en rango && no le da la luz && no está muerto el prota = se mueve
            transform.position = Vector2.MoveTowards (transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime); //GameObject.Find("KillCollider02").GetComponent<KillPlayer>().isDeath == false
        }
     }
    
    void playSonido () 
    {
        sonidoMonstruo.Play();
        PrimerSonidoUsado = true;
    }

     void OnTriggerEnter2D(Collider2D other) {

         if (other.name == "Player") {
             checkTrigger = true;
         }

        /* if (other.name == "ColliderLinterna_2")
          {
              recibeLuz = true;
             // stopwatchEntra.Start(); //Empieza a contar el delay Paralizado
          }
          */
     }
 
     void OnTriggerExit2D(Collider2D other){
         if (other.name == "Player") {
             checkTrigger = false;
         }
/*
         if (other.name == "ColliderLinterna_2")
          {
              //Paralizado = false;
              stopwatchSale.Start();
          }
          */
     }

     void Flip()    
      {
          isFacingRight = !isFacingRight;
  
          Vector3 theScale = transform.localScale;
          theScale.x *= -1;
          transform.localScale = theScale;
      }
}
 