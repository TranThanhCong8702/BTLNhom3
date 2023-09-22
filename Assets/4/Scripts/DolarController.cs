using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolarController : MonoBehaviour
{
    public Rigidbody rgb;
    public float force;
    private void OnEnable()
    {
        rgb.velocity =  transform.right*force;
        StartCoroutine(DisaBling());
    }

    public IEnumerator DisaBling()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
