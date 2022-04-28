using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BurgerManager : MonoBehaviour
{
    [CanBeNull]public BurgerCombiner burgerCombiner;
    [CanBeNull] public IngredientRemoverBox removerBox;

    [Header("Ingredients of Burger")]
    public Boolean hasTopBun;
    public Boolean hasBottomBun;

    public List<GameObject> ingredientList = new List<GameObject>();
    public List<string> ingredientNameList = new List<string>();
    public int listlength;

    // Update is called once per frame
    void Update()
    {
    }

    //adds gameobject reference to end of list
    public void AddToEndOfList(GameObject ingredient)
    {
        listlength = ingredientList.Count;
        if (listlength >= 1)
        {   //grab previous ingredient and disable interactable
            GameObject previousObject = ingredientList[listlength - 1];
          
            previousObject.GetComponent<Interactable>().enabled = false;
            Destroy(previousObject.GetComponent<Throwable>());
            Destroy(previousObject.GetComponent<Rigidbody>());
        }
        //add ingredient to end of list
        ingredientList.Add(ingredient);
        //move zones up
    } 

    //removes object reference from list
    public void RemoveFromEndOfList()
    {
        listlength = ingredientList.Count;

        if (listlength >= 2)
        {//if object below/before it in list, add interactable back to script
            GameObject previousObject = ingredientList[listlength - 2];
            previousObject.AddComponent<Rigidbody>();
            previousObject.GetComponent<Rigidbody>().isKinematic = false;
            previousObject.AddComponent<Throwable>();
            previousObject.GetComponent<Interactable>().enabled = true;
            
            ingredientList.RemoveAt(listlength - 1);
        }
        if (listlength == 1)
        {
            ingredientList.RemoveAt(0);
        }
        //move zones down
        burgerCombiner.MoveZoneDown();
        removerBox.MoveAndExitScaleZoneDown();
    }

    //adds name of object to list
    public void AddNameToEndOfList(String name)
    {
        //add reference to ingredient script to get name String?
        if (!ingredientNameList.Contains(name))
        {
            ingredientNameList.Add(name);
        }
    }

    //remove name from end of list
    public void RemoveNameFromEndOfList()
    {
        Debug.Log("Enter Process to remove last name from name list");
        listlength = ingredientNameList.Count;
        if (listlength >= 1)
        {
            ingredientNameList.RemoveAt(listlength - 1);
        }
    }
}
