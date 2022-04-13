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

    // Start is called before the first frame update
    void Start()
    {

        if (gameObject.GetComponent<MeshRenderer>().material == null) { Debug.Log("Missing MeshRenderer"); return; };

    }

    // Update is called once per frame
    void Update()
    {
        if (heat >= 10f && heat < 20f)
            gameObject.GetComponent<MeshRenderer>().material = MediumRare;
        else if (heat >= 20f && heat < 30f)
            gameObject.GetComponent<MeshRenderer>().material = WellDone;
        else if (heat >= 30f)
            gameObject.GetComponent<MeshRenderer>().material = Overcooked;

        if (onGrill)
        {
            heat += (1f * Time.deltaTime);
        }
    }

    public void StartGrilling()
    {
        onGrill = true;
    }

    public void StopGrilling()
    {
        if (onGrill)
        {
            onGrill = false;
            StartCoroutine(LatentHeat());
        }
        
        
    }

    public IEnumerator LatentHeat()
    {
        Debug.Log("Let the meat burning commence, Isaiah 12:32");
        float internalHeat = 0;
        while (internalHeat < 5f)
        {
            if (onGrill)
                break;
            heat += (1f);
            yield return new WaitForSeconds(1);
            internalHeat += 1;
        }
    }
}
