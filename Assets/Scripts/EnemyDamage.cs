using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public AudioSource damagedSound;

    void OnTriggerEnter()
    {
        if (Health.playerHealth > 0)
        {
            Health.damage -= 1;
            damagedSound.Play();
        }
    }
}
