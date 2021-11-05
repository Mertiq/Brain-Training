using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{

    [CreateAssetMenu(fileName ="Game", menuName = "ScriptableObjects/MainMenu/Game")]
    public class Game : ScriptableObject
    {
        public string name;
        public Sprite image;
        public string description;  
    }

}
