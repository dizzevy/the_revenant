using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseYSentitivity = 100f;
    public float mouseXSentitivity = 100f;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseXSentitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseYSentitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        

    }
}
