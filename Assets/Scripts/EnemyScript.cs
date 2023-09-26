using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    private int seed;
    private Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        // Un random que invierte la gravedad a aprox la mitad de los enemigos
        seed = Random.Range(0, 2);
        rigidbody2d = GetComponent<Rigidbody2D>();
        switch(seed)
        {
            case 0:
                rigidbody2d.gravityScale = -1;
                break;
            case 1:
                rigidbody2d.gravityScale = 1;
                break;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        
    }
}
