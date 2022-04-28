using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyTracker : MonoBehaviour
{

    [Header("Trigger Variables")]
    public bool OnGrill = false;

    [Header("Penalty Tracking")]
    public ScoreManager trackPenalty;
    public GrillSoundController sounds;
    
    // Start is called before the first frame update
    void Start()
    {
        trackPenalty = FindObjectOfType<ScoreManager>();
        sounds = FindObjectOfType<GrillSoundController>();
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
            StartCoroutine(ViolateSafety(other));
        }
    }

    public void OnTriggerExit(Collider other)
    {
        OnGrill = false;
    }


    public IEnumerator ViolateSafety(Collider collider)
    {
        while(OnGrill)
        {
            sounds.TouchGrill(collider);
            trackPenalty.ApplyPenalty();
            yield return new WaitForSeconds(1);
        }
    }
}
