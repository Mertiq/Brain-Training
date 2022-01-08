using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    [CreateAssetMenu(fileName ="Game", menuName = "ScriptableObjects/MainMenu/Game")]
    public class Game : ScriptableObject
    {
        public string _name;
        public Sprite image;
        public string description;
        public Category category;
    }

}
