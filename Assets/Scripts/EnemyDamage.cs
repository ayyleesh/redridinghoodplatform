using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public AudioSource damagedSound;

    void OnTriggerEnter()
    {
        Health.extraHealth -= 1;
        damagedSound.Play();
    }
}
