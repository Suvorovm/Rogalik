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

    private Vector3 rotationVector;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Поворот стиком
        float vertRotation = RotateJoystick.Vertical;
        float horizRotation = RotateJoystick.Horizontal;
        
        // Передвижение стиком
        float horizontalJ = moveJoystick.Horizontal;
        float verticalJ = moveJoystick.Vertical;

        // Передвижение WASD
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        if (vertRotation != 0 || horizRotation != 0)
        {
            rotationVector = (Vector3.up * horizRotation + Vector3.left * vertRotation);
        }
        else if (horizontalJ != 0 || verticalJ != 0)
        {
            rotationVector = (Vector3.up * horizontalJ + Vector3.left * verticalJ);
        }
        else if (horizontal != 0 || vertical != 0)
        {
            rotationVector = (Vector3.up * horizontal + Vector3.left * vertical);
        }
        
        transform.rotation = Quaternion.LookRotation(Vector3.forward, rotationVector);
        
        Vector3 moveDirectionJ = new Vector3(horizontalJ, verticalJ);
        Vector3 moveDirection = new Vector3(horizontal, vertical);
        
        transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime,Space.World);
        transform.Translate(moveDirectionJ * moveSpeed * Time.fixedDeltaTime, Space.World);
        
    }
}
