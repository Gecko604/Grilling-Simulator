using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{

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
            ingredientInstance.name = "Burger Patty";
            ingredientInstance.GetComponent<Rigidbody>().isKinematic = false;
            canSpawn = false;

            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
