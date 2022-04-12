using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BurgerCombiner : MonoBehaviour
{
    public Transform parent;
    public GameObject nextZone;

    // Develop better system for moving trigger zone up and add ingredients to list, remove from list as objects are removed, keep only top object interactable and removable


    [Header("Ingredients of Burger")]
    public Boolean hasLettuce;
    public int numberOfLettucePieces;
    public Boolean hasCheese;
    public int numberOfCheeseSlices;
    public Boolean hasPatty;
    public int numberOfPatties;
    public Boolean hasTopBun;
    public int topBunPosition;
    public Boolean hasBottomBun;
    public int bottomBunPosition;
    
    public int numberOfIngredients;
    public float ingredientoffset;
    public Boolean hasIngredient;
    private Vector3 centerlocation;

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
        ingredientoffset = 0.01f;
    }


    // Update is called once per frame
    void Update()
    {
        centerlocation = new Vector3(this.transform.position.x, this.transform.position.y + ingredientoffset,
            this.transform.position.z);
        //if both topbun and bottombun are in burger or surpass 5 ingredients, stop allowing combination and activate throwable/interactable for whole object
        if (numberOfIngredients >= 5 || (hasTopBun && hasBottomBun))
        {
            //disable the ability for ingredients to be added until top ingredient is removed
        }//otherwise maintain trigger zone or trigger ability of object
        else
        {

        }

        if (hasIngredient)
        {
            nextZone.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject ingredient = other.gameObject;
        if (ingredient.CompareTag("Ingredient"))
        {
            ingredient.transform.position = centerlocation;
            ingredient.transform.SetParent(this.transform);
            hasIngredient = true;
            hasPatty = true;
            ingredient.GetComponent<Rigidbody>().isKinematic = true;
            //reference other script to state position and confirm lettuce is on burger
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject ingredient = other.gameObject;
        if (ingredient.CompareTag("Ingredient"))
        {
            ingredient.transform.SetParent(null);
            ingredient.GetComponent<Rigidbody>().isKinematic = false;
            hasIngredient = false;
            hasPatty = false;
        }
    }
}

