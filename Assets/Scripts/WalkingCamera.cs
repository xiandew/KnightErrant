/*  This module is used to model the walking camera navigation matephor, where
    the camera will tilt left and right to add more realism to the player's
    movement.
    This module's implementation is based on a YouTube video:
    https://www.youtube.com/watch?v=zM6L5WJOsWg
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingCamera : MonoBehaviour
{


    public Animation anim;
    private bool isMoving;

    private bool left;
    private bool right;

    void Start()
    {
        left = true;
        right = false;
    }

 


    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        
        if (xMovement != 0 || zMovement != 0) {
            isMoving = true;
        }
        
        if (xMovement == 0 && zMovement == 0) {
            isMoving = false;
        }

        WalkingAnimation();

    }



    private void ClampXAxisRotationValue(float value){
        Vector3 eulerRotaion = transform.eulerAngles;
        eulerRotaion.x = value;
        transform.eulerAngles = eulerRotaion;
    }

    void WalkingAnimation() {
        if (isMoving == true) {
            if (left == true) {
                if (!anim.isPlaying) {
                    anim.Play("walkLeft");
                    left = false;
                    right = true;
                }
            }
            if (right == true) {
                if (!anim.isPlaying) {
                    anim.Play("walkRight");
                    left = true;
                    right = false;
                }
            }
        }
    }
}
