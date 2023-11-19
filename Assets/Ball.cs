using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveForce;
    public float jumpSpeed;
    public float maxSpeed = 5f;

    Rigidbody2D rb;

    public bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(hor, 0) * moveForce);

        if (Input.GetButtonDown("Jump") && isGrounded)  
        {
            Jump();

        }

        LimitSpeed();

    }

    void Jump()
    { 
        rb.velocity += Vector2.up * jumpSpeed;
    }

    void LimitSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.drag = 1;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }


}
