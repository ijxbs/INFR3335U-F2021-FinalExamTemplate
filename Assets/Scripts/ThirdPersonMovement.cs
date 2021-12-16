using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 7f;
    public float grav = 9.81f;
    public float jumpSpeed = 3f;
    public float dirY;

    public Joystick joystick;

    

    // Update is called once per frame
    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                dirY = jumpSpeed;
            }
        }

        dirY -= grav * Time.deltaTime;

        direction.y = dirY;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
