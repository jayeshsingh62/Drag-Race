﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 15.0f;
    private float tiltSpeed = 50.0f;
    private float rotationSpeed;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // get the user's rotation input
        rotationSpeed = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed * rotationSpeed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * tiltSpeed * verticalInput * Time.deltaTime);
    }
}
