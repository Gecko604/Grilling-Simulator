using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderHandler : MonoBehaviour
{
    public GameObject textTicketNumber;
    public GameObject[] imageElements;
    public GameObject[] textElements;
    public Material[] imageMaterials;

    public CreateOrder order;

    // Start is called before the first frame update
    void Start()
    {
        //get CreateOrder reference
        CreateOrder order = gameObject.GetComponent<CreateOrder>();
    }

    public void setUpTemplate()
    {

        //Assign Ticket The Number Order 
        textTicketNumber.GetComponent<TextMeshProUGUI>().text = "# " + handleOrderNumber(order.GetOrderNumber());

        //Create a list of strings from the order's required ingredients
        List<string> ingredients = order.GetIngredients();
        
        // Add list values to UI text elements
        for (int i = 0; i < ingredients.Count; i++)
        {

            //Debug.Log($"Logging: Ingredient is : {ingredients[i]}");
            textElements[i].GetComponent<TextMeshProUGUI>().text = ingredients[i];
            imageElements[i].GetComponent<RawImage>().material = retMaterial(ingredients[i]);
        }


    }

    private string handleOrderNumber(int orderNum)
    {
        if (orderNum > 9)
        {
            return $"{orderNum}";
        } else
        {
            return $"0{orderNum}";
        }
    }
    private Material retMaterial(string matName)
    {
        switch (matName)
        {
            case "bun": 
                return imageMaterials[0];
            case "lettuce":
                return imageMaterials[1];
            case "uncooked":
                return imageMaterials[2];
            case "raw":
                return imageMaterials[3];
            case "medium rare":
                return imageMaterials[4];
            case "well done":
                return imageMaterials[5];
            case "overcooked":
                return imageMaterials[6];
            case "burnt":
                return imageMaterials[7];
            case "cheese":
                return imageMaterials[8];
            case "tomato":
                return imageMaterials[9];
            case "onion":
                return imageMaterials[10];
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
