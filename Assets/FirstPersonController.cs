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

    public GMScript gm;

    [Header("Movement Speeds")]
    public float normalSpeed;
    public float walkSpeed;   // slower speed when holding Shift

    [Header("Crouch")]
    public float crouchHeight = 0.5f;
    public float normalHeight = 1f;
    private Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isInspecting)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector3(x, 0, z).normalized;

            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? walkSpeed : normalSpeed;

            Vector3 move = transform.TransformDirection(moveDirection) * currentSpeed;
            rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
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
        if (Input.GetKey(KeyCode.C))
        {
            // Crouching
            transform.localScale = new Vector3(originalScale.x, crouchHeight, originalScale.z);
        }
        else
        {
            // Return to normal
            transform.localScale = originalScale;
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

    private void OnTriggerEnter(Collider other)
    {
        gm.namePanel.SetActive(true);
        gm.flashlightPanel.SetActive(true);
        gm.StartFlashlightText();
    }
    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(gm.TypeText());
        gm.flashlightText.text = gm.lines1[gm.index1];
        gm.dialougePanel.SetActive(false);
        gm.namePanel.SetActive(false);
        gm.flashlightText.text = string.Empty;
        gm.flashlightPanel.SetActive(false);
    }
}
