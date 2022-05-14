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
        
        [SerializeField] private Product[] resourcesProducts;
        [SerializeField] private CanvasManager canvasManager;
        [SerializeField] private List<Sprite> customerPhotos;
        
        
        
        public delegate void GameEnd ();
        public static event GameEnd OnGameEnd;    
        public delegate void ScoreChanged (int score);
        public static event ScoreChanged OnScoreChanged; 
        private void Start()
        {
            canvasManager = GetComponent<CanvasManager>();
            resourcesProducts = Resources.LoadAll<Product>("Cashier Game/Products");
            FindObjectOfType<AudioManager>().PlaySound("bg");
            CreateNewLevel();
        }

        private void Update()
        {
            if(isGameEnd) return;
            if (!(Timer.currentTime >= gameEndTime)) return;
            //SkillSystemManager.IncreaseSkillAndSave("Matematik",50);
            isGameEnd = true;
            OnGameEnd?.Invoke();
            Time.timeScale = 0;
        }

        private void CreateNewLevel()
        {
            canvasManager.SetCustomerPhoto(customerPhotos[UnityEngine.Random.Range(0, customerPhotos.Count)]);
            canvasManager.SetProductPricesToZero();
            change = 0;
            
            float totalCost = 0;
            
            var rand = UnityEngine.Random.Range(1, 4);
            for (var i = 0; i < rand; i++)
            {
                FindObjectOfType<AudioManager>().PlaySound("barcode reader");
                
                var product = resourcesProducts[UnityEngine.Random.Range(0, resourcesProducts.Length)];
                canvasManager.SetProductText(i, product.ProductName, product.ProductPrice);
                
                totalCost += product.ProductPrice;
                
            }
            
            customerMoney = Roll(UnityEngine.Random.Range(totalCost+.25f, totalCost * 2.2f));

            canvasManager.SetTotalText(totalCost,customerMoney);
            totalProductPrice = totalCost;
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
                DeleteChange();
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

