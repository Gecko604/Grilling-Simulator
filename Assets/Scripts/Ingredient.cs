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

    }

    void OnTriggerEnter(Collider other)
    {
        
    }


    //on let go, make object no longer kinematic



}