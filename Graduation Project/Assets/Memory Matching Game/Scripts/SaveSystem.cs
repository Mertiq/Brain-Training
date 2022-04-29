using System;
using UnityEngine;

namespace MemoryMatchingGame
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
            newScore = (float) Math.Round(Timer.currentTime, 2);
            if (newScore < LoadHighScore())
            {
                SaveHighScore(newScore);
            }
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