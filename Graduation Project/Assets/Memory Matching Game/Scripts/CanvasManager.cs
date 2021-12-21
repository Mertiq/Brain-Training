using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MemoryMatchingGame
{
    public class CanvasManager : MonoBehaviour
    {
        public Text scoreText;
        public Text collectedCardsText;

        public void PauseButton()
        {

        }

        private void Update()
        {
            collectedCardsText.text = ScoreManager.collectedCardsCount + "/20";
            scoreText.text = ScoreManager.score.ToString();
        }
    }
}

