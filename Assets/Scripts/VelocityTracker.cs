using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{

    private Vector3 velocity;
    private bool onSpatula = false;


    private void Update()
    {
        velocity = gameObject.GetComponent<Rigidbody>().velocity;
        if (onSpatula)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Burger")
        {
            onSpatula = true;
        }
    }
}
