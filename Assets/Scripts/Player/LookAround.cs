using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform playerBody;

    private float mouseSensitivity = 400f;
    private float xRotation = 0f;
   
    void Start()
    {
        // Keep the cursor in the centre of the screen
        Cursor.lockState = CursorLockMode.Locked;
        // Turn cursor invisible
        Cursor.visible = false;
    }

    void Update()
    {
        // Get the Input values
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Set the rotation
        xRotation -= mouseY;
        // Clamp the rotation between looking above you and to the ground (not behind you)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate the camera on the X axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Rotate the whole player on the Y axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
