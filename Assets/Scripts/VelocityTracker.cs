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

    private double previousV = 0;
    private double currentV = 0;
    private Rigidbody rigidbody;
    private bool isInHand;
    private AudioSource crash;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        crash = GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        currentV = rigidbody.velocity.magnitude;
        if (previousV >= 0.1 && currentV < 0.1 && !isInHand)
        {
            crash.PlayOneShot(crash.clip);
        }
        previousV = currentV;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "BurgerIngredient")
        {
            //print("on spat");
            onSpatula = true;
            burger = other.gameObject;
            burger.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "BurgerIngredient")
        {
            //print("off spat");
            onSpatula = false;
            burger.transform.parent = null;
        }
    }

    public void Grabbed(bool isGrabbed)
    {
        isInHand = isGrabbed;
    }
}
