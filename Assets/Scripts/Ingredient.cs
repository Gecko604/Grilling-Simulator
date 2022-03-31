using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [Header("ingredient stats and name")]
    public int score;
    public String name;

    public Transform burgerParent;
    public Transform ingredients;

    [Header("Booleans")]
    private Boolean isInCombineZone;
    public Boolean snapped;
    public Boolean inHand;

    // Start is called before the first frame update
    void Start()
    {
        snapped = false;
        inHand = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (snapped)
        {

        }
        else 
        {

        }
        if (inHand) 
        {

        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;
        Debug.Log($"OnTriggerEnter other: {otherObject}");
        if (other.gameObject.CompareTag("CombineZone")) //if combine zone, add this to burger parent object
        {
            isInCombineZone = true;
            if (!inHand)
            {
                //set to center of trigger area
                moveToCenter(otherObject);
                this.transform.SetParent(burgerParent);
                otherObject.SetActive(false);
            }
        }
    }

    void OnCollisionExit(Collider other)
    {
        Debug.Log($"OnTriggerExit other: {other.gameObject}");
        if (other.CompareTag("CombineZone"))
        {
            GameObject otherObject = other.gameObject;
            isInCombineZone = false;
            this.transform.SetParent(ingredients);
        }
    }

    //sets this position to position of zone
    void moveToCenter(GameObject other)
    {
        this.transform.position = other.transform.position;
    }
}
