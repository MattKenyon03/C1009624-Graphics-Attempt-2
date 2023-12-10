using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float moveSpeed;
    public float rotationSpeed;

    void Update()
    {
        //Moves the camera using the WASD keys / arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(moveSpeed * Time.deltaTime * moveDirection);

        //The rotation of the camera in the x axis follows the mouse
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(mouseX * rotationSpeed * Vector3.up);

        //The rotation of the camera in the y axis follows the mouse
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(mouseY * rotationSpeed * Vector3.left);

        //Clamps the z rotation of the camera
        Vector3 currentRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0f);
    }
}
