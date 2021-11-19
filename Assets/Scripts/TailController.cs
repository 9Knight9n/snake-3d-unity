using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailController : MovableObject
{
    [SerializeField] public GameObject preNode;
    [SerializeField] public GameObject bodyPrefab;
    void Start()
    {
        CustomEventSystem.current.onFoodCollect.AddListener(AddNode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddNode(int addedLength)
    {
        for (int i = 0; i < addedLength; i++)
        {
            GameObject tailNode = preNode.GetComponent<MovableObject>().nextNode;
            GameObject newNode = Instantiate(bodyPrefab);
            newNode.transform.SetParent(GameObject.FindGameObjectWithTag(Tags.Snake.ToString()).transform,false);
            newNode.transform.position = transform.position;
            newNode.GetComponent<MovableObject>().direction = direction;
            newNode.GetComponent<MovableObject>().oldDirection = oldDirection;
            transform.position -= directions[(int) direction];
        
            preNode.GetComponent<MovableObject>().nextNode = newNode;
            newNode.GetComponent<MovableObject>().nextNode = tailNode;
            preNode = newNode;
        }
    }

}
