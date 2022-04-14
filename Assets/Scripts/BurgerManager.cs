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

    public LinkedList<GameObject> ingredientList = new LinkedList<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToEndOfList(GameObject ingredient)
    {
        ingredientList.AddLast(ingredient);
    }

    public void RemoveFromEndOfList()
    {
        ingredientList.RemoveLast();
    }

}
