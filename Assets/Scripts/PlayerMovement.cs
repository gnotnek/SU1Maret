using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float speed = 10f;
    private float gravity = 15f;
    public float jumpForce = 10f;
    private float verticalVelocity;

    void Awake() {
        controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();    
    }

    private void move() {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        direction = transform.TransformDirection(direction);
        direction *= speed * Time.deltaTime;
        applyGravity();
        controller.Move(direction);
    
    }

    private void applyGravity() {
        if (controller.isGrounded) {
            verticalVelocity -= gravity * Time.deltaTime;
            playerJump();
        } else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        direction.y = verticalVelocity * Time.deltaTime;
        //direction.y = verticalVelocity;
    }

    void playerJump()
    {
        if(controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }
    }
}
