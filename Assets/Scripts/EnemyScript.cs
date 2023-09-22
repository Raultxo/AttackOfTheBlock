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
    // Start is called before the first frame update
    void Start()
    {
        seed = Random.Range(1, 4);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        transform.position = new Vector2(transform.position.x * -1 + speed * Time.deltaTime, transform.position.y);
        if (seed == 1)
        {
            speed++;
        }
    }
}
