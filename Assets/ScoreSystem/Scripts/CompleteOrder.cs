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

            Debug.Log(evaluateOrder(turnInBurger, turnInTicket));
            scoreManager.MealCompleted(evaluateOrder(turnInBurger, turnInTicket));
            
            //Create transaction
            ////TODO: MealCompleted(bill amount, satisfaction level); 

            //Delete Order from orderManager 
            //TODO: Give order the order ticket number
            orderManager.CompleteOrder(turnInTicket.GetComponentInParent<CreateOrder>().GetOrderNumber().ToString());


            // Testing!!
            //Call owner removal script when completed
            CreateOrder orderScript = turnInTicket.transform.parent.GetComponent<CreateOrder>();


            //Destroy turned in order components => Reset variable references
            Destroy(turnInBurger);
            turnInBurger = null;
            Destroy(turnInTicket.transform.parent.gameObject);
            turnInTicket = null;

            

            director.customerGivenOrder(orderScript.orderOwner);


        }

    }
    private bool evaluateOrder(GameObject burger, GameObject ticket)
    {
        List<string> DebugBurger = new List<string> { "bun", "cheese", "medium", "tomato", "bun", "bun" };
        List<string> DebugTicket = new List<string> { "bun", "cheese", "medium", "bun" };

        // If mismatch in size, instant failure 
        if (DebugBurger.Count != DebugTicket.Count) { Debug.Log("Mismatched Ingredient Size");  return false; }

        // Loop for each needed ingredient on ticket
        for (int i = 0; i < DebugTicket.Count; i++)
        {
            if (DebugBurger[i] != DebugTicket[i])
            {
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
        Debug.Log($"Touched by : {other.gameObject.name}");
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
