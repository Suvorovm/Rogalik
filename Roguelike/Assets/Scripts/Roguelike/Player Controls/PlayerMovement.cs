using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 10.0f;

    public Joystick RotateJoystick;
    public Joystick moveJoystick;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float vertRotation = RotateJoystick.Vertical;
        float horizRotation = RotateJoystick.Horizontal;
        
        float horizontalJ = moveJoystick.Horizontal;
        float verticalJ = moveJoystick.Vertical;

        Vector3 moveVector = (Vector3.up * horizRotation + Vector3.left * vertRotation);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveDirectionJ = new Vector3(horizontalJ, verticalJ);
        Vector3 moveDirection = new Vector3(horizontal, vertical);
        
        transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime,Space.World);
        transform.Translate(moveDirectionJ * moveSpeed * Time.fixedDeltaTime, Space.World);
        
    }
}
