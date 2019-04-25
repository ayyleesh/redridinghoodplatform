using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject checkPointObject;
    private Vector3 currentCheckPoint;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0.1f, 0f, 0.1f);
        currentCheckPoint = checkPointObject.transform.position + offset;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Health>().ChangeCheckPoint(currentCheckPoint);
        }
    }
}
