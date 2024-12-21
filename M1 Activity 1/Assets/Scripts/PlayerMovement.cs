using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;          
    private Vector3 moveDirection;    

    void Update()
    {
        float moveDirectionY = Input.GetAxis("Vertical"); 
        float moveDirectionX = Input.GetAxis("Horizontal"); 

        moveDirection = transform.right * moveDirectionX + transform.forward * moveDirectionY;

        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}

