using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public AudioSource spawnSound;
    public GameObject enemy;
    public float spawnDelay;
    private bool hasPlayed = false;

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
            if (!hasPlayed)
            {
                spawnSound.Play();
                hasPlayed = true;
            }
        }
    }

    void Spawn()
    {
        enemy.SetActive(true);
    }
}
