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

    [SerializeField] private AudioClip colisionAudio;

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
        if (Vector2.Distance(transform.position, new Vector2(0, 0)) > 20)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            _audioSource.clip = colisionAudio;
            _audioSource.Play();
        }
        


    }
}
