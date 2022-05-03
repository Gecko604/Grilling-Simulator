using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    // Needed for plating logic
    public bool isGrabbed = false;
    // Needed for plating logic
    public BurgerManager selectedPlate = null;



    public Vector3 startPos;
    public GameObject ingredient = null;
    public Quaternion startRot;

    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        if (ingredient == null) { ingredient = gameObject; }

        startPos = gameObject.transform.position;
        startRot = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnIngredient()
    {
        if (canSpawn)
        {
            GameObject ingredientInstance = Instantiate(ingredient, startPos, startRot) as GameObject;
            ingredientInstance.name = $"{gameObject.name}";
            ingredientInstance.GetComponent<Rigidbody>().isKinematic = false;
            canSpawn = false;

            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }


    public void isGrabbedOn()
    {
        isGrabbed = true;
    }

    public void isGrabbedOff()
    {
        isGrabbed = false;
    }

    public void handlePlating()
    {
        // If not in a plate zone, do nothing
        if (selectedPlate == null) { return;}

        // Tell manager to handle adding this gameObject
        bool successfulBind = selectedPlate.addIngredient(gameObject);

        if (successfulBind)
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
        } else {
            return;
        }
    }
}
