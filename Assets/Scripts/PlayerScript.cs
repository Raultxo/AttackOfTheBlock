using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MouseMove2D : MonoBehaviour {
    
     [SerializeField] private AudioClip[] golpes;
     [SerializeField] private AudioClip sonidoPowerUp;
     
     private Vector3 mousePosition;
     private float moveSpeed = 0.075f;
     private int numGolpe;
     private bool golpeado;
     private AudioSource _audiosource;
     
     // Use this for initialization
     void Start ()
     {
         // Desaparecer cursor y hacer que no pueda salir de la ventana
         Cursor.visible = false;
         Cursor.lockState = CursorLockMode.Confined;
         numGolpe = 0;
         _audiosource = GetComponent<AudioSource>();
         _audiosource.loop = false;
         golpeado = false;
     }
    
     // Update is called once per frame
     void Update () {
         // El sprite sigue en todo momento el ratón, con un offset de 0.075f
         mousePosition = Input.mousePosition;
         mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
         transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
     }
     
     private void OnCollisionEnter2D(Collision2D other)
     {
         switch (other.gameObject.tag)
         { 
             // Si se choca con un enemigo, se reduce una vida, si se golpea 3 veces, se acaba el juego
             case "Enemy":
                 if (!golpeado)
                 {
                     golpeado = true;
                     StartCoroutine(Golpe());
                     _audiosource.clip = golpes[numGolpe];
                     _audiosource.Play();
                     numGolpe++;
                     if (numGolpe >= 3)
                     {
                         StartCoroutine(StopGame());
                     }
                 }
                 
                 break;
             // Si se choca con un powerup, destruye los enemigos cercanos
             case "Powerup":
                 Destroy(other.gameObject);
                 _audiosource.clip = sonidoPowerUp;
                 _audiosource.Play();
                 GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
                 for (int i = 0; i < enemigos.Length; i++)
                 {
                     if (Vector2.Distance(enemigos[i].transform.position, transform.position) < 5f)
                     {
                         Destroy(enemigos[i]);
                     }
                 }
                 break;
         }
     }

     // Corutina para esperar 2 segundos antes de volver a poder ser golpeado
     IEnumerator Golpe()
     {
         yield return new WaitForSeconds(2);
         golpeado = false;
     }

     // Corutina para que de tiempo a que suene el ultimo golpe antes de cerrar el juego
     IEnumerator StopGame()
     {
         yield return new WaitForSeconds(1);
         Application.Quit();
     }
 }
  