using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyTracker : MonoBehaviour
{
    public bool OnGrill = false;
    public ScoreManager trackPenalty;
    public AudioSource grillSound;
    
    // Start is called before the first frame update
    void Start()
    {
        trackPenalty = FindObjectOfType<ScoreManager>();
        grillSound = GetComponent<AudioSource>();
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
            grillSound.Play(0);
            yield return new WaitForSeconds(1);
        }
    }
}
