using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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

        string[] productNames = {"Bread", "Coke", "Ayran", "Cigkofte", "Toy", "Soap", "Water", "Orange"};

        private void Start()
        {
            totalText.text = LocalizationSystem.GetLocalizedValue(totalText.text);
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

        void SetProductPricesToZero()
        {
            for (int i = 0; i < productPriceTexts.Length; i++)
            {
                productPriceTexts[i].text = "";
                productNameTexts[i].text = "";
            }
        }
        
    }
} 

