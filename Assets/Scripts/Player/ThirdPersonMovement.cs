using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 7f;
    public float grav = 9.81f;
    public float jumpSpeed = 3f;
    public float dirY;

    public Joystick joystick;
    public Joystick Rightjoystick;

    public float turnSmoothness = 0.1f;
    float turnSmoothVelocity;

    public float CameraAngle;
    public float CameraAngleSpeed = 2f;

    public PhotonView view;

    // Update is called once per frame
    void Update()
    {
        //if (view.IsMine)
        //{
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
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothness);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                controller.Move(direction * speed * Time.deltaTime);
            }

        //}
     
    }
}
