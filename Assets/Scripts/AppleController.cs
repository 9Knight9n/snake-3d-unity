using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleController : FoodInstanceController
{
    private float _maxX;
    private float _maxY;
    private float _minX;
    private float _minY;
    // Start is called before the first frame update
    void Start()
    {
        GameObject platform = GameObject.FindGameObjectWithTag(Tags.Platform.ToString());
        
        Renderer rend = platform.GetComponent<Renderer>();
        Vector3 max = rend.bounds.max;
        Vector3 min = rend.bounds.min;
        _maxX = max[0];
        _minX = min[0];
        _maxY = max[2];
        _minY = min[2];
        
        Debug.Log("_maxX "+_maxX);
        Debug.Log("_minX "+_minX);
        Debug.Log("_maxY "+_maxY);
        Debug.Log("_minY "+_minY);
        transform.position = GetNewPlace();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetNewPlace()
    {
        return new Vector3(Random.Range(_minX, _maxX), transform.position[1], Random.Range(_minY, _maxY));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Head.ToString()) || other.gameObject.CompareTag(Tags.Body.ToString()) )
        {
            transform.position = GetNewPlace();
        }
    }
}
