using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFromGround : MonoBehaviour
{
    public Animator anim;
    public bool spawned;

    private void Start()
    {
        spawned = false;
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            Invoke("Spawn", 0);
        }
        
    }

    void Spawn()
    {
        anim.Play("SpawnFromGround");
        spawned = true;
    }
}
