using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{

    public float x;
    public float z;
    public bool onSpatula = false;
    public GameObject burger;
    public Vector3 rotationVector;


    private void Update()
    {
        x = gameObject.transform.position.x;
        z = gameObject.transform.position.z + 0.193f;
        rotationVector = gameObject.transform.rotation.eulerAngles;
        if (onSpatula)
        {
            burger.transform.position = new Vector3(x, burger.transform.position.y, z);
            burger.transform.rotation = Quaternion.Euler(rotationVector);
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
