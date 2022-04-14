using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCooker : MonoBehaviour
{
    [Header("Burger Halves")]
    public GameObject topBurger;
    public GameObject bottomBurger;

    private AudioSource grillingSound;


    // Start is called before the first frame update
    void Start()
    {
        if (topBurger.GetComponent<BurgerStager>() == null) { Debug.Log("Missing UpperStager"); };
        if (bottomBurger.GetComponent<BurgerStager>() == null) { Debug.Log("Missing LowerStager"); };

        grillingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Grill")
        {
            print("playing sound");
            grillingSound.Play();
            if (GetHalf())
            {
                topBurger.GetComponent<BurgerStager>().StartGrilling();
            }
            else
            {
                bottomBurger.GetComponent<BurgerStager>().StartGrilling();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
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
        if(topBurger.transform.position.y > bottomBurger.transform.position.y)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
