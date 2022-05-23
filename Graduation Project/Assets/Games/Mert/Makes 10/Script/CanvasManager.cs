using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Makes_10.Script
{
    
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText; 
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private Text newScoreText;
        [SerializeField] private Text highScoreText;
        [SerializeField] private SaveSystem saveSystem;
    
        public TextMeshProUGUI ScoreText
        {
            get => scoreText;
            set => scoreText = value;
        }
       
        private void ShowEndGamePanel()
        {
            highScoreText.text = saveSystem.LoadHighScore().ToString();
            newScoreText.text = saveSystem.NewScore.ToString();
            endGamePanel.SetActive(true);
            MainMenuAnimationController.VeryVeryShake(endGamePanel);
            Invoke(nameof(StopScale), 0.5f);
            
        }
        public void StopScale()
        {
            Time.timeScale = 0;
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
