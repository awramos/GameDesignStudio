using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed;
    public Transform trans;
    public Transform orientation;

    bool isGrounded;
    public float groundDrag;
    public float jumpSpeed;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    public bool hasItem;
    public bool hasKey;
    public bool isDone;

    public AudioSource backgroundMusic;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        moveSpeed = 5;
        groundDrag = 4;
        jumpSpeed = 2;
        hasItem = false;
        hasKey = false;
        isDone = false;
        backgroundMusic = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //player input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        speedControl();
    }

    private void FixedUpdate()
    {
        //player movement
        moveDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            jump();
        }
    }

    private void speedControl()
    {
        Vector3 vel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //cap max speed
        if(vel.magnitude > moveSpeed)
        {
            Vector3 limitVel = vel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    private void jump()
    {
        isGrounded = false;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Ground")
        //{
            isGrounded = true;
        //}            
    }


}
