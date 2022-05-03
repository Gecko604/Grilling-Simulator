using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BurgerIngredient")
        {
            Debug.Log("Destroyed!");
            Destroy(other.gameObject);
        }

        Debug.Log($"Detected object : {other.gameObject.name} with tag {other.gameObject.tag}");
    }
}
