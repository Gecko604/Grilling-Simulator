using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerStation : MonoBehaviour
{
    public GameObject BurgerParent;
    public GameObject NextZone;
    //list of possible ingredients?

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when interacting with ingredient not in hand, move ingredient to center of zone and disable zone and activate next one
    //add ingredient object to burger parent, once burger parent has 6? ingredients disable all zones until burger parent leaves zone
    //or instantiate new zone above ingredient and disable previous one
    //change material to greenTransparent when object in hand is interacting with it and activate meshrenderer
    void OnCollisionTrigger()
    {

    }
}
