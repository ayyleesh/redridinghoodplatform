using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectHealthItem : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter()
    {
        Health.extraHealth += 1;
        collectSound.Play();
        Destroy(gameObject);
    }

}
