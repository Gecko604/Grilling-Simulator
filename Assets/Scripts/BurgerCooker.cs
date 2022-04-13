using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCooker : MonoBehaviour
{
    [Header("Burger Halves")]
    public GameObject topBurger;
    public GameObject bottomBurger;

    //public BurgerStager UpperStager;
    //public BurgerStager LowerStager;


    // Start is called before the first frame update
    void Start()
    {
        if (topBurger.GetComponent<BurgerStager>() == null) { Debug.Log("Missing UpperStager"); };
        if (bottomBurger.GetComponent<BurgerStager>() == null) { Debug.Log("Missing LowerStager"); };

<<<<<<< HEAD
=======
        //Debug.Log("BurgerCooker.cs Start");
>>>>>>> 06080f1c5d60f8c2b47dd4b4250a4b2003adfd93
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD
=======
        //Debug.Log($"OnTriggerEnter other: {other.gameObject}");
>>>>>>> 06080f1c5d60f8c2b47dd4b4250a4b2003adfd93
        if (other.transform.tag == "Grill")
        {
            if (GetHalf())
            {
<<<<<<< HEAD
                topBurger.GetComponent<BurgerStager>().StartGrilling();
            }
            else
            {
                bottomBurger.GetComponent<BurgerStager>().StartGrilling();
=======
                //Debug.Log("Upper start grilling");
                topBurger.GetComponent<BurgerStager>().StartGrilling();
                //Debug.Log("Upper started grilling");
            }
            else
            {
                //Debug.Log("Lower start grilling");
                bottomBurger.GetComponent<BurgerStager>().StartGrilling();
                //Debug.Log("Lower started grilling");
>>>>>>> 06080f1c5d60f8c2b47dd4b4250a4b2003adfd93
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
<<<<<<< HEAD
=======
        //Debug.Log($"OnTriggerExit other: {other.gameObject}");
>>>>>>> 06080f1c5d60f8c2b47dd4b4250a4b2003adfd93
        if (other.transform.tag == "Grill")
        {
            bottomBurger.GetComponent<BurgerStager>().StopGrilling();
            topBurger.GetComponent<BurgerStager>().StopGrilling();
        }
    }

    private bool GetHalf()
    {
<<<<<<< HEAD
=======
        //float upAngle = Quaternion.Angle(Quaternion.Euler(0, -90, 0), transform.rotation);
        //float downAngle = Quaternion.Angle(Quaternion.Euler(0, 90, 0), transform.rotation);
        ////Debug.Log($"GetHalf() upAngle: {upAngle} downAngle: {downAngle}");
>>>>>>> 06080f1c5d60f8c2b47dd4b4250a4b2003adfd93

        if(topBurger.transform.position.y > bottomBurger.transform.position.y)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
