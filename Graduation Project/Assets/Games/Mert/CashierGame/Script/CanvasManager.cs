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
        public Text customerMoneyText;
        public Text changeText;
        
        public TextMeshProUGUI scoreText;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private Text newScoreText;
        [SerializeField] private Text highScoreText;
        [SerializeField] private SaveSystem saveSystem;
        [SerializeField] private Image customerPhoto;
        
        public void SetProductText(int receiptIndex, string productName, float productPrice)
        {
            productNameTexts[receiptIndex].text = productName;
            productPriceTexts[receiptIndex].text = productPrice.ToString();
        }

        public void SetTotalText(float totalProductPrice, float customerMoney)
        {
            totalProductPriceText.text = totalProductPrice.ToString();
            customerMoneyText.text = customerMoney.ToString();
            changeText.text = "0";
        }
        
        public void SetChangeText(float change)
        {
            changeText.text = change.ToString();
        }

        public void SetProductPricesToZero()
        {
            for (var i = 0; i < productPriceTexts.Length; i++)
            {
                productPriceTexts[i].text = "";
                productNameTexts[i].text = "";
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

        public void SetCustomerPhoto(Sprite photo)
        {
            customerPhoto.sprite = photo;
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

