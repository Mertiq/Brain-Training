using System;
using System.Collections;
using System.Collections.Generic;
using MemoryMatchingGame;
using UnityEngine;
using UnityEngine.UI;

namespace Makes10
{
    
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private Text timeText;
        [SerializeField] private Text scoreText;

        public Text TimeText
        {
            get => timeText;
            set => timeText = value;
        }

        public Text ScoreText
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
        
        private void SetScore(float score)
        {
            scoreText.text = score.ToString();
        }

        private void OnEnable()
        {
            GameManager.onScoreChange += SetScore;
        }

        private void OnDisable()
        {
            GameManager.onScoreChange -= SetScore;
        }
    }
}
