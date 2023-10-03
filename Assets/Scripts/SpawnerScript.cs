using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject bola;
    [SerializeField] private GameObject jugador;
    [SerializeField] private GameObject powerup;
    
    private float tiempoEnemy = 2f;
    private float tiempoPower = 15f;
    
    void Start()
    {
        // Spawnea un enemigo cada 2 segundos
        InvokeRepeating("SpawnEnemy", tiempoEnemy, tiempoEnemy);
        // Spawnea un powerup cada 15 segundos
        InvokeRepeating("SpawnPower", tiempoPower,tiempoPower);
    }

    void SpawnEnemy()
    {
        // Spawnear la bola de manera aleatoria controlando que no spawnee en el jugador
        // Controlando que haya siempre 20 enemigos como maximo
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 20)
        {
            float posX = Random.Range(-9f, 9f);
            float posY = Random.Range(-5f, 5f);

            while (Vector2.Distance(jugador.transform.position, new Vector2(posX,posY)) < 4f)
            {
                posX = Random.Range(-9f, 9f);
                posY = Random.Range(-5f, 5f);
            }
            GameObject.Instantiate(bola, new Vector2(posX, posY), Quaternion.identity);
        }
        
    }
    
    void SpawnPower()
    {
        // Spawnear el powerup de manera aleatoria controlando que no spawnee en el jugador
        // Pero puede spawnear más cerca que los enemigos
        // Cuando aparece uno, desaparece el anterior
        float posX = Random.Range(-9f, 9f);
        float posY = Random.Range(-5f, 5f);

        while (Vector2.Distance(jugador.transform.position, new Vector2(posX,posY)) < 2f)
        {
            posX = Random.Range(-9f, 9f);
            posY = Random.Range(-5f, 5f);
        }
        Destroy(GameObject.FindWithTag("Powerup"));
        GameObject.Instantiate(powerup, new Vector2(posX, posY), Quaternion.identity);
    }
}
