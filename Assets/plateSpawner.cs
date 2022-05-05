using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateSpawner : MonoBehaviour
{

    public GameObject platePrefab;

    private bool canSpawn = true; // true when the plate has not been touched yet.

    // Start is called before the first frame update
    void Start()
    {
        if (platePrefab == null) { platePrefab = gameObject; return; }

    }

    // Update is called once per framea
    void Update()
    {

    }

    public void SpawnPlate()
    {
        // When touched and SpawnPlate() is called by hands:

        // If already spawned a plate, return
        if (!canSpawn) { return; }

        // If first call, spawn an identical copy
        Instantiate(platePrefab, transform.position, Quaternion.identity);
        // Prevent further spawning
        canSpawn = false;


        //Turn on physics for this plate
        GetComponent<Rigidbody>().isKinematic = false;
        //GetComponent<Rigidbody>().useGravity = true;

    }
}

