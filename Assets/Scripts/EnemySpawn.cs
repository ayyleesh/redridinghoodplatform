using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public float spawnDelay;

    public Transform spawnPoint;

     void Start()
    {
        spawnPoint = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("Spawn", spawnDelay);
        }
    }

    void Spawn()
    {
        enemy.SetActive(true);
    }
}
