using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    private float speed = 3f;
    private int seed;
    private Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        seed = Random.Range(1, 4);
        rigidbody2d = GetComponent<Rigidbody2D>();
        switch(seed)
        {
            case 1:
                transform.position = new Vector2(transform.position.x + speed * -1, transform.position.y);
                break;
            case 2:
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                break;
            case 3:
                transform.position = new Vector2(transform.position.x, transform.position.y + speed);
                break;
            case 4:
                transform.position = new Vector2(transform.position.x, transform.position.y + speed * -1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (seed)
        {
            case 1:
                speed++;
                rigidbody2d.AddForce(transform.up * 1f,ForceMode2D.Force);
                break;
            case 2:
                speed++;
                speed++;
                rigidbody2d.AddForce(transform.up * 2f,ForceMode2D.Force);
                break;
            case 3:
                break;
            case 4:
                break;
        }
        if (seed == 1)
        {
            
        }
        
    }
}
