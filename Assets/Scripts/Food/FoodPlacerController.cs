using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlacerController : MonoBehaviour
{
    public float halfAppleCounter;
    public float bigAppleCounter;
    [Range(0f, 20f)] public float halfAppleFreqMax;
    [Range(0f, 20f)] public float bigAppleFreqMax;

    [SerializeField] private GameObject bigApplePrefab;
    private GameObject bigApple;
    [SerializeField] private GameObject halfApplePrefab;
    private GameObject halfApple;

    private float _halfAppleFreq;
    private float _bigAppleFreq;
    

    // Start is called before the first frame update
    void Start()
    {
        halfAppleFreqMax = 6f;
        bigAppleFreqMax = 6f;
        halfAppleCounter = 0f;
        bigAppleCounter = 0f;
        _halfAppleFreq = Random.Range(halfAppleFreqMax/2 , 2*halfAppleFreqMax);
        _bigAppleFreq = Random.Range(bigAppleFreqMax/2 , 2*bigAppleFreqMax);
        bigApple = Instantiate(bigApplePrefab);
        bigApple.transform.position = new Vector3(0f, 1.23f, 0f);
        bigApple.SetActive(false);
        halfApple = Instantiate(halfApplePrefab);
        halfApple.transform.position = new Vector3(0f, 1.22f, 0f);
        halfApple.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (halfApple.activeSelf)
        {
            if (ShouldDeactivateHalfApple())
            {
                halfApple.SetActive(false);
            }
        }
        else
        {
            if (ShouldDeployHalfApple())
            {
                halfApple.SetActive(true);
                halfApple.GetComponent<FoodInstanceController>().ChangePlace();
            }
        }
        
        if (bigApple.activeSelf)
        {
            if (ShouldDeactivateBigApple())
            {
                bigApple.SetActive(false);
            }
        }
        else
        {
            if (ShouldDeployBigApple())
            {
                bigApple.SetActive(true);
                bigApple.GetComponent<FoodInstanceController>().ChangePlace();
            }
        }
        

    }

    private bool ShouldDeployHalfApple()
    {
        halfAppleCounter += Time.deltaTime;
        if (halfAppleCounter >= _halfAppleFreq)
        {
            halfAppleCounter = 0f;
            return true;
        }
        return false;
    }
    private bool ShouldDeployBigApple()
    {
        bigAppleCounter += Time.deltaTime;
        if (bigAppleCounter >= _bigAppleFreq)
        {
            bigAppleCounter = 0f;
            return true;
        }
        return false;
    }
    private bool ShouldDeactivateHalfApple()
    {
        halfAppleCounter += Time.deltaTime;
        if (halfAppleCounter >= halfAppleFreqMax)
        {
            halfAppleCounter = 0f;
            return true;
        }
        return false;
    }
    private bool ShouldDeactivateBigApple()
    {
        bigAppleCounter += Time.deltaTime;
        if (bigAppleCounter >= bigAppleFreqMax)
        {
            bigAppleCounter = 0f;
            return true;
        }
        return false;
    }
}
