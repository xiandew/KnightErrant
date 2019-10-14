/*  This module is used to model the walking camera navigation matephor, where
    the camera will tilt left and right to add more realism to the player's
    movement.
    This module's implementation is based on a YouTube video:
    https://www.youtube.com/watch?v=n-KX8AeGK7E&t=332s 
    */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;
    private float xAxisClamp;


    private void Awake(){
        LockCursor();
        xAxisClamp = 0.0f;
    }
    private void LockCursor(){
        Cursor.lockState = CursorLockMode.Locked;
    }



    void Update()
    {
        CameraRotation();

    }

    private void CameraRotation(){
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp > 90.0f) {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationValue(270.0f);
        }
        else if(xAxisClamp < -90.0f) {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationValue(90.0f);
        }
        transform.Rotate(-transform.right * mouseY);
    }

    private void ClampXAxisRotationValue(float value){
        Vector3 eulerRotaion = transform.eulerAngles;
        eulerRotaion.x = value;
        transform.eulerAngles = eulerRotaion;
    }

 
}
