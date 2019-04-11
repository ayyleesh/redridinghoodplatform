using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    public bool lookAtPlayer;
    public bool rotate = true;
    public float rotSpeed = 5f;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.deltaTime);

        if (rotate)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * rotSpeed, Vector3.up);
            offset = camTurnAngle * offset;

        }

        if (lookAtPlayer || rotate)
        {
            transform.LookAt(target);
        }
    }
}
