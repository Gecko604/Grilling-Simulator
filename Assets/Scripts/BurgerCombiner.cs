using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCombiner : MonoBehaviour
{

    public GameObject burgerParent;
    public GameObject nextZone;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Startup of BurgerCombiner");
    }


    // Update is called once per frame
    void Update()
    {
        //if both topbun and bottombun are in burger, stop allowing combination and activate throwable/interactable for whole object
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject ingredient = other.gameObject;
        if (ingredient.CompareTag("Lettuce"))
        {
            ingredient.transform.SetParent(burgerParent.transform);
            //reference other script to state position and confirm lettuce is on burger
        }
        if (ingredient.CompareTag("Cheese"))
        {
            ingredient.transform.SetParent(burgerParent.transform);
            //reference other script to state position and confirm lettuce is on burger
        }
        if (ingredient.CompareTag("BottomBun"))
        {
            ingredient.transform.SetParent(burgerParent.transform);
            //reference other script to state position and confirm lettuce is on burger
        }
        if (ingredient.CompareTag("TopBun"))
        {
            ingredient.transform.SetParent(burgerParent.transform);
            //reference other script to state position and confirm lettuce is on burger
        }
        if (ingredient.CompareTag("Burger"))
        {
            ingredient.transform.SetParent(burgerParent.transform);
            //reference other script to state position and confirm lettuce is on burger
        }

    }

    void DisablePreviousZone()
    {
        nextZone.SetActive(false);
    }
}

