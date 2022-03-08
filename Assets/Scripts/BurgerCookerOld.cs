using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCookerOld : MonoBehaviour
{
    [Header("Burger Halves")]
    public GameObject UpperHalf;
    public GameObject LowerHalf;
    private GameObject GrillingHalf;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Grill")
            GrillingHalf = GetHalf();
            // GrillingHalf.StartGrilling();
            
    }

    void OnTriggerExit()
    {
        // GrillingHalf.StopGrilling();
    }

    private GameObject GetHalf()
    {
        float upAngle = Quaternion.Angle(Quaternion.Euler(-90, 0, 0), transform.rotation);
        float downAngle = Quaternion.Angle(Quaternion.Euler(90, 0, 0), transform.rotation);
        return upAngle < downAngle ? UpperHalf : LowerHalf;
    }
}
