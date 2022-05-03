using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateSpawner : MonoBehaviour
{
    public Vector3 startPos;
    public GameObject platePrefab = null;
    public Quaternion startRot;

    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        if (platePrefab == null) { return; }

        startPos = gameObject.transform.position;
        startRot = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPlate()
    {
        if (canSpawn)
        {
            GameObject ingredientInstance = Instantiate(platePrefab, startPos, startRot) as GameObject;
            ingredientInstance.name = $"platePrefab";
            ingredientInstance.GetComponent<Rigidbody>().isKinematic = false;
            canSpawn = false;

            gameObject.transform.parent.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.transform.parent.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
