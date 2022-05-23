using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MemoryMatchingGame
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private Text collectedCardsText;
        [SerializeField] private Text newScoreText;
        [SerializeField] private Text highScoreText;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private SaveSystem saveSystem;

        
        private void Update()
        {
            collectedCardsText.text = GameManager.collectedCardsCount + "/20";
        }
        private void ShowEndGamePanel()
        {
            endGamePanel.SetActive(true);
            MainMenuAnimationController.VeryVeryShake(endGamePanel);
            Time.timeScale = 0;
            highScoreText.text = saveSystem.LoadHighScore().ToString(CultureInfo.CurrentCulture);
            newScoreText.text = saveSystem.NewScore.ToString(CultureInfo.CurrentCulture);
        }

        private void OnEnable()
        {
            SaveSystem.OnScoreSaved += ShowEndGamePanel;
        }
        
        private void OnDisable()
        {
            SaveSystem.OnScoreSaved -= ShowEndGamePanel;
        }
    }
}

