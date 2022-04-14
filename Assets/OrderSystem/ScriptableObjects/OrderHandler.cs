using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderHandler : MonoBehaviour
{

    [SerializeField]
    public List<string> burgerTemplate = null;
    public List<string> ingredients = null;
    private int maxIngredients = 6;
    private string patty = null;
    public int orderNumber = -1;




    [SerializeField] public GameObject textPrefab = null;
    [SerializeField] public GameObject imagePrefab = null;
    [SerializeField] public GameObject textParent = null;
    [SerializeField] public GameObject imageParent = null;

    // Start is called before the first frame update
    void Start()
    {
        //get CreateOrder reference
        CreateOrder order = gameObject.GetComponent<CreateOrder>();

        // Set up order card variables
        patty = order.GetPatty();
        ingredients = order.GetIngredients();
        orderNumber = order.GetOrderNumber();

        setUpTemplate();

    }

    public void setUpTemplate()
    {
        //Set up the order template card based off of ingredients

        // n ingredients
        int ingredientCount = ingredients.Count;

        //If we have a bun, we need to have a bottom bun as well
        if (ingredients.Contains("Bun"))
        {
            ingredients.Add("Bun");
            ingredientCount += 1;
        }
    }

    private void spawnOrderElements()
    {
        Vector3 textStartingPos = new Vector3(4.7f, 0.35f, 0f);
        Vector3 imageStartingPos = new Vector3(0f, 0.65f, 0f);
        //Create UI elements && text on order ticket
        for (int i = 0; i < ingredients.Count; i++)
        { 
            GameObject text = Instantiate(textPrefab, textParent.transform);
            text.transform.position = new Vector3(textStartingPos.x , textStartingPos.y, textStartingPos.z);
            GameObject image = Instantiate(imagePrefab, imageParent.transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
