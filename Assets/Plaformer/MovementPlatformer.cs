using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatformer : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    public Rigidbody2D rb;
    public Animator anim;
    public BoxCollider2D boxcoll;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    float xMove;
    float wallJumpCooldown;

    // Update is called once per frame
    void Update()
    {
        //Checking for horizontal keyboard input
        xMove = Input.GetAxisRaw("Horizontal");

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
        anim.SetBool("grounded", isGrounded());
    }

    void FixedUpdate()
    {

        //Wall Jump Logic
        if(wallJumpCooldown > 0.2f)
        {
            // Moves us left and right
            rb.velocity = new Vector2(xMove * moveSpeed, rb.velocity.y);

            if(onWall() && !isGrounded())
            {
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
            }
            else
                rb.gravityScale = 2.5f;

            if(Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    private void Jump()
    {
        if(isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if(onWall() && !isGrounded())
        {
            if(xMove == 0)
            {
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 7, 2);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 2, 6);
            }
            wallJumpCooldown = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcoll.bounds.center, boxcoll.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcoll.bounds.center, boxcoll.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

}
