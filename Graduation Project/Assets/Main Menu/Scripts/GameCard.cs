using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class GameCard : MonoBehaviour
    {
        public GameObject nameText;
        public GameObject descriptionText;
        public GameObject imageObject;
        public string sceneName;
        public void SetGameCard(string name, string description, Sprite image)
        {
            sceneName = name;
            nameText.GetComponent<Text>().text = name;
            descriptionText.GetComponent<Text>().text = description;
            imageObject.GetComponent<Image>().sprite = image;
        }
    }
}
