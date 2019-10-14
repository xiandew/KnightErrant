using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public float speed;
    // public float sensitivity;
    // private float yaw = 0.0f;
    // private float pitch = 0.0f;

    // void Start()
    // {
    //     // Initial orientation
    //     this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     // Update orientation
    //     yaw += sensitivity * Input.GetAxis("Mouse X");
    //     pitch -= sensitivity * Input.GetAxis("Mouse Y");

    //     // Clamp pitch:
    //     pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);

    //     // Wrap yaw:
    //     while (yaw < 0.0f) {
    //         yaw += 360.0f;
    //     }
    //     while (yaw >= 360.0f) {
    //         yaw -= 360.0f;
    //     }

    //     this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    //     // The player moves left while key A is pressed.
    //     if (Input.GetKey(KeyCode.A)) {
    //         this.transform.Translate(Vector3.left * speed * Time.deltaTime);
    //     }

    //     // The player moves right while key D is pressed.
    //     if (Input.GetKey(KeyCode.D)) {
    //         this.transform.Translate(Vector3.right * speed * Time.deltaTime);
    //     }

    //     // The player moves forward while key W is pressed.
    //     if (Input.GetKey(KeyCode.W)) {
    //         this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    //     }

    //     // The player moves backward while key S is pressed.
    //     if (Input.GetKey(KeyCode.S)) {
    //         this.transform.Translate(Vector3.back * speed * Time.deltaTime);
    //     }

    // }

    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float speed;

    private CharacterController characterController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode JumpKey;

    private bool isJumping;
    private void Awake(){
        characterController = GetComponent<CharacterController>();

    }

    void Update(){
        move();
    }

    private void move(){
        float horizInput = Input.GetAxis(horizontalInputName) * speed;
        float vertInput = Input.GetAxis(verticalInputName) * speed;


        Vector3 moveForward = transform.forward * vertInput;
        Vector3 moveRight = transform.right * horizInput;

        characterController.SimpleMove(moveForward + moveRight);
        JumpInput();
    }

    private void JumpInput(){
        if(Input.GetKeyDown(JumpKey) && !isJumping){
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent() {
        float timeInAir = 0.0f;
        do{
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            characterController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        }while(!characterController.isGrounded && characterController.collisionFlags != CollisionFlags.Above);

        isJumping = false;
    }








}
