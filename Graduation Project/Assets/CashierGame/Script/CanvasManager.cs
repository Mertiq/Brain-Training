using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace CashierGame
{
    public class CanvasManager : MonoBehaviour
    {
        public Text[] productPriceTexts;
        public Text[] productNameTexts;

        public Text totalProductPriceText;
        public Text totalText;
        public Text customerMoneyText;
        public Text changeText;
        
        public TextMeshProUGUI timeText;
        public TextMeshProUGUI scoreText;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private Text newScoreText;
        [SerializeField] private Text highScoreText;
        [SerializeField] private SaveSystem saveSystem;

        private readonly string[] productNames = {"Bread", "Coke", "Ayran", "Cigkofte", "Toy", "Soap", "Water", "Orange"};

        private void Start()
        {
            totalText.text = LocalizationSystem.GetLocalizedValue(totalText.text);
        }

        private void Update()
        {
            SetTimeText(Timer.currentTime);
        }
        
        public void SetTexts(List<float> productPrices, float totalProductPrice, float customerMoney, float change)
        {
            SetProductPricesToZero();
            for (int i = 0; i < productPrices.Count; i++)
            {
                productNameTexts[i].text = LocalizationSystem.GetLocalizedValue(productNames[UnityEngine.Random.Range(0, productNames.Length)]);
                productPriceTexts[i].text = productPrices[i].ToString();
            }

            totalProductPriceText.text = totalProductPrice.ToString();
            customerMoneyText.text = customerMoney.ToString();
            changeText.text = change.ToString();
        }

        public void SetChangeText(float change)
        {
            changeText.text = change.ToString();
        }

        private void SetProductPricesToZero()
        {
            for (var i = 0; i < productPriceTexts.Length; i++)
            {
                productPriceTexts[i].text = "";
                productNameTexts[i].text = "";
            }
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

