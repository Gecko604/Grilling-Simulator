using JetBrains.Annotations;
using UnityEngine;

public class IngredientRemoverBox : MonoBehaviour
{
    [CanBeNull]public BurgerManager burgerManager;
    [CanBeNull]public BurgerCombiner burgerCombiner;
    private Transform startingTransform;
    private Vector3 startingPosition;
   

    // Start is called before the first frame update
    void Start()
    {
        startingTransform = this.transform;
        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        int numOfIngredients = burgerManager.ingredientList.Count;
        //if list is less than one disable trigger
        if (numOfIngredients < 1)
        {
            //disable zone
            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
        }
        if (numOfIngredients >= 6 || (burgerManager.hasTopBun && burgerManager.hasBottomBun))
        {
            //disable zone
            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;

            Debug.Log("Filled plate with ingredients/finished burger");
        }
        if (numOfIngredients >= 1)
        {
            //enable zone
            this.GetComponent<Collider>().enabled = true;
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        GameObject exitObject = other.gameObject;
        if (burgerManager.ingredientList.Contains(exitObject))
        {
            //remove item from lists of names and object
            RemoveFromManagerLists();
            
            //move/scale trigger zone and move other trigger zone down
            burgerCombiner.MoveZoneDown();
        }
    }

    public void RemoveFromManagerLists()
    {
        burgerManager.RemoveFromEndOfList();
        burgerManager.RemoveNameFromEndOfList();
    }
}
