using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BurgerManager : MonoBehaviour
{
    [Header("Required Components")]
    [SerializeField] private List<string> ingredientNames = new List<string>();
    [SerializeField] private List<GameObject> ingredientPrefabs = new List<GameObject>();
    [SerializeField] private BoxCollider ingredientHitbox = null;
    [SerializeField] private Vector3 ingredientPlacePosition = new Vector3();

    [Header("Burger Ingredients")]
    [SerializeField] private List<string> ingredientNameList = new List<string>();
    [SerializeField] private List<GameObject> ingredientObjectList = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object is an ingredient
        if (other.gameObject.tag == "BurgerIngredient")
        {
            
        }
    }

    private int getPrefabIndex(string ingredientName)
    {
        return 0; // change
    }
    private void addBottomBun(GameObject ingredient)
    {
        // Bind ingredient to plate
        ingredient.transform.parent = gameObject.transform;

        // Reset position to place
        ingredient.transform.position = ingredientPlacePosition;

        //Add the ingredient to a list
        ingredientNameList.Add("bottomBun");
        ingredientObjectList.Add(ingredient);
        //Loop through list, if not topmost ingredient disable interaction on the ingredient

    }

    private void disableInteraction()
    {
        for (int i = 0; i < ingredientObjectList.Count - 1; i++)
        {
           // if (ingredientObjectList[i].GetComponent<>)
            //{

            //}
        }
    }
    private void addTopBun(GameObject ingredient)
    {

    }

    private void incrementPosition()
    {
        ingredientPlacePosition = new Vector3(ingredientPlacePosition.x, ingredientPlacePosition.y + 0.05f, ingredientPlacePosition.z);
    }
    public void decrementPosition()
    {
        ingredientPlacePosition = new Vector3(ingredientPlacePosition.x, ingredientPlacePosition.y - 0.05f, ingredientPlacePosition.z);
    }
}


