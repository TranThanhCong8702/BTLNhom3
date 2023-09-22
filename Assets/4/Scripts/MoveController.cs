using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public bool isMove = false;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Vector3 oldPos;
    [SerializeField] private float speed;
    [SerializeField] private float maxRange;
    
    private void Start()
    {
        oldPos = transform.position;
    }

    void Update()
    {
        if (isMove)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
        
        if (Mathf.Abs(transform.position.z - oldPos.z) > maxRange)
        {
            transform.position = oldPos;
        }
    }
}
