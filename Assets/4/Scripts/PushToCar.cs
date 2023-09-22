using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushToCar : MonoBehaviour
{
    private bool isIn;
    [SerializeField] private Transform cameraRig;
    [SerializeField] public Transform avatarObj;
    public Vector3 posPlayer = new Vector3(11f, -18f, 17f);
    public GameObject carParent;
    public BoxCollider cols;
    public GameObject dollar;
    public bool canShoot;

    public void ResetShoot()
    {
        if (canShoot == false)
        {
            canShoot = true;
        }
    }

    public void PushIn()
    {
        var transform1 = transform;
        cameraRig.parent = carParent.transform;
        cameraRig.localPosition = posPlayer;
        isIn = true;
        cols.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            carParent = other.gameObject;
            PushIn();
            carParent.GetComponent<MoveController>().isMove = true;
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(ResetShoot), 0.2f, 0.2f);
    }

    public void PushOut()
    {
        isIn = false;
        cameraRig.parent = null;
        carParent.GetComponent<MoveController>().isMove = false;
        cameraRig.position += new Vector3(5, 0, 0);
        cols.enabled = true;
    }

    void Update()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                canShoot = false;
                Instantiate(dollar, transform.GetChild(0).GetChild(0));
            }
        }

        if (transform.GetChild(1).gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                transform.GetChild(1).GetComponent<DolarController>().enabled = true;
                transform.GetChild(1).GetComponent<DolarController>().rgb.useGravity = true;
            }
        }

        if (isIn)
        {
            avatarObj.localPosition = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            PushOut();
        }
    }
}