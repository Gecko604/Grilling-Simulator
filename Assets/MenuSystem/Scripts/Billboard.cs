using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    //Late Update is called once per frame after Update()
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
