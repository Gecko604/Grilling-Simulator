using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCooker : MonoBehaviour
{
    [Header("Burger Halves")]
    // public GameObject UpperHalf;
    // public GameObject LowerHalf;
    public BurgerStager UpperStager;
    public BurgerStager LowerStager;


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
        {
            if (GetHalf())
                UpperStager.StartGrilling();
            else
                LowerStager.StartGrilling();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Grill")
        {
            if (GetHalf())
                UpperStager.StopGrilling();
            else
                LowerStager.StopGrilling();
        }
    }

    private bool GetHalf()
    {
        float upAngle = Quaternion.Angle(Quaternion.Euler(-90, 0, 0), transform.rotation);
        float downAngle = Quaternion.Angle(Quaternion.Euler(90, 0, 0), transform.rotation);
        return upAngle < downAngle;
    }
}
