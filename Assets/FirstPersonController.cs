using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed;
    public float jumpForce;

    public LayerMask groundMask;
    public Rigidbody rb;

    public bool itemHeld;
    public GameObject currentItem;
    public Transform cameraPosition;
    public LayerMask interactMask;

    public bool isInspecting;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isInspecting)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector3(x, 0, z);
            transform.Translate(speed * Time.deltaTime * moveDirection);
        }


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!itemHeld)
            {
                if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out RaycastHit reach, 1.5f, interactMask))
                {
                    itemHeld = true;
                    isInspecting = true;
                    currentItem = reach.collider.gameObject; //set currentItem to the object that the ray collides with
                    currentItem.GetComponent<ItemController>().isHeld = true; //set isHeld bool of currentItem to true
                    currentItem.GetComponent<Rigidbody>().useGravity = false; //set gravity usage of the currentItem to false
                }
            }
            else
            {
                itemHeld = false; //sets itemHeld to false
                isInspecting = false;
                currentItem.GetComponent<ItemController>().isHeld = false; // get the itemController from the currentitem and set isHeld to false
                currentItem.GetComponent<Rigidbody>().useGravity = true; // get rigidbody component from currentitem and set gravity usage to true
                currentItem = null; //clear current item by setting it to null
            }
        }
    }
    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position - new Vector3(0, .9f, 0), Vector3.down,
            out RaycastHit hit, .2f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
