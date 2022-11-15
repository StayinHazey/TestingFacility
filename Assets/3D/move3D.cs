using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move3D : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] Rigidbody rb;
    Vector3 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        //rb.MovePosition(new Vector3(rb.position.x + movement.x * Speed * Time.deltaTime, rb.position.y, rb.position.z + movement.z * Speed * Time.deltaTime));
        transform.Translate(movement.x * Speed * Time.deltaTime, 0, movement.z * Speed * Time.deltaTime);
    }
}
