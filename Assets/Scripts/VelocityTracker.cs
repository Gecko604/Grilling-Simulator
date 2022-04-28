using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{

    [Header("Spatula Position")]
    public float x;
    public float z;

    [Header("Trigger Variables")]
    public bool onSpatula = false;
    public GameObject burger;


    private void FixedUpdate()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Burger")
        {
            //print("on spat");
            onSpatula = true;
            burger = other.gameObject;
            burger.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Burger")
        {
            //print("off spat");
            onSpatula = false;
            burger.transform.parent = null;
        }
    }
}
