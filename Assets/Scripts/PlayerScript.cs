using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public float rotSpeed;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    private Vector3 moveDirection;

    CharacterController controller;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter <= 0)
        {
            var y = moveDirection.y;
            var rotate = Input.GetAxis("Horizontal") * rotSpeed;
            moveDirection = (transform.forward * Input.GetAxis("Vertical") * moveSpeed);
            moveDirection.y = y;

            transform.Rotate(0, rotate, 0);

            if (controller.isGrounded)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    moveDirection.y = jumpForce;
                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);

        bool walking = moveDirection.x != 0f || moveDirection.z != 0f;
        anim.SetBool("isWalking", walking);
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;
        
        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;

    }
}
