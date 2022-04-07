using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCombiner : MonoBehaviour
{
    public Transform parent;


    [Header("Ingredients of Burger")]
    public Boolean hasLettuce;
    public int numberOfLettucePieces;
    public Boolean hasCheese;
    public int numberOfCheeseSlices;
    public Boolean hasTopBun;
    public int topBunPosition;
    public Boolean hasBottomBun;
    public int bottomBunPosition;
    
    
    public int numberOfIngredients;
    public int ingredientoffset;
    


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Startup of BurgerCombiner");
        hasLettuce = false;
        numberOfLettucePieces = 0;
        hasCheese = false;
        numberOfCheeseSlices = 0;
        hasTopBun = false;
        hasBottomBun = false;
        ingredientoffset = 0;
    }


    // Update is called once per frame
    void Update()
    {
        //if both topbun and bottombun are in burger or surpass 5 ingredients, stop allowing combination and activate throwable/interactable for whole object
        if (numberOfIngredients >= 5 || (hasTopBun && hasBottomBun))
        {
            //disable the ability for ingredients to be added until top ingredient is removed
        }//otherwise maintain trigger zone or trigger ability of object
        else
        {

        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject ingredient = other.gameObject;
        if (ingredient.CompareTag("Lettuce"))
        {
            ingredient.transform.SetParent(this.transform);
            //reference other script to state position and confirm lettuce is on burger
        }
        if (ingredient.CompareTag("Cheese"))
        {
            ingredient.transform.SetParent(this.transform);
            //reference other script to state position and confirm lettuce is on burger
        }
        if (ingredient.CompareTag("BottomBun"))
        {
            ingredient.transform.SetParent(this.transform);
            //reference other script to state position and confirm lettuce is on burger
        }
        if (ingredient.CompareTag("TopBun"))
        {
            ingredient.transform.SetParent(this.transform);
            //reference other script to state position and confirm lettuce is on burger
        }
        if (ingredient.CompareTag("Burger"))
        {
            ingredient.transform.SetParent(this.transform);
            //reference other script to state position and confirm lettuce is on burger
        }

    }

}

