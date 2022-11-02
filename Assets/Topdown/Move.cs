using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float mySpeed;
    public Rigidbody2D rb;
    Vector2 movement;

    void Update()
    {
        // Checking for Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * mySpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Collectible")
        {
            Debug.Log("Collision");
            SpriteRenderer sr = other.gameObject.GetComponent("SpriteRenderer") as SpriteRenderer;

            if(sr != null)
            {
                Debug.Log("found sr");
                sr.color = new Color(11, 255, 0);
            }
            else
                Debug.Log("No SpriteRenderer Found in Collision");
        }
    }
}

