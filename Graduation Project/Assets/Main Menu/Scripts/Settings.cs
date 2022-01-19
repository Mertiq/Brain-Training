using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class Settings : MonoBehaviour
    {
        public void ChangeLanguage(Dropdown dropdown)
        {

            if (dropdown.options[dropdown.value].text == "English")
            {
                LocalizationSystem.language = LocalizationSystem.Language.English;
            }
            else
            {
                LocalizationSystem.language = LocalizationSystem.Language.Turkce;
            }


        }
    }
}