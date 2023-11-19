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

    public AudioSource jumpSound;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
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
        jumpSound.Play();
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

        if (other.gameObject.tag == "Enemy")
        {
            GameManager.instance.Lose();
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.Win();
    }


}
