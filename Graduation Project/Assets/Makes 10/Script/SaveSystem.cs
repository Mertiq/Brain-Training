using MainMenu;
using UnityEngine;

namespace Makes_10.Script
{
    public class SaveSystem : MonoBehaviour
    {
        [SerializeField] private string gameName;
        [SerializeField] private float newScore;
        
        public float NewScore
        {
            get => newScore;
            set => newScore = value;
        }
        
        public delegate void ScoreSaved ();
        public static event ScoreSaved OnScoreSaved;    
        
        private void SaveNewScore()
        {
            newScore = GameManager.score;
            if (newScore > LoadHighScore())
            {
                SaveHighScore(newScore);
            }
            SkillSystemManager.CalculateSkillPoint(Category.MATH,SkillSystemManager.GameName.Ten,GameManager.score);
            OnScoreSaved?.Invoke();
        }

        public float LoadHighScore()
        {
            return PlayerPrefs.GetFloat(gameName);
        }

        private void SaveHighScore(float highScore)
        {
            PlayerPrefs.SetFloat(gameName,highScore);
        }

        private void OnEnable()
        {
            GameManager.OnGameEnd += SaveNewScore;
        }

        private void OnDisable()
        {
            GameManager.OnGameEnd -= SaveNewScore;
        }
    }
}
