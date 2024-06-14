using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour
{
    public Text textComponent; 
    public float fadeInTime = 2.0f; 

    private float elapsedTime = 0.0f;

    void Start()
    {
        
        if (textComponent == null)
        {
            textComponent = GetComponent<Text>();
        }
    }

    void Update()
    {
        
        if (textComponent != null && textComponent.text.Length > 0)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeInTime); 

            
            Color textColor = textComponent.color;
            textColor.a = alpha;
            textComponent.color = textColor;

            
            if (alpha >= 1.0f)
            {
                this.enabled = false;
            }
        }
    }
}