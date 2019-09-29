/*  This module is used to model the walking camera navigation matephor, where
    the camera will tilt left and right to add more realism to the player's
    movement.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingCamera : MonoBehaviour
{

    public Animation animation;
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

    void WalkingAnimation() {
        if (isMoving == true) {
            if (left == true) {
                if (!animation.isPlaying) {
                    animation.Play("walkLeft");
                    left = false;
                    right = true;
                }
            }
            if (right == true) {
                if (!animation.isPlaying) {
                    animation.Play("walkRight");
                    left = true;
                    right = false;
                }
            }
        }
    }
}
