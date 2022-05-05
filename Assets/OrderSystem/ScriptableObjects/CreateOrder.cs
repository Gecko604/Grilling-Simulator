using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrder : MonoBehaviour
{

    [SerializeField] private int queuePosition = -1;


    [SerializeField] public ScoreManager scoreManager;
    [SerializeField] private OrderHandler ticketOrderManager;

    public int difficulty = 1;
    public int orderNumber = -1;

    [SerializeField] private List<string> ingredients;

    [SerializeField] public GameObject orderOwner = null;
    void Start()
    {
    }
    public void generateOrder(int numOrder)
    {
        //Create a order with given order #
        orderNumber = numOrder;
        //Assign a random difficulty
        difficulty = UnityEngine.Random.Range(1, 4);
        //Assign ingredients
        ingredients = determineIngredients();

        // PrintDetails();

        ticketOrderManager.setUpTemplate();
    }

    public void PrintDetails()
    {
        string ingredientList = "";


        foreach (string ele in ingredients)
        {
            ingredientList += $"{ele}\n";
        }
    }


    private string determinePatty()
    {
        List<string> pattyCookedStates = new List<string>();

        // Generate a random patty requirement based off difficulty - 1 = easy, 2 = medium, 3 = hard
        // Append to list of possible states for the difficulty
        if (difficulty == 1)
        {
            pattyCookedStates.Add("medium rare");
        }
        if (difficulty == 2)
        {
            pattyCookedStates.Add("medium rare");
            pattyCookedStates.Add("well done");
        }
        if (difficulty == 3)
        {
            pattyCookedStates.Add("raw");
            pattyCookedStates.Add("medium rare");
            pattyCookedStates.Add("well done");
            pattyCookedStates.Add("overcooked");
        }

        // Pick ONE state from the created list
        int num = UnityEngine.Random.Range(0, pattyCookedStates.Count - 1);

        return pattyCookedStates[num];
    }

    private List<string> determineIngredients()
    {
        List<string> pattyIngredients = new List<string>();

        pattyIngredients.Add("bun");
        // Generate ingredient requirements based off difficulty - 1 = easy, 2 = medium, 3 = hard
        if (difficulty == 1)
            // Only cheese burgers :)
        {
            pattyIngredients.Add("cheese");
        }
        if (difficulty == 2)
            //Two toppings, both random
        {
            pattyIngredients.Add(getRandomIngredient());
            pattyIngredients.Add(getRandomIngredient());
        }
        if (difficulty == 3)
           // Three toppings, one is an additional patty
        {
            pattyIngredients.Add(getRandomIngredient());
            pattyIngredients.Add(determinePatty());
            pattyIngredients.Add(getRandomIngredient());
        }

        //Always end burger on patty and bun
        pattyIngredients.Add(determinePatty());
        pattyIngredients.Add("bun");

        //return ingredient list
        return pattyIngredients;
    }

    private string getRandomIngredient()
    {
        List<string> candidates = new List<string> { "cheese", "lettuce", "tomato" };
        // Allow a patty as an additional ingredient
        if (difficulty == 3)
        {
            candidates.Add(determinePatty());
        }
        int num = UnityEngine.Random.Range(0, candidates.Count);

        return candidates[num];
    }

    public List<string> GetIngredients()
    {
        return ingredients;
    }
    
    public int GetOrderNumber()
    {
        return orderNumber;
    }
}
