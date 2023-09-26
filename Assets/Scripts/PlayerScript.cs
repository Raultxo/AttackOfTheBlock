using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

 public class MouseMove2D : MonoBehaviour {
  
     private Vector3 mousePosition;
     private float moveSpeed = 0.075f;
  
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
         // Si se choca con un enemigo, se acaba el juego
         if (other.gameObject.tag == "Enemy")
         {
             Application.Quit();
         }
         
         
     }
 }
  