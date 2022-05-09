using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disco : MonoBehaviour
{
    [SerializeField] private Light lightBulb = null;
    // Start is called before the first frame update
    void Start()
    {
        lightBulb = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startDisco()
    {
        StartCoroutine(LerpColor(4));
        
    }

    IEnumerator LerpColor(float duration)
    {

        float time = 0;
        Color startPosition = lightBulb.color;

        Color targetColor = new Color(
             Random.Range(0f, 1f),
             Random.Range(0f, 1f),
             Random.Range(0f, 1f)
         );
        while (time < duration)
        {
            lightBulb.color = Color.Lerp(startPosition, targetColor, time / duration);
            lightBulb.intensity = 3 * time / duration;
            time += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(LerpColor(1));
    }
}
