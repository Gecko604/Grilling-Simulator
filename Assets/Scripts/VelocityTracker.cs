using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{

    private Vector3 velocity;
    private bool onSpatula = false;
    public GameObject burger;


    private void Update()
    {
        velocity = gameObject.GetComponent<Rigidbody>().velocity;
        if (onSpatula)
        {
            burger.GetComponent<Rigidbody>().velocity = velocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Burger")
        {
            onSpatula = true;
            burger = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Burger")
        {
            onSpatula = false;
        }
    }
}
