using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbed : MonoBehaviour
{
    public Boolean inHand;
    //small class to prevent objects in hand from interacting with triggers


    // Start is called before the first frame update
    void Start()
    {
        inHand = true;
    }
}
