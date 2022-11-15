using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject player;

    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -1);
    }
}