using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryMatchingGame { 
    public class ScoreManager : MonoBehaviour
    {
        public static int score=0;
        public static int collectedCardsCount = 0;

        public static void IncreaseScore()
        {
            score += 1000;
            collectedCardsCount += 2;
        }
    }
}