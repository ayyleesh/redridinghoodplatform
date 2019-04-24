using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectHealthItem : MonoBehaviour
{
    public AudioSource collectSound;
    public int heal_amt = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Health>().HealPlayer(heal_amt);
            collectSound.Play();
            Destroy(gameObject);
        }
        
    }

}
