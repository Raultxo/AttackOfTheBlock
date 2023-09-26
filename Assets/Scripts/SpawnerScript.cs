using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject bola;
    [SerializeField] private GameObject jugador;

    private float tiempo = 7f;
    // Start is called before the first frame update
    void Start()
    {
        // Llamar al metodo "Spawn" cada 5 segundos
        InvokeRepeating("Spawn", tiempo, tiempo);
    }

    void Spawn()
    {
        // Spawnear la bola de manera aleatoria controlando que no spawnee en el jugador
        float posX = Random.Range(-9f, 9f);
        float posY = Random.Range(-5f, 5f);

        while (Vector2.Distance(jugador.transform.position, new Vector2(posX,posY)) < 3f)
        {
            posX = Random.Range(-9f, 9f);
            posY = Random.Range(-5f, 5f);
        }
        GameObject.Instantiate(bola, new Vector2(posX, posY), Quaternion.identity);
    }
}
