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
    private Boolean isInCombineZone;
    public Boolean snapped;
    // Start is called before the first frame update
    void Start()
    {
        snapped = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter other: {other.gameObject}");
        if (other.gameObject.CompareTag("CombineZone")) //if combine zone, add this to burger parent object
        {
            GameObject zone = other.gameObject;
            //set to center of trigger area
            moveToCenter(zone);
            this.transform.SetParent(burgerParent);


            zone.SetActive(false);
        }
    }

    void OnCollisionExit(Collider other)
    {
        Debug.Log($"OnTriggerEnter other: {other.gameObject}");
        if (other.CompareTag("CombineZone"))
        {
            GameObject zone = other.gameObject;

            this.transform.SetParent(ingredients);
        }
    }

    void moveToCenter(GameObject zone)
    {
        this.transform.position = zone.transform.position;
    }
}
