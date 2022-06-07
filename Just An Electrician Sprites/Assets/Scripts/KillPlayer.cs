using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public int Respawn;
    public Animator animator;

    Stopwatch stopwatch = new Stopwatch();

    [SerializeField] public GameObject enemigo;


    public int tiempoMuerte = 1500;
    public bool isDeath = false;

    // Start is called before the first frame update
    void Start()
    {
//       UnityEngine.Debug.Log(isDeath);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatch.ElapsedMilliseconds >= tiempoMuerte)
            {
                //SceneManager.LoadScene(Respawn);
                GameObject.Find("Player").GetComponent<PlayerMovement>().haMuerto = true;
                GameObject.Find("Player").GetComponent<PlayerMovement>().isDeath = false;
                isDeath = false;
                animator.SetBool("isDeath", false);

                stopwatch.Reset();
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.CompareTag("Linterna")) 
         {
            enemigo.GetComponent<FollowPlayer>().recibeLuzLinterna = true;
            UnityEngine.Debug.Log("PillaLuzLinterna");
         }

         if (other.CompareTag("DetectorLuz")) //LUZ ZONA
         {
            enemigo.GetComponent<FollowPlayer>().recibeLuzZona = true;
            enemigo.GetComponent<FollowPlayer>().muerta = true;
            enemigo.AddComponent<Rigidbody2D>();
            enemigo.GetComponent<Rigidbody2D>().mass = 4;
         }
*/
        if (other.CompareTag("Player"))
        {
            isDeath = true;
            animator.SetBool("isDeath", true);
            stopwatch.Start();
        }
    }

        void OnTriggerExit2D(Collider2D other)
    {
        /*
         if (other.CompareTag("DetectorLuz")) 
         {
            enemigo.GetComponent<FollowPlayer>().recibeLuzZona = false;
            enemigo.GetComponent<FollowPlayer>().muerta = false;
            Destroy(enemigo.GetComponent<Rigidbody2D>());
         }

         if (other.CompareTag("Linterna")) 
         {
            enemigo.GetComponent<FollowPlayer>().recibeLuzLinterna = false;
           UnityEngine.Debug.Log("NOPillaLuzLinterna");
         }

         */
    }

}
