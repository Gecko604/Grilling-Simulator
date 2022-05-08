using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerStager : MonoBehaviour
{
    [Header("Burger Stages")]
    public Material Raw;
    public Material MediumRare;
    public Material WellDone;
    public Material Overcooked;

    [Header("Heat Stuff")]
    public float heat = 0.0f;
    public bool onGrill = false;
    public GameObject smoke;

    public string state = "raw";

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<MeshRenderer>().material == null) { Debug.Log("Missing MeshRenderer"); return; };
    }

    // Update is called once per frame
    void Update()
    {
        if (heat >= 10f && heat < 20f)
        {
            gameObject.GetComponent<MeshRenderer>().material = MediumRare;
            state = "medium rare";
        }

        else if (heat >= 20f && heat < 30f)
        {
            gameObject.GetComponent<MeshRenderer>().material = WellDone;
            state = "well done";
        }
        else if (heat >= 30f)
        {
            gameObject.GetComponent<MeshRenderer>().material = Overcooked;
            state = "overcooked";
        }

        if (onGrill)
        {
            heat += (1f * Time.deltaTime);
        }
    }

    public void StartGrilling()
    {
        smoke.SetActive(true);
        onGrill = true;
    }

    public void StopGrilling()
    {
        if (onGrill)
        {
            smoke.SetActive(false);
            onGrill = false;
            StartCoroutine(LatentHeat());
        }
        
        
    }

    public IEnumerator LatentHeat()
    {
        float internalHeat = 0;
        while (internalHeat < 5f)
        {
            if (onGrill)
                break;
            heat += (1f/3f);
            yield return new WaitForSeconds(1);
            internalHeat += 1;
        }
    }
}
