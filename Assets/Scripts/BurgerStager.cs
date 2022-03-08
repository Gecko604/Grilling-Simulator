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
    private bool onGrill = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Agony: Unity crashed");

        if (gameObject.GetComponent<MeshRenderer>().material == null) { Debug.Log("Missing MeshRenderer"); return; };

        //gameObject.GetComponent<MeshRenderer>().material = Raw;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("life is pain, a stark reminder every frame of this godless project");
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
        Debug.Log("endless torment, why must i be burnt");
        onGrill = true;
    }

    public void StopGrilling()
    {
        Debug.Log("i lament the time when I must burn again, please make it not so.");
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
        Debug.Log("burg cool");
    }
}
