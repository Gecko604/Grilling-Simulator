using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyTracker : MonoBehaviour
{

    [Header("Trigger Variables")]
    public bool OnGrill = false;

    [Header("Penalty Tracking")]
    public ScoreManager trackPenalty;
    
    // Start is called before the first frame update
    void Start()
    {
        trackPenalty = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Hand")
        {
            OnGrill = true;
            StartCoroutine(ViolateSafety());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        OnGrill = false;
    }


    public IEnumerator ViolateSafety()
    {
        while(OnGrill)
        {
            trackPenalty.ApplyPenalty();
            yield return new WaitForSeconds(1);
        }
    }
}
