/*  This module implements a FPS camera controller.
    It's based on the implementation from YouTube turorial:
    https://www.youtube.com/watch?v=n-KX8AeGK7E
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;

    private float xAxisClamp;


    void Start() {
        LockCursor();
        xAxisClamp = 0.0f;
    }

    void Update() {
        CameraRotation();
    }

    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CameraRotation() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        // Make sure the player can only look up and down for 90 degrees maximum
        if (xAxisClamp > 90.0f) {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        } else if (xAxisClamp < -90.0f) {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value) {
        Vector3 eulerRotaion = transform.eulerAngles;
        eulerRotaion.x = value;
        transform.eulerAngles = eulerRotaion;
    }
 
}
