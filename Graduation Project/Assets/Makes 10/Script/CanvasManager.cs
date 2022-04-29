using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Makes_10.Script
{
    
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private Text newScoreText;
        [SerializeField] private Text highScoreText;
        [SerializeField] private SaveSystem saveSystem;
        public TextMeshProUGUI TimeText
        {
            get => timeText;
            set => timeText = value;
        }

        public TextMeshProUGUI ScoreText
        {
            get => scoreText;
            set => scoreText = value;
        }
        private void Update()
        {
            SetTimeText(Timer.currentTime);
        }
        
        private void SetTimeText(float currentTime)
        {
            int seconds = (int) currentTime % 60;
            int minute = (int) currentTime / 60;

            if (seconds < 10 && minute < 10)
            {
                timeText.text = "0" + minute + ":0" + seconds;
            }
            else if (seconds < 10)
            {
                timeText.text = minute + ":0" + seconds;
            }
            else if (minute < 10)
            {
                timeText.text = "0" + minute + ":" + seconds;
            }
            
        }
        private void ShowEndGamePanel()
        {
            endGamePanel.SetActive(true);
            highScoreText.text = saveSystem.LoadHighScore().ToString();
            newScoreText.text = saveSystem.NewScore.ToString();
        }
        
        private void SetScoreText(int score)
        {
            scoreText.text = score.ToString();
        }

        private void OnEnable()
        {
            GameManager.OnScoreChanged += SetScoreText;
            SaveSystem.OnScoreSaved += ShowEndGamePanel;
        }

        private void OnDisable()
        {
            GameManager.OnScoreChanged -= SetScoreText;
            SaveSystem.OnScoreSaved -= ShowEndGamePanel;
        }
    }
}
