using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyIntEvent : UnityEvent<int> {}
[System.Serializable]
public class MyTextEvent : UnityEvent<string> {}


public class CustomEventSystem : MonoBehaviour
{
    public static CustomEventSystem current;
    public MyIntEvent onFoodCollect;
    public MyIntEvent onScoreChange;
    public UnityEvent onEndGame;

    void Awake()
    {
        current = this;
        onFoodCollect = new MyIntEvent();
        onScoreChange = new MyIntEvent();
        onEndGame = new UnityEvent();
    }
}