using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInstanceController : MonoBehaviour
{
    public FoodConfig config;
    protected float maxX;
    protected float maxY;
    protected float minX;
    protected float minY;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        GameObject platform = GameObject.FindGameObjectWithTag(Tags.Platform.ToString());
        
        Renderer rend = platform.GetComponent<Renderer>();
        Vector3 max = rend.bounds.max;
        Vector3 min = rend.bounds.min;
        maxX = max[0]-2;
        minX = min[0]+2;
        maxY = max[2]-2;
        minY = min[2]+2;
        
        Debug.Log("_maxX "+maxX);
        Debug.Log("_minX "+minX);
        Debug.Log("_maxY "+maxY);
        Debug.Log("_minY "+minY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected Vector3 GetNewPlace()
    {
        return new Vector3(Random.Range(minX, maxX), transform.position[1], Random.Range(minY, maxY));
    }

    public void ChangePlace()
    {
        transform.position = GetNewPlace();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Head.ToString()))
        {
            CustomEventSystem.current.onFoodCollect.Invoke(config.lengthAdded);
            CustomEventSystem.current.onScoreChange.Invoke(config.score);
            GameObject.FindGameObjectWithTag(tag).SetActive(false);
        }
        else if (other.gameObject.CompareTag(Tags.Body.ToString()))
        {
            ChangePlace();
        }
    }
}
