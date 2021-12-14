using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextLocalizerUI : MonoBehaviour
{
    Text text;

    private void Start()
    {
        text = GetComponent<Text>(); 
        text.text = LocalizationSystem.GetLocalizedValue(text.text);
    }

    public void UpdateText()
    {
        text.text = LocalizationSystem.GetLocalizedValue(text.text);
    }
}