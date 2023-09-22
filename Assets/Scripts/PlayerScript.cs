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
         Cursor.visible = false;
     }
    
     // Update is called once per frame
     void Update () {
         mousePosition = Input.mousePosition;
         mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
         transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
     }

     private void OnCollisionEnter2D(Collision2D other)
     {
         Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
         
         
     }
 }
  