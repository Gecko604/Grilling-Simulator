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

    void Start()
    {
    }
    public void generateOrder(int numOrder)
    {
        //Create a order with given order #
        orderNumber = numOrder;
        //Assign difficulty from score manager 
        difficulty = scoreManager.difficulty;
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

        if (difficulty == 1)
        {
            pattyCookedStates.Add("medium");
        }
        if (difficulty == 2)
        {
            pattyCookedStates.Add("uncooked");
            pattyCookedStates.Add("medium");
            pattyCookedStates.Add("well done");
            pattyCookedStates.Add("overcooked");
        }
        if (difficulty == 3)
        {
            pattyCookedStates.Add("uncooked");
            pattyCookedStates.Add("raw");
            pattyCookedStates.Add("medium");
            pattyCookedStates.Add("well done");
            pattyCookedStates.Add("overcooked");
            pattyCookedStates.Add("burnt");
        }
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
            //Two toppings, one is random
        {
            pattyIngredients.Add("lettuce");
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
        List<string> candidates = new List<string> { "cheese", "lettuce", "tomato", "bun" };

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
