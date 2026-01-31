using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed;

    public Rigidbody rb;

    public bool itemHeld;
    public GameObject currentItem;
    public Transform cameraPosition;
    public LayerMask interactMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); 
        float z = Input.GetAxisRaw("Vertical"); 

        moveDirection = new Vector3(x, 0, z); 
        transform.Translate(speed * Time.deltaTime * moveDirection);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!itemHeld)
            {
                if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out RaycastHit reach, 1.5f, interactMask))
                {
                    itemHeld = true; //sets itemHeld to true
                    currentItem = reach.collider.gameObject; //set currentItem to the object that the ray collides with
                    currentItem.GetComponent<ItemController>().isHeld = true; //set isHeld bool of currentItem to true
                    currentItem.GetComponent<Rigidbody>().useGravity = false; //set gravity usage of the currentItem to false
                }
            }
            else
            {
                itemHeld = false; //sets itemHeld to false
                currentItem.GetComponent<ItemController>().isHeld = false; // get the itemController from the currentitem and set isHeld to false
                currentItem.GetComponent<Rigidbody>().useGravity = true; // get rigidbody component from currentitem and set gravity usage to true
                currentItem = null; //clear current item by setting it to null
            }
        }
    }
}
