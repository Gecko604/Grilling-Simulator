using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FadeOut : MonoBehaviour
{
    public CanvasGroup cText;
    public float alphaSpeed = 1.0f;


    // Update is called once per frame
    void Update()
    {

        cText.alpha = Mathf.Lerp(cText.alpha, 0.0f, alphaSpeed * Time.deltaTime);
        if (cText.alpha < 0.01f)
        {
            Destroy(gameObject);
        }
        
    }
}
