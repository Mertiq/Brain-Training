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
            SetTimeText(Timer.currentTime);
        }
        
        private void SetTimeText(float currentTime)
        {
            var seconds = (int) currentTime % 60;
            var minute = (int) currentTime / 60;

            switch (seconds < 10)
            {
                case true when minute < 10:
                    timeText.text = "0" + minute + ":0" + seconds;
                    break;
                case true:
                    timeText.text = minute + ":0" + seconds;
                    break;
                default:
                {
                    if (minute < 10)
                    {
                        timeText.text = "0" + minute + ":" + seconds;
                    }
                    break;
                }
            }
        }

        private void ShowEndGamePanel()
        {
            endGamePanel.SetActive(true);
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

