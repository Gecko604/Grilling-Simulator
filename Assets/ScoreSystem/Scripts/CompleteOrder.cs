using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteOrder : MonoBehaviour
{
    [SerializeField] 
    private ScoreManager scoreManager;
    [SerializeField]
    private orderManager orderManager;

    [SerializeField] 
    private GameObject turnInBurger = null;
    [SerializeField]
    private GameObject turnInTicket = null;

    
    // Start is called before the first frame update
    void Start()
    {
        //Get reference to HUD's score manager
        //scoreManager = GameObject.Find("HUD").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnInBurger != null && turnInTicket != null)
        {
            //Evaluate Order components
            //// TODO : 
            
            //Create transaction
            ////TODO: MealCompleted(bill amount, satisfaction level); 

            //Delete Order from orderManager 
            //TODO: Give order the order ticket number
            orderManager.CompleteOrder(turnInTicket.GetComponentInParent<CreateOrder>().GetOrderNumber().ToString());

            //Destroy turned in order components => Reset variable references
            Destroy(turnInBurger);
            turnInBurger = null;
            Destroy(turnInTicket);
            turnInTicket = null;


        }

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
