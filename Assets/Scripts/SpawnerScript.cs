using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject bola;

    [SerializeField] private float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", tiempo, tiempo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        GameObject.Instantiate(bola);
    }
}
