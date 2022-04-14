using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCooker : MonoBehaviour
{
    [Header("Burger Halves")]
    public GameObject topBurger;
    public GameObject bottomBurger;

    private AudioSource grillingSound;
    //public BurgerStager UpperStager;
    //public BurgerStager LowerStager;


    // Start is called before the first frame update
    void Start()
    {
        if (topBurger.GetComponent<BurgerStager>() == null) { Debug.Log("Missing UpperStager"); };
        if (bottomBurger.GetComponent<BurgerStager>() == null) { Debug.Log("Missing LowerStager"); };

        grillingSound = GetComponent<AudioSource>();
        //Debug.Log("BurgerCooker.cs Start");
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"OnTriggerEnter other: {other.gameObject}");
        if (other.transform.tag == "Grill")
        {
            print("playing sound");
            grillingSound.Play();
            if (GetHalf())
            {
                //Debug.Log("Upper start grilling");
                topBurger.GetComponent<BurgerStager>().StartGrilling();
                //Debug.Log("Upper started grilling");
            }
            else
            {
                //Debug.Log("Lower start grilling");
                bottomBurger.GetComponent<BurgerStager>().StartGrilling();
                //Debug.Log("Lower started grilling");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log($"OnTriggerExit other: {other.gameObject}");
        if (other.transform.tag == "Grill")
        {
            print("stopping sound");
            grillingSound.Stop();
            bottomBurger.GetComponent<BurgerStager>().StopGrilling();
            topBurger.GetComponent<BurgerStager>().StopGrilling();
        }
    }

    private bool GetHalf()
    {
        //float upAngle = Quaternion.Angle(Quaternion.Euler(0, -90, 0), transform.rotation);
        //float downAngle = Quaternion.Angle(Quaternion.Euler(0, 90, 0), transform.rotation);
        //Debug.Log($"GetHalf() upAngle: {upAngle} downAngle: {downAngle}");

        if(topBurger.transform.position.y > bottomBurger.transform.position.y)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
