using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class BurgerCombiner : MonoBehaviour
{
    public Transform parent;
    public Material clear;
    public Material clearGreen;
    public Material highLightMaterial;
    [CanBeNull] public BurgerManager burgerManager;
    [CanBeNull] public IngredientRemoverBox removerBox;
    public int numIngredients;

    //Location Data
    public float ingredientoffset;
    private Vector3 centerlocation;
    private Vector3 startingLocation;

    public GameObject secondfromTopObject;
    public GameObject topObject;
    public float timer;
    private Boolean ingredientInList;

    //public List<GameObject> ingredientList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Startup of BurgerCombiner");

        ingredientoffset = 0.01f;
        centerlocation = this.transform.position;
        startingLocation = this.transform.position;
        numIngredients = 0;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {


        if (timer <= 2.0f)
        {
            timer += timer + Time.deltaTime;
            //ingredientList = burgerManager.ingredientList;
        }
        centerlocation = this.transform.position;

        if (burgerManager.ingredientList.Count == 0)
        {
            removerBox.DisableColliderAndRenderer();
            removerBox.ResetBoxLocation();
            this.transform.position = startingLocation;
        }

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
        
        //check if ingredient interacting is already in list of gameobjects
        ingredientInList = burgerManager.ingredientList.Contains(ingredient);
        //only add item to list if timer is good so no double input and if not already in list of objects
        if (timer >= 2.0f && !ingredientInList)
        {
            timer = 0.0f;
            if (ingredient.CompareTag("Burger"))
            {
                //talk to manager script to add gameobject to list for score measuring
                AddToManagerLists(ingredient, name);
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
    public void MoveZoneUp()
    {
        Debug.Log("Moved Zones Down");
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, this.transform.position.z);
        if (numIngredients != 1)
        {
            removerBox.MoveAndExitScaleZoneUp();
        }
    }

    public void MoveZoneDown()
    {
        Debug.Log("Moving adder Zone down");
        //check if zone would go into/below the surface of plate
        //if now zero ingredients in list, reset to starting position and disable exit box
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - ingredientoffset, this.transform.position.z);
    }

    //sets parent, makes object kinematic, and moves to center of trigger zone
    void SetPositionAndParent(GameObject other)
    {
        other.transform.position = centerlocation;
        other.GetComponent<Rigidbody>().isKinematic = true;
        other.transform.rotation = parent.rotation;
        other.transform.SetParent(parent);
    }

    void AddToManagerLists(GameObject ingredient, String name)
    {
        burgerManager.AddToEndOfList(ingredient);
        burgerManager.AddNameToEndOfList(name);
    }
}

