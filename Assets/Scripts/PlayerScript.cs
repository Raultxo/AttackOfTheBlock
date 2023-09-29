using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MouseMove2D : MonoBehaviour {
  
     private Vector3 mousePosition;
     private float moveSpeed = 0.075f;
     [SerializeField] private GameObject powerup;
     
     // Use this for initialization
     void Start ()
     {
         // Desaparecer cursor y hacer que no pueda salir de la ventana
         Cursor.visible = false;
         Cursor.lockState = CursorLockMode.Confined;
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
             // Si se choca con un enemigo, se acaba el juego
             case "Enemy":
                 Application.Quit();
                 break;
             // Si se choca con un powerup, destruye los enemigos cercanos
             case "Powerup":

                 Destroy(other.gameObject);
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
 }
  