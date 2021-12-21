﻿using System.Collections;
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
        UpdateText();
    }

    public void UpdateText()
    {
        Debug.Log(gameObject.name + " " + text);
        text.text = LocalizationSystem.GetLocalizedValue(text.text);
    }

}