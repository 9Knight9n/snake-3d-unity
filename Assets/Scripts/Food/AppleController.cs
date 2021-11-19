using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleController : FoodInstanceController
{
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        transform.position = GetNewPlace();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Head.ToString()) || other.gameObject.CompareTag(Tags.Body.ToString()) )
        {
            transform.position = GetNewPlace();
            if (other.gameObject.CompareTag(Tags.Head.ToString()))
            {
                CustomEventSystem.current.onFoodCollect.Invoke(config.lengthAdded);
                CustomEventSystem.current.onScoreChange.Invoke(config.score);
            }
        }
    }
}
