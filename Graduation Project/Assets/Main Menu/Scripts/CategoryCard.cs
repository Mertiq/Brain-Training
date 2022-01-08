using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public enum Category
    {
        MATH,
        MEMORY,
    }


    public class CategoryCard : MonoBehaviour
    {
        public GameObject nameText;
        public GameObject imageObject;
        public void SetCard(string name, Sprite image)
        {
            nameText.GetComponent<Text>().text = name;
            imageObject.GetComponent<Image>().sprite = image;
        }
    }
}
