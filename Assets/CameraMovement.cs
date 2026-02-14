using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity;
    public float xRot = 0f;
    public float minY = -75;
    public float maxY = 75;

    public bool camLock;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();

        if (!pm.isInspecting)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            MouseLook();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, minY, maxY);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }
}