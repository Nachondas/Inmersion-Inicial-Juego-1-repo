using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFPS : MonoBehaviour
{

    public float mouseSensitivity = 500f;
    float xRotation = 0f;
    float yRotation = 0f;
    public Transform player;
    // the clamp is for restricting the mouse movement beyond certain limit
    public float topClamp = -90f;
    public float bottomClamp = 90f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        player.Rotate(Vector3.up * mouseX);

    }
}