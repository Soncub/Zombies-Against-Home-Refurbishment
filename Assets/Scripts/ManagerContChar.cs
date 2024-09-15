using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerContChar : MonoBehaviour
{
    private CharacterController _charController;
    private Transform meshPlayer;
    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    private float moveSpeed;
    void Start()
    {
        moveSpeed = 0.1f;
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        meshPlayer = tempPlayer.transform.GetChild(0);
        _charController = tempPlayer.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        v_movement = new Vector3(inputX * moveSpeed, 0, inputZ * moveSpeed);
        _charController.Move(v_movement);

        Vector3 lookDir = new Vector3(v_movement.x, 0, v_movement.z);
        meshPlayer.rotation = Quaternion.LookRotation(lookDir);
    }
}
