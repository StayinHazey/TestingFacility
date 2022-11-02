using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirboMove : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    void FixedUpdate()
    {
        //Enemy that moves up until it hits a wall then down and repeat.
        rb.MovePosition(new Vector2(rb.position.x, rb.position.y + speed * Time.fixedDeltaTime));        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            speed = -speed;
        }
    }
}
