﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class GameCard : MonoBehaviour
    {
        public GameObject nameText;
        public GameObject descriptionText;
        public void SetName(string name)
        {
            nameText.GetComponent<Text>().text = name;
        }
        public void SetDescription(string description)
        {
            descriptionText.GetComponent<Text>().text = description;
        }
    }
}