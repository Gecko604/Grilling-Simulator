using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillSoundController : MonoBehaviour
{

    [Header("Burger Sizzles")]
    public AudioClip sizzleOne;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Burger")
        {
            print("Burger Placed");
            AudioSource.PlayClipAtPoint(sizzleOne, other.transform.position, 1f);
        }
    }
}
