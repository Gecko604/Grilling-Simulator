using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropped : MonoBehaviour
{

    private double previousV = 0;
    private double currentV = 0;
    private Rigidbody rb;
    private bool isInHand;
    private AudioSource crash;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        crash = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        currentV = rb.velocity.magnitude;
        if (previousV >= 0.1 && currentV < 0.1 && !isInHand)
        {
            crash.PlayOneShot(crash.clip);
        }
        previousV = currentV;
    }

    public void Grabbed(bool isGrabbed)
    {
        isInHand = isGrabbed;
    }
}
