using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerManager : MonoBehaviour
{
    public GameObject triggerZone;

    [Header("Ingredients of Burger")]
    public Boolean hasLettuce;
    public int numberOfLettucePieces;
    public Boolean hasCheese;
    public int numberOfCheeseSlices;
    public Boolean hasPatty;
    public int numberOfPatties;
    public Boolean hasTopBun;
    public Boolean hasBottomBun;
    public int numberOfIngredients;

    public List<GameObject> ingredientList = new List<GameObject>();
    public List<string> ingredientNameList = new List<string>();
    public int listLength;


    // Update is called once per frame
    void Update()
    {
    }

    //adds gameobject to end of linked list
    public void AddToEndOfList(GameObject ingredient)
    {
        int listlength = ingredientList.Count;
        if (listLength >= 1)
        {//grab previous ingredient and siable interactable
            GameObject previousObject = ingredientList[listLength - 1];
            
        }
        //add ingredient to end of list
        ingredientList.Add(ingredient);

    }


    public void RemoveFromEndOfList()
    {
        int listlength = ingredientList.Count;
        ingredientList.RemoveAt(listlength - 1);
        //if object below/before it in list, add interactable back to script
    }

}
