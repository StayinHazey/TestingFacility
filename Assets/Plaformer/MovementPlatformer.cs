using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatformer : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    float xMove;
    bool jumpPress;

    // Update is called once per frame
    void Update()
    {
        //Checking for horizontal keyboard input
        xMove = Input.GetAxisRaw("Horizontal");

        //Checking for spacebar keyboard input
        if(Input.GetKey(KeyCode.Space))
        {
            jumpPress = true;
        }
        else
        {
            jumpPress = false;
        }
    }

    void FixedUpdate()
    {
        // Moves us left and right
        rb.velocity = new Vector2(xMove * moveSpeed, rb.velocity.y);

        // Jump
        if(jumpPress){
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        }
    }
}
