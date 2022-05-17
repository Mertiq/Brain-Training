using UnityEngine;
using UnityEngine.UI;

namespace Paint.Script
{
    public class Paint_CanvasManager : MonoBehaviour
    {
        
        [SerializeField] private Text newScoreText;
        [SerializeField] private Text highScoreText;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private Paint_SaveSystem saveSystem;
        
        private void ShowEndGamePanel()
        {
            endGamePanel.SetActive(true);
            highScoreText.text = saveSystem.LoadHighScore().ToString();
            newScoreText.text = saveSystem.NewScore.ToString();
        }

        private void OnEnable()
        {
            Paint_SaveSystem.OnScoreSaved += ShowEndGamePanel;
        }

        private void OnDisable()
        {
            Paint_SaveSystem.OnScoreSaved -= ShowEndGamePanel;
        }
    }
}