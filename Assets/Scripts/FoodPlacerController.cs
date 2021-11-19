using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlacerController : MonoBehaviour
{
    public float halfAppleCounter;
    public float bigAppleCounter;
    [Range(0f, 20f)] public float halfAppleFreqMax;
    [Range(0f, 20f)] public float bigAppleFreqMax;

    private float halfAppleFreq;
    private float bigAppleFreq;


    // Start is called before the first frame update
    void Start()
    {
        halfAppleCounter = 0f;
        bigAppleCounter = 0f;
        halfAppleFreq = Random.Range(halfAppleFreqMax / 2, halfAppleFreqMax);
        bigAppleFreq = Random.Range(bigAppleFreqMax / 2, bigAppleFreqMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldDeployHalfApple())
            DeployHalfApple();
        if (ShouldDeployBigApple())
            DeployBigApple();
        

    }

    private void DeployHalfApple()
    {
        
    }

    private void DeployBigApple()
    {
        
    }
    
    private bool ShouldDeployHalfApple()
    {
        halfAppleCounter += Time.deltaTime;
        if (halfAppleCounter >= halfAppleFreq)
        {
            halfAppleCounter = 0f;
            return true;
        }
        return false;
    }
    private bool ShouldDeployBigApple()
    {
        bigAppleCounter += Time.deltaTime;
        if (bigAppleCounter >= bigAppleFreq)
        {
            bigAppleCounter = 0f;
            return true;
        }
        return false;
    }
    
}
