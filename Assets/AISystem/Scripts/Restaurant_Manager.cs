using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Restaurant_Manager : MonoBehaviour
{

    [Header("Game Settings")]
    [SerializeField] public bool gameOver = false;

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
    [SerializeField] public List<GameObject> waiting = new List<GameObject>() {null, null, null};
    [SerializeField] public List<GameObject> seats = new List<GameObject>();

    [Header("Prefabs")]
    [SerializeField] private GameObject customerPrefab = null;

    [Header("Order Manager")]
    [SerializeField] private orderManager orderManager = null;
    // 6 line
    // 3 waiting
    // 8 sitting
    // 3 exit (1-4 seats go 2,3), (5-8 seats go 1,2,3)

    //Hard-coded spawn point for each customer
    private Vector3 spawnPoint = new Vector3(2f, 1.25f, -12f);

    private void Start()
    {
        orderManager = GameObject.Find("Order Holder").GetComponent<orderManager>();

        // Call coroutine immediately - spawn a full line
        StartCoroutine(attemptNewCustomer());

        StartCoroutine(autoLineCheck());

    }


    IEnumerator attemptNewCustomer()
    {
        if (!gameOver)
        {
            float delay = 3;
            //Debug.Log($"Spawning a new customer in ({delay}) seconds!");
            // How long to wait before code below is called
            yield return new WaitForSeconds(delay);

            if (line.Count < 6) { spawnCustomer(); }

            StartCoroutine(attemptNewCustomer());

        } else
        {
            StartCoroutine(customersCleanUp());
        }
        
    }

    //
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
        if (checkLineReady() && isStandingOpen())
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
        // only move everyone up if waiting is open
        if (isStandingOpen())
        {
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
                    //Debug.Log($"New position to be acquired | Index i = {i}");
                    //Debug.Log($"New position to be acquired | Index i = {customerData.waitPosition}");
                    if (customerData.waitPosition == -1)
                    {
                        //Add to wait list
                        //waiting.Add(line[i]);
                        assignStanding(line[i]);

                        //Order - pass onto order the owner
                        orderManager.spawnOrder(line[i]);

                        //Get new position
                        customerData.standPosition = waiting.IndexOf(line[i]);
                        //Move to new position
                        customerData.positionToMoveTo = waitingPositions[customerData.standPosition].transform.position;
                        // Debug coroutine - given customer and 10 seconds to delete and re-evaluate line to take in spot
                        // -- Remove to test manual order completion    
                        //StartCoroutine(testCompleteOrder(line[i]));
                        //Remove customer from line list
                        //line.Remove(line[i]);
                    }
                    else
                    {
                        // Customer is not first 
                        customerData.positionToMoveTo = new Vector3(linePositions[customerData.waitPosition].transform.position.x, line[i].transform.position.y, linePositions[customerData.waitPosition].transform.position.z);

                    }
                    //Debug.Log($"New position acquired | Index i = {i}");


                    // Move customer to their new position
                    customerData.MoveNextPosition();





                    //Debug.Log(i);
                }

            }
            //Remove first customer
            if (line.Count > 0)
            {
                line.Remove(line[0]);
            }

        }
        
    }

    // Iterate Standing positions, if a single one is open then assign customer to that position
    private bool assignStanding(GameObject orderedCustomer)
    {
        // while less than 3, just add to list ==> takes available spot
        if (waiting.Count < 3) { waiting.Add(orderedCustomer);  return true; }

        // otherwise swap with null spot
        for (int i = 0; i < waiting.Count; i++)
        {
            if (waiting[i] == null)
            {
                waiting[i] = orderedCustomer;
                return true;
            }
            
        }

        // return false if unsuccessful ==> should never happen
        Debug.Log("Oops! This should never run.");
        return false;
    }
    private bool isStandingOpen()
    {
        if (waiting.Count < 3) { return true; }

        for (int i = 0; i < waiting.Count; i++)
        {
            if (waiting[i] == null)
            {
                return true;
            }
        }

        return false;
    }

    private bool assignSeating(GameObject orderedCustomer)
    {
        // while less than 8, just add to list ==> takes available spot
        if (seats.Count < 8) { seats.Add(orderedCustomer); return true; }

        // otherwise swap with null spot
        for (int i = 0; i < seats.Count; i++)
        {
            if (seats[i] == null)
            {
                seats[i] = orderedCustomer;
                return true;
            }

        }

        // return false if unsuccessful ==> should never happen
        Debug.Log("Oops 1! This should never run.");
        return false;
    }
    private bool isSeatingOpen()
    {
        if (seats.Count < 8) { return true; }

        for (int i = 0; i < seats.Count; i++)
        {
            if (seats[i] == null)
            {
                return true;
            }
        }

        return false;
    }

    public void customerGivenOrder(GameObject customerGivenFood)
    {
        // Take index of completed customer in standing queue
        int positionOpened = waiting.IndexOf(customerGivenFood);
        // Remove reference in waiting, turn into null so it may be swapped
        waiting[positionOpened] = null;
        // Destroy customer - for now

        //Destroy(customerGivenFood);
        if (isSeatingOpen())
        // Move to a seat
        {
            AIBehavior customerData = customerGivenFood.GetComponent<AIBehavior>();

            assignSeating(customerGivenFood);
            // Get index of customer in line
            customerData.seatPosition = seats.IndexOf(customerGivenFood);
            //Get customer's line positions's Vector3
            Vector3 targetPosition = new Vector3(seatingPositions[customerData.seatPosition].transform.position.x, customerGivenFood.transform.position.y, seatingPositions[customerData.seatPosition].transform.position.z);
            // Give customer target position of thier spot in line
            customerData.positionToMoveTo = targetPosition;
            customerData.MoveNextPosition();

            StartCoroutine(customerEating(customerGivenFood));
        } else
        // Move directly to exit
        {
            // Get script 
            AIBehavior customerData = customerGivenFood.GetComponent<AIBehavior>();

            //Get position of exit
            Vector3 targetPosition = new Vector3(ExitPath[0].transform.position.x, customerGivenFood.transform.position.y, ExitPath[0].transform.position.z);

            // Give customer target position of thier spot in line
            customerData.positionToMoveTo = targetPosition;
            customerData.MoveNextPosition();

            StartCoroutine(destroyCustomer(customerGivenFood));
        }

        




        // Tell line to evaluate line and see if one can go in waiting
        EvaluateLine();
    }

    IEnumerator autoLineCheck()
    {
        yield return new WaitForSeconds(15);
        // Call evaluate line in case spawning has caused a mistime in evaluateLine() and people walking in.
        EvaluateLine();
        StartCoroutine(autoLineCheck());

    }

    IEnumerator destroyCustomer(GameObject exitingCustomer)
    {
        yield return new WaitForSeconds(5);
        // Despawn customer after it leaves 
        Destroy(exitingCustomer);
    }

    // Customer goes to sit, then calls exit lerp
    IEnumerator customerEating(GameObject exitingCustomer)
    {
        yield return new WaitForSeconds(14);

        //Relinquish seat
        int seatIndex = seats.IndexOf(exitingCustomer);

        // Reset seat
        seats[seatIndex] = null;

        // Get script 
        AIBehavior customerData = exitingCustomer.GetComponent<AIBehavior>();

        //Get position of exit
        Vector3 targetPosition = new Vector3(ExitPath[0].transform.position.x, exitingCustomer.transform.position.y, ExitPath[0].transform.position.z);

        // Give customer target position of thier spot in line
        customerData.positionToMoveTo = targetPosition;
        // Move customer to exit over 4 seconds
        customerData.MoveNextPosition();


        // Destroy customer after 5 seconds -> 1 sec after leaving building 
        StartCoroutine(destroyCustomer(exitingCustomer));
    }

    // Customer goes to sit, then calls exit lerp
    

    //DEBUG COROUTINE ONLY
    IEnumerator testCompleteOrder(GameObject customerGivenOrder)
    {
        Debug.Log("Order being made. Completed in 10 seconds.");
        yield return new WaitForSeconds(10);
        // Take index of completed customer in standing queue
        int positionOpened = waiting.IndexOf(customerGivenOrder);
        // Remove reference in waiting, turn into null so it may be swapped
        waiting[positionOpened] = null;
        // Destroy customer - for now
        Destroy(customerGivenOrder);
        // Tell line to evaluate line and see if one can go in waiting
        EvaluateLine();
    }


    //Clear out resturant - only call when game over
    IEnumerator customersCleanUp()
    {
        Debug.Log("Cleanup called");
        yield return new WaitForSeconds(6);

        GameObject[] customers = GameObject.FindGameObjectsWithTag("customer");
        
        for (int i = 0; i < customers.Length; i++)
        {
            // Get script 
            AIBehavior customerData = customers[i].GetComponent<AIBehavior>();

            //Get position of exit
            Vector3 targetPosition = new Vector3(ExitPath[0].transform.position.x, customers[i].transform.position.y, ExitPath[0].transform.position.z);

            // Give customer target position of thier spot in line
            customerData.positionToMoveTo = targetPosition;
            // Move customer to exit over 4 seconds
            customerData.MoveNextPosition();
            // Destroy customer after 5 seconds -> 1 sec after leaving building 
            StartCoroutine(destroyCustomer(customers[i]));
        }
    }
}
