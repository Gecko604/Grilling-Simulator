using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteOrder : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    
    // Start is called before the first frame update
    void Start()
    {
        //Get reference to HUD's score manager
        scoreManager = GameObject.Find("HUD").GetComponent<ScoreManager>();

        //Test
        //scoreManager.CreateTransaction(32);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Burger")
        {
            Destroy(other.gameObject);
            scoreManager.CreateTransaction(5);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
