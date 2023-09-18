using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed.
    public float horizontalInput;
    public float jumpSpeed = 10f; // Adjust jump speed as needed.

    public bool isJumping; //a boolean to keep our character from jumping multiple times in the air

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //assigns rb to rigidbody, so it knows that anything declared with rb is related to our player physics
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = movement;

        if (Input.GetButtonDown("Jump") && isJumping == false) // provided the player is on the groumd, they can jump.
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground")) // if the player (gameObject) is on the "Ground", then the player can jump.
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
    // if the player is in the air, then they cannot jump again.
}
