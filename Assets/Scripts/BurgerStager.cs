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
    public float heat;
    private bool onGrill;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Agony");
        heat = 0f;
        gameObject.GetComponent<MeshRenderer>().material = Raw;
    }

    // Update is called once per frame
    void Update()
    {
        if (heat > 10f && heat < 20f)
            gameObject.GetComponent<MeshRenderer>().material = MediumRare;
        else if (heat > 20f && heat < 30f)
            gameObject.GetComponent<MeshRenderer>().material = WellDone;
        else if (heat > 30f)
            gameObject.GetComponent<MeshRenderer>().material = Overcooked;
    }

    public void StartGrilling()
    {
        onGrill = true;
        while (onGrill)
        {
            heat += (1f * Time.deltaTime);
        }
    }

    public void StopGrilling()
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
