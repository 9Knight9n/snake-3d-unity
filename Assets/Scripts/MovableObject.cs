using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public Directions direction;
    public Directions oldDirection;
    
    [Range(0f, 1f)] private float _moveAmount;
    private List<Vector3> _directions;
    
    [SerializeField] public GameObject nextNode;
    
    void Start()
    {
        
    }

    protected virtual void Awake()
    {
        _moveAmount = 0.5f;
        Debug.Log(name+" move Amount :"+_moveAmount);
        _directions = new List<Vector3>()
        {
            new Vector3(0f,0f,_moveAmount),
            new Vector3(0f,0f,-_moveAmount),
            new Vector3(_moveAmount,0f,0f),
            new Vector3(-_moveAmount,0f,0f),
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    protected void ChangeDir(Directions dir)
    {
        oldDirection = direction;
        direction = dir;
    }
    
    protected void Move()
    {
        Debug.Log("it's "+name);
        
        transform.Translate(_directions[(int) direction]);
        Debug.Log("it's "+name+" went "+direction);
        if (nextNode != null)
        {
            Debug.Log("it's "+name+" my child is "+nextNode.name);
            nextNode.GetComponent<MovableObject>().ChangeDir(oldDirection);
            Debug.Log("it's "+name+" my child is "+nextNode.name+" told him to go"+oldDirection);
            oldDirection = direction;
            nextNode.GetComponent<MovableObject>().Move();
        }
    }

    protected void Init(Directions dir,Vector3 tra)
    {
        oldDirection = dir;
        direction = dir;
        if (nextNode != null)
        {
            nextNode.GetComponent<MovableObject>().Init(dir,tra);
        }
    }
    
}
