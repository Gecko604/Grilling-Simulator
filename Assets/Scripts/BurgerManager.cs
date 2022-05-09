using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BurgerManager : MonoBehaviour
{

    [Header("Enabled")]
    public bool active = false;
    [Header("Required Components")]
    [SerializeField] private Mesh pattyMesh = null;


    [Header("Burger Variables")]
    [SerializeField] private GameObject ingredientCandidate = null;
    [SerializeField] private Vector3 ingredientPos = new Vector3(0f, -0.1f, 0f);
    [SerializeField] private GameObject ingredientSpawnShadow;

    [Header("Burger Ingredients")]
    [SerializeField] public List<string> ingredientNameList = new List<string>();
    [SerializeField] private List<GameObject> ingredientObjectList = new List<GameObject>();



    // When an ingredient go into the collider, make new candidate equal to stored prefab 
    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            if (other.gameObject.tag == "BurgerIngredient" && ingredientObjectList.IndexOf(other.gameObject) < 0)
            {
                // Make hovered ingredient have this plate as a reference
                other.gameObject.GetComponent<IngredientSpawner>().selectedPlate = this;
                // When a ingredient hovers over plate, make shadow represent the candidate

                AssignCandidate(other.gameObject);

            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (active)
        {
            if (other.gameObject.tag == "BurgerIngredient")
            {
                // Reset reference on absent object
                other.gameObject.GetComponent<IngredientSpawner>().selectedPlate = null;
                // When ingredient no longer hovers, reset shadow
                UnassignCandidate();
            }
        }
        

    }

    // called by ingredient when released
    public void AssignCandidate(GameObject candidate)
    {
        if (active)
        {
            //Only show shadow if able to attach ingredient
            if (ingredientObjectList.Count < 6)
            {
                if (candidate.name != "burgerSpawner")
                {
                    ingredientSpawnShadow.GetComponent<MeshFilter>().mesh = candidate.GetComponent<MeshFilter>().mesh;
                }
                else
                {
                    ingredientSpawnShadow.GetComponent<MeshFilter>().mesh = pattyMesh;
                }

                ingredientSpawnShadow.transform.localScale = scaleHandler(candidate.name);
            }
        }
        
        

    }
    // called by ingredient when grabbed or spawned
    public void UnassignCandidate()
    {
        // Reset Mesh
        ingredientSpawnShadow.GetComponent<MeshFilter>().mesh = null;
        // Reset Scale of shadow
        ingredientSpawnShadow.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private Vector3 scaleHandler(string ingredientName)
    {
        switch (ingredientName)
        {
            case "bottomBunSpawner":
                return new Vector3(0.1f, 3f, 0.1f);
            case "topBunSpawner":
                return new Vector3(0.1f, 3f, 0.1f);
            case "lettuceSpawner":
                return new Vector3(0.075f, 1f, 0.075f);
            case "tomatoSpawner":
                return new Vector3(0.05f, 0.5f, 0.05f);
            case "cheeseSpawner":
                return new Vector3(0.5f, 0.25f, 0.5f);
            case "onionSpawner":
                return new Vector3(0.2f, 0.5f, 0.2f);
            case "burgerSpawner":
                // fix this
                Debug.Log("test1");
                return new Vector3(0.09f, 2f, 0.09f);
        }

        Debug.Log("test2");
        // Return default value (1,1,1)
        return new Vector3(1f, 1f, 1f);
    }
    private Vector3 heightHandler(string ingredientName)
    {
        switch (ingredientName)
        {
            case "bottomBunSpawner":
                return new Vector3(0.0f, 0.01f, 0.0f);
            case "topBunSpawner":
                return new Vector3(0.0f, 0.01f, 0.0f);
            case "lettuceSpawner":
                return new Vector3(0.0f, 0.02f, 0.0f);
            case "tomatoSpawner":
                return new Vector3(0.0f, 0.01f, 0.0f);
            case "cheeseSpawner":
                return new Vector3(0.0f, 0.01f, 0.0f);
            case "onionSpawner":
                return new Vector3(0.0f, 0.01f, 0.0f);
            case "burgerSpawner":
                return new Vector3(0.0f, 0.02f, 0.0f);
        }

        // Return default value (0f,1f,0f)
        return new Vector3(0f, 1f, 0f);
    }
    private string nameHandler(GameObject candidate)
    {
        switch (candidate.name)
        {
            case "bottomBunSpawner":
                return "bun";
            case "topBunSpawner":
                return "bun";
            case "lettuceSpawner":
                return "lettuce";
            case "tomatoSpawner":
                return "tomato";
            case "cheeseSpawner":
                return "cheese";
            case "onionSpawner":
                return "onion";
            case "burgerSpawner":
                string topPatty = candidate.GetComponent<BurgerCooker>().topBurger.GetComponent<BurgerStager>().state;
                string botPatty = candidate.GetComponent<BurgerCooker>().bottomBurger.GetComponent<BurgerStager>().state;

                if (topPatty == botPatty)
                {
                    return topPatty;
                }
                return "mismatchPatty";

        }
        
        //default case
        return "null";

    }

  


    public bool addIngredient(GameObject candidate)
    {
        if (active)
        {
            // Only add ingredient if less than max total count of 5
            if (ingredientObjectList.Count < 6)
            {
                // add itself to list
                ingredientObjectList.Add(candidate);
                // add itself to string list 
                ingredientNameList.Add(nameHandler(candidate));
                // bind to parent (plate)
                candidate.transform.parent = gameObject.transform;
                // fix scaling issues
                candidate.transform.localScale = scaleHandler(candidate.name);
                candidate.transform.rotation = Quaternion.identity;
                // increment position
                ingredientPos = ingredientPos += heightHandler(candidate.name);
                // increment shadow position
                ingredientSpawnShadow.transform.localPosition = ingredientPos;
                // snap to position
                candidate.transform.localPosition = ingredientPos;
                Debug.Log("Position should have changed");



                //fix this
                // turn off shadow and reset
                UnassignCandidate();
                //Re-bind Ingredient 
                return true;
            }
        }
        return false;

    }

    public void removeIngredient(GameObject candidate)
    {
        // Remove reference from list
        ingredientObjectList.Remove(candidate);
    }

}


