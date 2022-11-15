using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    Color32 hasPackColour = new Color32 (255, 205, 0, 255);
    Color32 noPackColour = new Color32 (162, 150, 255, 255);
    bool hasPack = false;
    int score = 0;

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision with hard object detected");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !hasPack){
            hasPack = true;
            Debug.Log("Package Received. hasPack = " + hasPack);
            Destroy(other.gameObject);
            sr.color = hasPackColour;
        }

        if((other.tag == "Customer") && hasPack){
            hasPack = false;
            Debug.Log("Package Delivered. hasPack = " + hasPack);
            score++;
            Debug.Log("SCORE: " + score);
            sr.color = noPackColour;
        }
    }
}
