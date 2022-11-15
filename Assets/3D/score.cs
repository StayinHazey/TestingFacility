using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    int Score;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Ground"){
            Score++;
            Debug.Log(Score); 
        }  
    }
}
