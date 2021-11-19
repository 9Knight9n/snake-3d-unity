using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "FoodConfig")]
public class FoodConfig : ScriptableObject
{
    public string foodName;
    public int lengthAdded;
    public int score;   
}