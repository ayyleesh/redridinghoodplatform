using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGripper : MonoBehaviour
{
    public GameObject platform;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = platform.transform;
        }
        
    }

    void OnTriggerExit()
    {
        player.transform.parent = null;
    }
}
