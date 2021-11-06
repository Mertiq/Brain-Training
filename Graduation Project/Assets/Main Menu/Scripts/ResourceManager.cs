using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MainMenu
{
    public class ResourceManager : ScriptableSingleton<ResourceManager>
    {
        public int offsetIncreaseValueCardContainer = 1000;
        public int bottomPaddingForGameCardContainer = 50;
        public int defaultCardContainerSize = 2000;
    }
}
