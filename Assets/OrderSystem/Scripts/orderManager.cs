using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] orders = null;

    [SerializeField]
    private float[] orderLocations = null;


    [SerializeField]
    private GameObject emptyOrder = null;


    public List<GameObject> currentOrders = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        

        //Add all starting orders to the current order list 
        for(int i = 0; i < orders.Length; i++)
        {
            currentOrders.Add(orders[i]);
        }

        // Populate orders to full if not already
        if (currentOrders.Count > 5)
        {
            int startingLength = currentOrders.Count;

            for (int j = 0; j < (5 - currentOrders.Count); j++)
            {
                currentOrders.Add(emptyOrder);
            }
        }

        PopulateOrders(currentOrders);
    }


    public void PopulateOrders(List<GameObject> list)
    {
        for (int i = 0; i < orderLocations.Length; i++)
        {
            GameObject order = Instantiate(emptyOrder, transform, false);
            order.transform.position = new Vector3(orderLocations[i], order.transform.position.y, order.transform.position.z);
            Debug.Log("Spawned Order");
        }
    }

    // Complete an order 
    public void CompleteOrder(string orderNumber)
    {
        for (int i = 0; i < currentOrders.Count; i++)
        {
            if (currentOrders[i].name == orderNumber)
            {
                // If the completed order matches a ticket, then delete the order, remove from list and run the score system evaluation
                GameObject completedOrder = currentOrders[i];

                //Remove order from list 
                currentOrders.Remove(completedOrder);
                //Destroy Order Ticket Object
                Destroy(completedOrder);


            }
        }
    }
}
