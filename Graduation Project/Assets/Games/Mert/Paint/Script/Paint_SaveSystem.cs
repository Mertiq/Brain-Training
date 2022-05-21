using System;
using UnityEngine;
using Utilities;

namespace Paint.Script
{
    public class Paint_SaveSystem : MonoBehaviour
    {
        [SerializeField] private string gameName;
        [SerializeField] private float newScore;
        [SerializeField] private Timer timer;
        
        
        public float NewScore
        {
            get => newScore;
            set => newScore = value;
        }
        
        public delegate void ScoreSaved ();
        public static event ScoreSaved OnScoreSaved;    
        
        private void SaveNewScore()
        {
            newScore = (float) Math.Round(timer.currentTime, 2);
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
            Paint_GameManager.OnGameEnd += SaveNewScore;
        }

        private void OnDisable()
        {
            Paint_GameManager.OnGameEnd -= SaveNewScore;
        }
    }
}