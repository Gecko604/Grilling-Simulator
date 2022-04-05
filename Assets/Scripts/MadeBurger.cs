using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadeBurger : MonoBehaviour
{
    [Header("Ingredients of Burger info")]
    public Boolean hasLettuce;
    public int numberOfLettucePieces;
    public Boolean hasCheese;
    public int numberOfCheeseSlices;
    public Boolean hasTopBun;
    public int topBunPosition;
    public Boolean hasBottomBun;
    public int bottomBunPosition;




    // Start is called before the first frame update
    void Start()
    {
        hasLettuce = false;
        numberOfLettucePieces = 0;
        hasCheese = false;
        numberOfCheeseSlices = 0;
        hasTopBun = false;
        hasBottomBun = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (hasTopBun && hasBottomBun)
        {
            //set throwable and interactable scripts as active
        }
    }
}
