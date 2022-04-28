using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DelayandDestroy(float length)
    {
        yield return new WaitForSeconds(length);
        Destroy(gameObject);
    }
}
