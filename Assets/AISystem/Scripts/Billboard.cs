using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam = null;

    void Start()
    {
        // Look for VR player camera
        if (GameObject.Find("VRCamera") != null) { cam = GameObject.Find("VRCamera").transform; return; }
   
        // Look for 2D player camera
        if (GameObject.Find("FallbackObjects") != null) { cam = GameObject.Find("FallbackObjects").transform; return; }

        // No Camera in scene
        Debug.Log("No Camera found!");


    }
    //Late Update is called once per frame after Update()
    void LateUpdate()
    {
        if (cam == null) { attachCamera(); }
        
        transform.LookAt(transform.position + cam.forward);
    }

    private void attachCamera()
    {
        // Look for VR player camera
        if (GameObject.Find("VRCamera") != null) { cam = GameObject.Find("VRCamera").transform; return; }
        // Look for 2D player camera
        if (GameObject.Find("FallbackObjects") != null) { cam = GameObject.Find("VRCamera").transform; return; }
    }
}
