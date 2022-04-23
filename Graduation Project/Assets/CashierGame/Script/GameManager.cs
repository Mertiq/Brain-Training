using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace CashierGame
{
    public class GameManager : MonoBehaviour
    {
        private float totalProductPrice;
        private float customerMoney;
        private float change;
        
        [SerializeField] private bool isGameEnd;
        [SerializeField] public static int score;
        [SerializeField] private int gameEndTime;
        
        
        public delegate void GameEnd ();
        public static event GameEnd OnGameEnd;    
        public delegate void ScoreChanged (int score);
        public static event ScoreChanged OnScoreChanged; 
        private void Start()
        {
            FindObjectOfType<AudioManager>().PlaySound("bg");
            CreateNewLevel();
        }

        private void Update()
        {
            if (!(Timer.currentTime >= gameEndTime)) return;
            isGameEnd = true;
            OnGameEnd?.Invoke();
        }

        private void CreateNewLevel()
        {
            change = 0;
            float tempTotalProductPrice = 0;

            var tempProductPrices = new List<float>();

            var rand = UnityEngine.Random.Range(1, 4);
            for (var i = 0; i < rand; i++)
            {
                var price = UnityEngine.Random.Range(1, 20);
                tempProductPrices.Add(price);
                tempTotalProductPrice += tempProductPrices[i];
                FindObjectOfType<AudioManager>().PlaySound("barcode reader");
            }

            var tempCustomerMoney = UnityEngine.Random.Range(tempTotalProductPrice+.25f, tempTotalProductPrice * 2.2f);
            tempCustomerMoney = Roll(tempCustomerMoney);
            totalProductPrice = tempTotalProductPrice;
            customerMoney = tempCustomerMoney;

            GetComponent<CanvasManager>().SetTexts(tempProductPrices, totalProductPrice, customerMoney, change);
        }

        private static float Roll(float a)
        {
            // if given parameter is 88.71, it will return 88.50.
            return Convert.ToSingle(System.Math.Round(a - (System.Math.Round(a, 2) % 0.25f), 2));
        }

        public void AddChanges(float a)
        {
            change += a;
            GetComponent<CanvasManager>().SetChangeText(change);
        }

        public void Control()
        {
            if (totalProductPrice + change != customerMoney)
            {
                FindObjectOfType<AudioManager>().PlaySound("pay fail");
                score -= 10;
                OnScoreChanged?.Invoke(score);
                return;
            }
            FindObjectOfType<AudioManager>().PlaySound("pay success");
            score += 10;
            OnScoreChanged?.Invoke(score);
            Invoke(nameof(CreateNewLevel), .75f);
        }

        public void DeleteChange()
        {
            change = 0;
            GetComponent<CanvasManager>().SetChangeText(change);
        }

    }
}

