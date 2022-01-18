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
        public void SetCard(Category name, Sprite image)
        {
            nameText.GetComponent<Text>().text = name.ToString();
            imageObject.GetComponent<Image>().sprite = image;
        }
    }
}
