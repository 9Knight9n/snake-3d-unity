﻿using System.Collections;
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
    //public UnityEvent OnCloneStickyPlatformEnter;
    public MyIntEvent onFoodCollect;
    //public MyTextEvent onHintChange;
    //public MyTextEvent onEndGame;

    void Awake()
    {
        current = this;
        //OnCloneStickyPlatformEnter = new UnityEvent();
        onFoodCollect = new MyIntEvent();
        //onHintChange = new MyTextEvent();
        //onEndGame = new MyTextEvent();
    }
}