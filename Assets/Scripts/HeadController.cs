using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeadController : MonoBehaviour
{
    public Directions direction ;
    
    
    [Range(0f, 1f)] public float moveFreq;
    public float counter;
    
    
    [Range(0f, 1f)] public float moveAmount;


    private List<Vector3> _directions;


    [SerializeField] public GameObject bodyPrefab;


    
    
    
    void Start()
    {
        
        counter = 0f;

    }

    private void Awake()
    {
        direction = (Directions)Random.Range(0, (int) Directions.Count);

        _directions = new List<Vector3>()
        {
            new Vector3(0f,0f,moveAmount),
            new Vector3(0f,0f,-moveAmount),
            new Vector3(moveAmount,0f,0f),
            new Vector3(-moveAmount,0f,0f),
        };
    }

    void Update()
    {
        if (CanMove())
            transform.Translate(_directions[(int)direction]);


        if (Input.GetKey(KeyCode.D) && direction!=Directions.Left)
            direction =(Directions.Right);
        if (Input.GetKey(KeyCode.A) && direction!=Directions.Right)
            direction = (Directions.Left);
        if (Input.GetKey(KeyCode.W) && direction!=Directions.Down)
            direction = (Directions.Up);
        if (Input.GetKey(KeyCode.S) && direction!=Directions.Up)
            direction = (Directions.Down);
    }
    

    private bool CanMove()
    {
        counter += Time.deltaTime;
        if (counter >= moveFreq)
        {
            counter = 0f;
            return true;
        }
        return false;
    }
}
