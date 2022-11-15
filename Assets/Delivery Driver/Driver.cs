using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed;
    [SerializeField] float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxisRaw("Vertical");
        float hori = Input.GetAxisRaw("Horizontal");

        transform.Rotate(0, 0, hori * -steerSpeed * Time.deltaTime);
        transform.Translate(0, vert * moveSpeed * Time.deltaTime, 0);
    }
}
