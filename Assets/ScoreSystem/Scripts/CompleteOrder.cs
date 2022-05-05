using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteOrder : MonoBehaviour
{
    [SerializeField] 
    // Reference for updating score 
    private ScoreManager scoreManager;

    [SerializeField]
    // Reference for updating line 
    private Restaurant_Manager director;

    [SerializeField]
    // Retrieve list of active orders
    private orderManager orderManager;

    [SerializeField] 
    // Submitted Burger gameObject
    private GameObject turnInBurger = null;
    [SerializeField]
    // Submitted Ticket gameObject
    private GameObject turnInTicket = null;

    
    // Start is called before the first frame update
    void Start()
    {
        //Get reference to HUD's score manager
        scoreManager = GameObject.Find("HUD").GetComponent<ScoreManager>();
        orderManager = GameObject.Find("Order Holder").GetComponent<orderManager>();
        director = GameObject.Find("Resturant_Position_Manager").GetComponent<Restaurant_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (turnInBurger != null && turnInTicket != null)
        {
           
            // eval T or F if order is correct
            scoreManager.MealCompleted(evaluateOrder(turnInBurger, turnInTicket));
            
            //Create transaction
            ////TODO: MealCompleted(bill amount, satisfaction level); 

            //Delete Order from orderManager 
            orderManager.CompleteOrder(turnInTicket.GetComponentInParent<CreateOrder>().GetOrderNumber().ToString());


            // Testing!!
            //Call owner removal script when completed
            CreateOrder orderScript = turnInTicket.transform.parent.GetComponent<CreateOrder>();


            //Destroy turned in order components => Reset variable references
            Destroy(turnInBurger);
            turnInBurger = null;
            Destroy(turnInTicket.transform.parent.gameObject);
            turnInTicket = null;

            
            //Move customer alonog
            director.customerGivenOrder(orderScript.orderOwner);


        }

    }
    private bool evaluateOrder(GameObject plate, GameObject ticket)
    {

        // Attach data 
        List<string> burgerIngredients = plate.GetComponentInChildren<BurgerManager>().ingredientNameList;
        burgerIngredients.Reverse();
        List<string> ticketIngredients = ticket.transform.parent.GetComponent<CreateOrder>().GetIngredients();

        // If mismatch in size, instant failure 
        if (burgerIngredients.Count != ticketIngredients.Count) { Debug.Log("Mismatched Ingredient Size");  return false; }

        // Loop for each needed ingredient on ticket
        for (int i = 0; i < ticketIngredients.Count; i++)
        {
            //debug only
            if(burgerIngredients[i] == "patty")
            {
                continue;
            }
            if (burgerIngredients[i] != ticketIngredients[i])
            {
                Debug.Log($"Incorrect Order! {burgerIngredients[i]} != {ticketIngredients[i]}");
                return false;
            }
        }

        return true;
    }
    private void OnTriggerEnter(Collider other)
    {
        // If object touching is either a plated burger or a ticket, make the turn in object offending object
        if (other.gameObject.tag == "plate")
        {
            turnInBurger = other.gameObject;
        }

        if (other.gameObject.tag == "ticket")
        {
            turnInTicket = other.gameObject;
        }
        //Debug.Log($"Touched by : {other.gameObject.name}");
    }
    private void OnTriggerExit(Collider other)
    {
   
        if (other.gameObject.tag == "plate")
        {
            turnInBurger = null;
        }

        if (other.gameObject.tag == "ticket")
        {
            turnInTicket = null;
        }
    }

}
