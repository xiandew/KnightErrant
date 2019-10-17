using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSoundController : MonoBehaviour
{

    private CharacterController characterController;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded == true) {
            if (characterController.velocity.magnitude > 0 && audioSource.isPlaying == false) {
                audioSource.volume = Random.Range(0.8f, 1);
                audioSource.pitch = Random.Range(1.2f, 1.5f);
                audioSource.Play();
            } else if (characterController.velocity.magnitude <= 0 && audioSource.isPlaying == true) {
                audioSource.Stop();
            }
        }
    }
}
