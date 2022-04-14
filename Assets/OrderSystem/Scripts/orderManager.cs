using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderManager : MonoBehaviour
{
    private int ticketCount = 0;

    public ScoreManager scoreManager = null;


    public string[] currentOrders;

    // X moves 0.75 each; 3 orders MAX
    public Vector3 orderStartingPos;

    [SerializeField] private GameObject newOrderPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("attemptSpawnOrder");
    }

    private void spawnOrder()
    {
        // Iterate through current orders (max: 3), and check if there is an open spot (open == "")
        for (int i = 0; i < currentOrders.Length; i++)
        {
            if (currentOrders[i] == "")
            {
                // Instantiate a new Order
                GameObject newOrder = Instantiate(newOrderPrefab, new Vector3 (orderStartingPos.x - (i * 0.75f), orderStartingPos.y, orderStartingPos.z), Quaternion.identity);

                //Rotate 180
                newOrder.transform.Rotate(0f, 180f, 0f);

                CreateOrder orderScript = newOrder.GetComponent<CreateOrder>();
                //Assign new order it's score manager
                orderScript.scoreManager = scoreManager;

                //Tell it to generate an order based of the difficulty
                orderScript.generateOrder(ticketCount);

                //// Cleaning up 
                //Add order to order queue by replacing empty array element
                currentOrders[i] = ticketCount.ToString();
                //Increment Ticket Count 
                ticketCount++;
               return;
            }

        }
        
    }

    // Complete an order - fix 
    public void CompleteOrder(string orderNumber)
    {
        for (int i = 0; i < currentOrders.Length; i++)
        {
            if (currentOrders[i] == orderNumber)
            {
                // If the order matches, remove order number from array - this allows new order to take place
                currentOrders[i] = "";
            }
        }
    }

    IEnumerator attemptSpawnOrder()
    {
        yield return new WaitForSeconds(5);
        spawnOrder();
        StartCoroutine("attemptSpawnOrder");
    }
}
