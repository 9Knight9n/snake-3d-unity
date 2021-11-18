using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public Directions direction;
    public Directions oldDirection;
    
    [Range(0f, 1f)] private float _moveAmount;
    protected List<Vector3> directions;
    
    [SerializeField] public GameObject nextNode;
    
    void Start()
    {
        
    }

    protected virtual void Awake()
    {
        _moveAmount = 0.5f;
        Debug.Log(name+" move Amount :"+_moveAmount);
        directions = new List<Vector3>()
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
    
    
    
    protected virtual void ChangeDir(Directions dir)
    {
        oldDirection = direction;
        direction = dir;
    }
    
    protected void Move()
    {
        transform.Translate(directions[(int) direction]);
        if (nextNode != null)
        {
            nextNode.GetComponent<MovableObject>().ChangeDir(oldDirection);
            oldDirection = direction;
            nextNode.GetComponent<MovableObject>().Move();
        }
    }

    protected void Init(Directions dir,Vector3 tra)
    {
        oldDirection = dir;
        direction = dir;
        transform.position = tra;
        if (nextNode != null)
        {
            Vector3 newTra = tra - directions[(int) dir];
            newTra[1] = nextNode.transform.position[1];
            nextNode.GetComponent<MovableObject>().Init(dir,newTra);
        }
    }
    
}
