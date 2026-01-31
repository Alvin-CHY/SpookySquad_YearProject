using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public bool isHeld;
    public Transform holderPosition;

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
        }
        else
        {

        }
    }
}
