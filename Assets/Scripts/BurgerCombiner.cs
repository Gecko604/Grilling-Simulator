using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class BurgerCombiner : MonoBehaviour
{
    // remove from list as objects are removed, keep only top object interactable and removable

    public Transform parent;
    public Material clear;
    public Material clearGreen;
    public Material highLightMaterial;
    [CanBeNull] public BurgerManager burgerManager;
    private Ingredient ingredient;
    public int numIngredients;

    //Location Data
    public float ingredientoffset;
    private Vector3 centerlocation;

    //public GameObject secondfromTopObject;
    public float timer;

    public List<GameObject> ingredientList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Startup of BurgerCombiner");
        ingredientoffset = 0.01f;
        centerlocation = this.transform.position;
        numIngredients = 0;
        //secondfromTopObject = null;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 2.0f)
        {
            timer += timer + Time.deltaTime;
        }
        centerlocation = this.transform.position;

        //check to see completion of burger
        if (numIngredients > 5 || (burgerManager.hasTopBun && burgerManager.hasBottomBun)) 
        {
            //disable zone, 
            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;

            Debug.Log("Filled plate with ingredients/finished burger");
        }
        else if (numIngredients < 6) 
        {
            //set  material to transparent green and reenable trigger/collider' or we could just have them start over?
            this.GetComponent<Collider>().enabled = true;
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //check tag or name of object for type of ingredient
        GameObject ingredient = other.gameObject;
        //get object name
        String name = ingredient.name;
        
        if (timer >= 2.0f)
        {
            timer = 0.0f;
            if (ingredient.CompareTag("Burger"))
            {
                //talk to manager script to add gameobject to list for score measuring
                AddToManagerLists(ingredient, name);
                burgerManager.hasPatty = true;
                burgerManager.numberOfPatties++;
                numIngredients++;

                //sets position and parent
                SetPositionAndParent(ingredient);

                //move zone up
                MoveZoneUp();
                ingredientoffset = 0.02f;
            }

            if (ingredient.CompareTag("Lettuce"))
            {
                //talk to manager script to add gameobject to list for score measuring
                AddToManagerLists(ingredient, name);
                burgerManager.hasLettuce = true;
                burgerManager.numberOfLettucePieces++;
                
                numIngredients++;

                //sets position and parent
                SetPositionAndParent(ingredient);

                //move zone up
                MoveZoneUp();
                ingredientoffset = 0.02f;
            }

            if (ingredient.CompareTag("Cheese"))
            {
                //talk to manager script to add gameobject to list for score measuring
                AddToManagerLists(ingredient, name);
                burgerManager.hasCheese = true;
                burgerManager.numberOfCheeseSlices++;
                numIngredients++;

                //sets position and parent
                SetPositionAndParent(ingredient);

                //move zone up
                MoveZoneUp();
                ingredientoffset = 0.02f;
            }

            //Top Bun
            if (ingredient.CompareTag("TopBun"))
            {
                //talk to manager script to add gameobject to list for score measuring
                AddToManagerLists(ingredient, name);
                burgerManager.hasTopBun = true;
                
                numIngredients++;

                //sets position and parent
                SetPositionAndParent(ingredient);

                //move zone up
                MoveZoneUp();
                ingredientoffset = 0.02f;
            }

            if (ingredient.CompareTag("BottomBun"))
            {
                //talk to manager script to add gameobject to list for score measuring
                AddToManagerLists(ingredient, name);
                burgerManager.hasBottomBun = true;
                numIngredients++;

                //sets position and parent
                SetPositionAndParent(ingredient);

                //move zone up
                MoveZoneUp();
                ingredientoffset = 0.02f;
            }
        }
    }

    void MoveZoneUp()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + ingredientoffset, this.transform.position.z);
    }

    void MoveZoneDown()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - ingredientoffset, this.transform.position.z);
    }

    //sets this position to position of zone
    void moveToCenter(GameObject other)
    {
        other.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    //have some system if the top ingredient is grabbed move zone down and remove that ingredient from the list




    //sets parent, makes object kinematic, and moves to center of trigger zone
    void SetPositionAndParent(GameObject other)
    {
        other.transform.position = centerlocation;
        other.GetComponent<Rigidbody>().isKinematic = true;
        other.transform.rotation = parent.rotation;
        other.transform.SetParent(parent);
    }


    /*//adds gameobject reference to end of linked list
    public void AddToEndOfList(GameObject ingredient)
    {
        int listlength = ingredientList.Count;
        if (listlength >= 1)
        {//grab previous ingredient and disable interactable
            GameObject previousObject = ingredientList[listlength - 1];
            previousObject.GetComponent<Interactable>().enabled = false;
        }
        //add ingredient to end of list
        ingredientList.Add(ingredient);

    }

    //removes object reference from list
    public void RemoveFromEndOfList()
    {
        int listlength = ingredientList.Count;
        if (listlength >= 2)
        {
            GameObject previousObject = ingredientList[listlength - 2];
            previousObject.GetComponent<Interactable>().enabled = true;
            ingredientList.RemoveAt(listlength - 1);
        }
        if (listlength == 1)
        {
            ingredientList.RemoveAt(0);
        }
        
    }*/


    void AddToManagerLists(GameObject ingredient, String name)
    {
        burgerManager.AddToEndOfList(ingredient);
        burgerManager.AddNameToEndOfList(name);
    }
}

