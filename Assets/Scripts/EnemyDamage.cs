using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter()
    {
        Health.extraHealth -= 1;
        collectSound.Play();
    }
}
