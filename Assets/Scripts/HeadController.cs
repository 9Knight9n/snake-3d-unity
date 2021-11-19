using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeadController : MovableObject
{


    [Range(0f, 1f)] public float moveFreq;
    public float counter;

    private bool _canChangeDir;


    void Start()
    {
        //Init((Directions)Random.Range(0, (int) Directions.Count),new Vector3());
    }

    protected override void Awake()
    {
        base.Awake();
        counter = 0f;
        _canChangeDir = true;
        direction = (Directions) Random.Range(0, (int) Directions.Count);
        oldDirection = direction;
        Init(direction, transform.position);
    }

    void Update()
    { 
        if (CanMove()) 
            Move();
        if (_canChangeDir)
        {
            if (Input.GetKeyDown(KeyCode.D) && direction!=Directions.Left)
                ChangeDir(Directions.Right);
            if (Input.GetKeyDown(KeyCode.A) && direction!=Directions.Right)
                ChangeDir(Directions.Left);
            if (Input.GetKeyDown(KeyCode.W) && direction!=Directions.Down)
                ChangeDir(Directions.Up);
            if (Input.GetKeyDown(KeyCode.S) && direction!=Directions.Up)
                ChangeDir(Directions.Down);
        }
    }

    protected override void ChangeDir(Directions dir)
    {
        base.ChangeDir(dir);
        _canChangeDir = false;
    }
    
    

    private bool CanMove()
    {
        counter += Time.deltaTime;
        if (counter >= moveFreq)
        {
            counter = 0f;
            _canChangeDir = true;
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(Tags.DeathZone.ToString()))
        {
            CustomEventSystem.current.onEndGame.Invoke();
            Time.timeScale = 0;
        }

        if (other.gameObject.CompareTag(Tags.Body.ToString()))
        {
            CustomEventSystem.current.onEndGame.Invoke();
            Time.timeScale = 0;
        }
    }
}
