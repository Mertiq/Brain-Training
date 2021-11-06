using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class CategoryCard : MonoBehaviour
    {
        public GameObject nameText;
        public void SetName(string name)
        {
            nameText.GetComponent<Text>().text = name;
        }
    }
}
