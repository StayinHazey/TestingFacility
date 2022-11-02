using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatformer : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    float xMove;
    bool jumpPress;
    public Animator anim;
    private bool grounded;

    // Update is called once per frame
    void Update()
    {
        //Checking for horizontal keyboard input
        xMove = Input.GetAxisRaw("Horizontal");

        //Checking for spacebar keyboard input
        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            jumpPress = true;
        }
        else
        {
            jumpPress = false;
        }
        


        //Flipping the sprite for left and right facing
        //Right Facing
        if(xMove > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        //Left Facing
        else if(xMove < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        //Run Animation Transition to and from Idle
        //If its -1 its left moving, if its 1 its right moving... If its 0 its idle. So
        //It reads this to determine the bool; if its not 0, run is true.
        anim.SetBool("run", xMove != 0);

        //Animation for jumping
        anim.SetBool("grounded", grounded);
    }

    void FixedUpdate()
    {
        // Moves us left and right
        rb.velocity = new Vector2(xMove * moveSpeed, rb.velocity.y);

        // Jump
        if(jumpPress){
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

}
