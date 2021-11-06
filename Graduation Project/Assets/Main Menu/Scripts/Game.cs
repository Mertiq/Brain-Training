using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public enum Category{
        MATH,
        PHYSICS,
    }

    [CreateAssetMenu(fileName ="Game", menuName = "ScriptableObjects/MainMenu/Game")]
    public class Game : ScriptableObject
    {
        public string _name;
        public Sprite image;
        public string description;
        public Category category;
    }

}
