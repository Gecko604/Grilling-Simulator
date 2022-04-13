using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GrillingObjects", menuName = "ScriptableObjects/OrderObject", order = 1)]
public class OrderObject : ScriptableObject
{
    public int orderNumber;

    public int difficulty;
    public string pattyType;
    public List<string> ingredients;

}

