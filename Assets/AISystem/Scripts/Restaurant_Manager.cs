using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant_Manager : MonoBehaviour
{
    [Header("Position References")]
    // References to positions - don't modify
    [SerializeField] private List<GameObject> linePositions = new List<GameObject>(6);
    [SerializeField] private List<GameObject> waitingPositions = new List<GameObject>(3);
    [SerializeField] private List<GameObject> seatingPositions = new List<GameObject>(8);
    [SerializeField] private List<GameObject> bossPath = new List<GameObject>(4);
    [SerializeField] private List<GameObject> ExitPath = new List<GameObject>(4);

    [Header("Customer Elements")]
    // Lists of positions containing customers - do modify
    [SerializeField] public List<GameObject> line = new List<GameObject>();
    [SerializeField] public List<GameObject> waiting = new List<GameObject>();
    [SerializeField] public List<GameObject> seats = new List<GameObject>();

    [Header("Prefabs")]
    [SerializeField] private GameObject customerPrefab = null;

    // 6 line
    // 3 waiting
    // 8 sitting
    // 3 exit (1-4 seats go 2,3), (5-8 seats go 1,2,3)

    //Hard-coded spawn point for each customer
    private Vector3 spawnPoint = new Vector3(2f, 1.25f, -12f);

    private void Start()
    {
        // Call coroutine immediately - spawn a full line
        StartCoroutine(NewCustomer());
        


    }

    private void Update()
    {
       
    }

    IEnumerator NewCustomer()
    {
        float delay = 3;
        //Debug.Log($"Spawning a new customer in ({delay}) seconds!");
        // How long to wait before code below is called
        yield return new WaitForSeconds(delay);
        spawnCustomer();
        if (line.Count < 6)
        {
            StartCoroutine(NewCustomer());
        }

    }

    // Return True if all customers in line are waiting
    private bool checkLineReady()
    {
        for (int i = 0; i < line.Count; i++)
        {
            if (line[i].GetComponent<AIBehavior>().currentTask != AIBehavior.CustomerState.Waiting) { return false; }
        }

        return true;
    }
    private void spawnCustomer()
    {

        // Spawn a new customer
        GameObject newCustomer = Instantiate(customerPrefab);
        AIBehavior customerData = newCustomer.GetComponent<AIBehavior>();
        // Place new customer at spawn point
        newCustomer.transform.position = spawnPoint;

        // Add customer to line list
        line.Add(newCustomer);
        // Get index of customer in line
        customerData.waitPosition = line.IndexOf(newCustomer);
        //Get customer's line positions's Vector3
        Vector3 targetPosition = new Vector3(linePositions[customerData.waitPosition].transform.position.x, newCustomer.transform.position.y ,linePositions[customerData.waitPosition].transform.position.z);
        // Give customer target position of thier spot in line
        customerData.positionToMoveTo = targetPosition;
    }

    public void EvaluateMyPosititon(GameObject readyCustomer)
    {
        // If in wait line && first position
        if (line.IndexOf(readyCustomer) == 0)
        {
            //Create my order

            // Move me to waiting position if avaliable
            if (waiting.Count < 3)
            {
                // Remove me from line
                //line.Remove(readyCustomer);

                // Move everyone in wait line up one
                //moveLineUp();

                // Move me to waiting line
                waiting.Add(readyCustomer);

                // Retrieve data script
                AIBehavior readyCustomerData = readyCustomer.GetComponent<AIBehavior>();

                // No longer in waiting line, set invalid value
                readyCustomerData.waitPosition = -1;

                // Set waiting position
                readyCustomerData.standPosition = waiting.IndexOf(readyCustomer);

                // Set state to waiting
                readyCustomerData.currentTask = AIBehavior.CustomerState.Waiting;
                // Set customer's target position to waiting position vector3
                //readyCustomerData.positionToMoveTo = waiting[readyCustomerData.standPosition].transform.position;
                readyCustomerData.positionToMoveTo = waitingPositions[readyCustomerData.standPosition].transform.position;

                // Move customer
                readyCustomerData.MoveNextPosition();
            }

        }



        // If Order Complete
            // Evaluate my order
            // Move me to eating position
            // Remove me from waiting position
            // Reevaluate first position in wait line
        // If Done Eating
            // Remove me from eating position
            // Move me to outside restuarant
            // Destroy me

    }

    // Called by customers after moving into place - requests manager evalute if line should move
    public void EvaluateLine()
    {
        // If line is ready move everyone up one
        if (checkLineReady() && waiting.Count != 3)
        {
            moveLineUp();
        } else
        {
            if (!checkLineReady()) { Debug.Log($"Reason: CheckLineReady() returned False!"); }
            if (waiting.Count == 3) { Debug.Log($"Reason: Waiting Line is Full!"); }
        }
    }
    private void moveLineUp()
    {
        Debug.Log(line.Count);
        // After removing firstPos, index 1 -> N : must be moved down an index on dataScript and move position to show 
        for (int i = 0; i < line.Count; i++)
        {
            // if the element i has a customer, move it up
            if (line[i] != null)
            {
                // Retrieve data script
                AIBehavior customerData = line[i].GetComponent<AIBehavior>();


                // Move customer index down one
                customerData.waitPosition -= 1;

                // Update MoveToPosition reference to updated position
                Debug.Log($"New position to be acquired | Index i = {i}");
                Debug.Log($"New position to be acquired | Index i = {customerData.waitPosition}");
                if (customerData.waitPosition == -1)
                {
                    // Customer is first - this customer is removed
                    //Add to wait list
                    waiting.Add(line[i]);
                    //Order
                    //Get new position
                    customerData.positionToMoveTo = waitingPositions[0].transform.position;
                    //Move to new position

                    //Remove customer from line list
                    //line.Remove(line[i]);
                }
                else
                {
                    // Customer is not first 
                    customerData.positionToMoveTo = new Vector3(linePositions[customerData.waitPosition].transform.position.x, line[i].transform.position.y, linePositions[customerData.waitPosition].transform.position.z);

                }
                Debug.Log($"New position acquired | Index i = {i}");

                
                // Move customer to their new position
                customerData.MoveNextPosition();

                
                
                

                Debug.Log(i);
            }
            
        }
        //Remove first customer 
        line.Remove(line[0]);
    }
}
