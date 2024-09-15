using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    private float ySpeed;
    private CharacterController conn;
    public bool isGrounded;
    public Joystick joy;
    float horizontalSpeed = 0f;
    float verticalSpeed = 0f;
    void Start()
    {
        conn = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        float joyHorizontalMove = joy.Horizontal * speed;
        float joyVerticalMove = joy.Vertical * speed;

        Vector3 moveDirection = new Vector3 (horizontalMove, 0, verticalMove);
        moveDirection.Normalize();
        float magnitude = moveDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);
        conn.SimpleMove(moveDirection * magnitude * speed);

        Vector3 joyMovement = new Vector3(joyHorizontalMove, 0, joyVerticalMove);
        joyMovement.Normalize();
        float joyMagnitude = joyMovement.magnitude;
        joyMagnitude = Mathf.Clamp01(joyMagnitude);
        conn.SimpleMove(joyMovement * joyMagnitude * speed);

        if(horizontalSpeed >= .2f)
        {
            joyHorizontalMove = speed;
        }
        else if(horizontalSpeed <= -.2f)
        {
            joyHorizontalMove = -speed;
        }
        else
        {
            horizontalSpeed = 0f;
        }

        if (verticalSpeed >= .2f)
        {
            joyVerticalMove = speed;
        }
        else if (verticalSpeed <= -.2f)
        {
            joyVerticalMove = -speed;
        }
        else
        {
            verticalSpeed = 0f;
        }

        ySpeed += Physics.gravity.y * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            ySpeed = -0.5f;
            isGrounded = false;
        }

        Vector3 vel = moveDirection * magnitude;
        vel.y = ySpeed;
        conn.Move(vel * Time.deltaTime);

        if (conn.isGrounded)
        {
            ySpeed = -0.5f;
            isGrounded = true;
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
                isGrounded = false;
            }
        }

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }

        if (joyMovement != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(joyMovement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,toRotate, rotationSpeed * Time.deltaTime);
        }
    }
}
