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
        
    }

    void OnTriggerEnter(Collider other)
    {
        
    }

    void DisablePreviousZone()
    {
        nextZone.SetActive(false);
    }
}

