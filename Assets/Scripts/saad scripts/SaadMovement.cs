// i will optimise this script a bit more so mouseSensivity is better
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaadMovement : MonoBehaviour
{
    // Start is called before the first frame update
   
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 3.0f; // speed value to manage player speed
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float mouseSensitivity = 3.0f;

    void Start()
    {
        controller  = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;// new movement every frame
    // checking if player is on the ground or not (line 24-30)
        if(controller.isGrounded){
            verticalVelocity = 0.0f;
        }
        else{
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //drag function
        //x
        // moveVector.x = Input.GetAxisRaw("Horizontal") * speed; // keys left and right are nowq functionable
        moveVector.x = Input.GetAxis("Mouse X") * mouseSensitivity *speed;

        //y

        //z
        moveVector.z = speed; // since we are moving forward automatically so no input needed
        
        controller.Move(moveVector * speed * Time.deltaTime); // move forward at given speed per second    
        }
}
