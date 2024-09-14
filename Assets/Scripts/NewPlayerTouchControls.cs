using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerTouchControls : MonoBehaviour
{
    public Joystick joystick;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 Input = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        characterController.Move((Vector3)transform.position + Input * 10 * Time.deltaTime);
    }
}
