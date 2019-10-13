using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float sensitivity;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start()
    {
        // Initial orientation
        this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Update orientation
        yaw += sensitivity * Input.GetAxis("Mouse X");
        pitch -= sensitivity * Input.GetAxis("Mouse Y");

        // Clamp pitch:
        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);

        // Wrap yaw:
        while (yaw < 0.0f) {
            yaw += 360.0f;
        }
        while (yaw >= 360.0f) {
            yaw -= 360.0f;
        }

        this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // The player moves left while key A is pressed.
        if (Input.GetKey(KeyCode.A)) {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // The player moves right while key D is pressed.
        if (Input.GetKey(KeyCode.D)) {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        // The player moves forward while key W is pressed.
        if (Input.GetKey(KeyCode.W)) {
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // The player moves backward while key S is pressed.
        if (Input.GetKey(KeyCode.S)) {
            this.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

    }
}
