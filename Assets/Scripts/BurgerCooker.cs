using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCooker : MonoBehaviour
{
    [Header("Burger Stages")]
    public Material MaterialOne;
    public Material MaterialTwo;

    [Header("Heat Stuff")]
    public float heat;
    private bool onGrill;

    // Start is called before the first frame update
    void Start()
    {
        heat = 0f;
        gameObject.GetComponent<MeshRenderer>().material = MaterialOne;
    }

    // Update is called once per frame
    void Update()
    {
        if (heat > 20f)
            gameObject.GetComponent<MeshRenderer>().material = MaterialTwo;
        if (onGrill)
            heat += (1f * Time.deltaTime);
    }

    void OnTriggerEnter()
    {
        onGrill = true;
    }

    void OnTriggerExit()
    {
        onGrill = false;
        StartCoroutine(LatentHeat());
    }

    IEnumerator LatentHeat()
    {
        float internalHeat = 0;
        while (internalHeat < 5f)
        {
            if (onGrill)
                break;
            heat += (1f);
            yield return new WaitForSeconds(1);
            internalHeat += 1;
        }
        Debug.Log("burg cool");
    }
}
