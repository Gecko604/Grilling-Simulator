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

    private float timer;
    public float framesBetweenTriggers;
    
    // Start is called before the first frame update
    void Start()
    {
        trackPenalty = FindObjectOfType<ScoreManager>();
        sounds = FindObjectOfType<GrillSoundController>();
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 5.0f) 
        {
            timer += Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Hand")
        {
            OnGrill = true;
            StartCoroutine(ViolateSafety(other));
            timer = 0.0f;
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
            yield return new WaitForSeconds(2);
        }
    }
}
