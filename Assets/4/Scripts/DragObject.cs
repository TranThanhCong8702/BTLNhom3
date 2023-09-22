using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    [SerializeField] private Rigidbody objectDrag;
    [SerializeField] private bool isHere = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Gach") && Input.GetMouseButton(0))
        {
            objectDrag = other.gameObject.GetComponent<Rigidbody>();
            objectDrag.isKinematic = true;
            objectDrag.GetComponent<Collider>().enabled = false;
            isHere = true;
        }
    }


    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isHere = false;
            objectDrag.isKinematic = false;
            objectDrag.GetComponent<Collider>().enabled = true;
            objectDrag = null;
        }
    }

    private void LateUpdate()
    {
        if (isHere)
        {
            objectDrag.position = transform.position;
            objectDrag.rotation = transform.rotation;
        }
    }
}
