using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrder : MonoBehaviour
{

    public int difficulty = 1;

    private int orderNumber = 0;
    [SerializeField] private string patty;
    [SerializeField] private List<string> ingredients;
    // Generate a random order based off difficulty - 1 = easy, 2 = medium, 3 = hard
    void Start()
    {
        //Get difficulty score    
        createPatty(1);


    }

    public void createPatty(int numOrder)
    {
        //Create a order with order #, patty and ingredients
        orderNumber = numOrder;

        patty = determinePatty();
        ingredients = determineIngredients();

        PrintDetails();
    }

    public void PrintDetails()
    {
        string ingredientList = "";


        foreach (string ele in ingredients)
        {
            ingredientList += $"{ele}";
        }
        
        Debug.Log($"-----------------\n Order Number: {orderNumber}\n Patty Cooked Value: {patty}\n Ingredients: {ingredientList}\n-----------------\n");
    }


    private string determinePatty()
    {
        List<string> pattyCookedStates = new List<string>();

        // Generate a random patty requirement based off difficulty - 1 = easy, 2 = medium, 3 = hard

        if (difficulty == 1)
        {
            pattyCookedStates.Add("Medium Rare");
        }
        if (difficulty == 2)
        {
            pattyCookedStates.Add("Medium Rare");
            pattyCookedStates.Add("Well Done");
        }
        if (difficulty == 3)
        {
            pattyCookedStates.Add("Raw");
            pattyCookedStates.Add("Medium Rare");
            pattyCookedStates.Add("Well Done");
            pattyCookedStates.Add("Overcooked");
        }
        int num = UnityEngine.Random.Range(0, pattyCookedStates.Count - 1);
        //Debug.Log($"Index: {num}");
        //Debug.Log($"Total List: {pattyCookedStates.ToString()}");
        string selectedPatty = pattyCookedStates[num];
       // Debug.Log($"Patty State: {selectedPatty}");
        //Pick a random patty from the list of possible states

        return selectedPatty;
    }

    private List<string> determineIngredients()
    {
        List<string> pattyIngredients = new List<string>();

        // Generate ingredient requirements based off difficulty - 1 = easy, 2 = medium, 3 = hard
        if (difficulty == 1)
        {
            pattyIngredients.Add("Bun");
        }
        if (difficulty == 2)
        {
            pattyIngredients.Add("Bun");
            pattyIngredients.Add("Cheese");
        }
        if (difficulty == 3)
        {
            pattyIngredients.Add("Bun");
            pattyIngredients.Add("Cheese");
            pattyIngredients.Add("Tomato");
            pattyIngredients.Add("Lettuce");
        }

        //If burgers have more than patty and bun
        if (difficulty > 1)
        {
            //Generate random index to remove
            int removedIndex = UnityEngine.Random.Range(-1, pattyIngredients.Count);

            //Debug.Log($"Removed Index: {removedIndex}");
            //if index == -1, then remove none
            if (removedIndex == -1) { return ingredients;}

            //otherwise, remove at index 
            printList(pattyIngredients);
            pattyIngredients.RemoveAt(removedIndex);
            printList(pattyIngredients);

        }
        //return ingredient list
        return pattyIngredients;
    }

    public string GetPatty()
    {
        return patty;
    }

    public List<string> GetIngredients()
    {
        return ingredients;
    }
    
    public int GetOrderNumber()
    {
        return orderNumber;
    }

    private void printList(List<string> list)
    {
        foreach (string ele in list)
        {
            //Debug.Log(ele);
        }
    }
}
