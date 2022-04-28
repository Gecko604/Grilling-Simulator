using JetBrains.Annotations;
using UnityEngine;

public class IngredientRemoverBox : MonoBehaviour
{
    [CanBeNull]public BurgerManager burgerManager;
    [CanBeNull]public BurgerCombiner burgerCombiner;
    private Transform startingTransform;
    private Vector3 startingPosition;
    private Vector3 startingScale;
   

    // Start is called before the first frame update
    void Start()
    {
        startingTransform = this.transform;
        startingPosition = this.transform.position;
        startingScale = this.transform.localScale;
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
        burgerCombiner.timer = 0.0f;
        GameObject exitObject = other.gameObject;
        if (burgerManager.ingredientList.Contains(exitObject))
        {
            Debug.Log("object found to be removed");
            //remove item from lists of names and object
            RemoveFromManagerLists();
            exitObject.transform.SetParent(null);
            //move/scale trigger zone and move other trigger zone down
            burgerCombiner.MoveZoneDown();
            burgerCombiner.numIngredients--;
        }
    }

    public void RemoveFromManagerLists()
    {
        burgerManager.RemoveFromEndOfList();
        Debug.Log("Removed last object from object list");
        burgerManager.RemoveNameFromEndOfList();
        Debug.Log("removed name from end of list");
    }

    public void MoveAndExitScaleZoneUp()
    {
        Debug.Log("Moved Exit Trigger up");
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, this.transform.position.z);
        //this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y + 1.0f, this.transform.localScale.z);
    }

    public void MoveAndExitScaleZoneDown() 
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.02f, this.transform.position.z);
        //this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y - 1.0f, this.transform.localScale.z);
    }

    public void DisableColliderAndRenderer() 
    {
        this.GetComponent<Collider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;
    }

    public void EnableColliderAndRenderer() 
    {
        this.GetComponent<Collider>().enabled = true;
        this.GetComponent<MeshRenderer>().enabled = true;
    }

    public void ResetBoxLocation()
    {
        this.transform.localScale = startingScale;
        this.transform.position = startingPosition;
    }
}
