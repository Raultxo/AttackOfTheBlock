using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private AudioClip colisionAudio;
    
    private int seed;
    private Rigidbody2D rigidbody2d;
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
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
        // Controlar que si los enemigos se salen del area de juego desaparecen
        if (Vector2.Distance(transform.position, new Vector2(0, 0)) > 20)
        {
            Destroy(gameObject);
        }

    }

    // Cada vez que el enemigo colisiona con una pared suena un audio
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            _audioSource.clip = colisionAudio;
            _audioSource.Play();
        }
        


    }
}
