﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    public Directions direction ;//= Random.Range(0, (int) Directions.Count);
    [Range(0f, 1f)] public float moveFrequency;
    [Range(0f, 1f)] public float moveAmount;
    [SerializeField] public GameObject bodyPrefab;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveAmount, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveAmount, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, moveAmount);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -moveAmount);
        }
    }
}
