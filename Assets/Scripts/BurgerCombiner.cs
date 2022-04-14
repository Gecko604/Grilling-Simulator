using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class BurgerCombiner : MonoBehaviour
{
    // Develop better system for moving trigger zone up and add ingredients to list,
    // remove from list as objects are removed, keep only top object interactable and removable

    public Transform parent;
    public GameObject parentGameObject;
    public Material clear;
    public Material clearGreen;
    [CanBeNull] public BurgerManager burgerManager;

    public int numberOfIngredients;
    public float ingredientoffset;
    private Vector3 centerlocation;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Startup of BurgerCombiner");
        ingredientoffset = 0.01f;
        centerlocation = this.transform.position;
        numberOfIngredients = 0;
    }

    // Update is called once per frame
    void Update()
    {
        centerlocation = this.transform.position;
        if (numberOfIngredients > 6 || (burgerManager.hasTopBun && burgerManager.hasBottomBun)) 
        {
            //disable zone, 
            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;

            Debug.Log("Filled plate with ingredients/finished burger");

        }
        else if (numberOfIngredients <= 5) 
        {
            //set  material to transparent green and reenable trigger/collider'
            this.GetComponent<Collider>().enabled = true;
            this.GetComponent<MeshRenderer>().enabled = true;

        }
        //if numofIngredients is > 6 and or a top bun and bottom bun are together, consider it a finished burger and diasble trigger zone/make object clear
    }

    void OnTriggerEnter(Collider other)
    {
        //check tag or name of object for type of ingredient
        GameObject ingredient = other.gameObject;
        //grab ingredient script


        if (ingredient.CompareTag("Burger"))
        {
            //talk to manager script to add gameobject to list for score measuring
            burgerManager.AddToEndOfList(ingredient);
            burgerManager.hasPatty = true;
            burgerManager.numberOfPatties++;
            numberOfIngredients++;

            //sets position and parent
            ingredient.transform.position = centerlocation;
            ingredient.transform.SetParent(parent);
            ingredient.GetComponent<Rigidbody>().isKinematic = true;

            //move zone up
            MoveZoneUp();
            ingredientoffset = 0.02f;
        }

        if (ingredient.CompareTag("Lettuce"))
        {
            //talk to manager script to add gameobject to list for score measuring
            burgerManager.AddToEndOfList(ingredient);
            burgerManager.hasLettuce = true;
            burgerManager.numberOfLettucePieces++;
            numberOfIngredients++;

            //sets position and parent
            ingredient.transform.position = centerlocation;
            ingredient.transform.SetParent(parent);
            ingredient.GetComponent<Rigidbody>().isKinematic = true;

            //move zone up
            MoveZoneUp();
            ingredientoffset = 0.02f;
        }

        if (ingredient.CompareTag("Cheese"))
        {
            //talk to manager script to add gameobject to list for score measuring
            burgerManager.AddToEndOfList(ingredient);
            burgerManager.hasCheese = true;
            burgerManager.numberOfCheeseSlices++;
            numberOfIngredients++;

            //sets position and parent
            ingredient.transform.position = centerlocation;
            ingredient.transform.SetParent(parent);
            ingredient.GetComponent<Rigidbody>().isKinematic = true;

            //move zone up
            MoveZoneUp();
            ingredientoffset = 0.02f;
        }
        //Top Bun
        if (ingredient.CompareTag("TopBun"))
        {
            //talk to manager script to add gameobject to list for score measuring
            burgerManager.AddToEndOfList(ingredient);
            burgerManager.hasTopBun = true;
            numberOfIngredients++;

            //sets position and parent
            ingredient.transform.position = centerlocation;
            ingredient.transform.SetParent(parent);
            ingredient.GetComponent<Rigidbody>().isKinematic = true;

            //move zone up
            MoveZoneUp();
            ingredientoffset = 0.02f;
        }

        if (ingredient.CompareTag("BottomBun"))
        {
            //talk to manager script to add gameobject to list for score measuring
            burgerManager.AddToEndOfList(ingredient);
            burgerManager.hasBottomBun = true;
            numberOfIngredients++;

            //sets position and parent
            ingredient.transform.position = centerlocation;
            ingredient.transform.SetParent(parent);
            ingredient.GetComponent<Rigidbody>().isKinematic = true;

            //move zone up
            MoveZoneUp();
            ingredientoffset = 0.02f;
        }
    }

    void MoveZoneUp()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + ingredientoffset, this.transform.position.z);
        numberOfIngredients++;
    }

    void MoveZoneDown()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - ingredientoffset, this.transform.position.z);
        numberOfIngredients--;
    }

    //sets this position to position of zone
    void moveToCenter(GameObject other)
    {
        other.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.01f, this.transform.position.z);
    }

    //have some system if the top ingredient is grabbed move zone down and remove that ingredient from the list
    

}

