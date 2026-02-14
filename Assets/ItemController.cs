using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public bool isHeld;
    public Transform holderPosition;

    public float rotationSpeed = 200f;
    public string itemName = "???";
    // Start is called before the first frame update
    void Start()
    {
        holderPosition = GameObject.Find("PickUpHolder").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            transform.position = holderPosition.position;

            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, -mouseX, Space.World);
            transform.Rotate(Vector3.right, mouseY, Space.World);
        }
        else
        {

        }
    }
}
