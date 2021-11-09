using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace CashierGame
{
    public class CanvasManager : MonoBehaviour
    {
        public Text[] productPriceTexts;

        public Text totalProductPriceText;
        public Text customerMoneyText;
        public Text changeText;

        string[] productNames = { "ekmek", "kola", "ayran", "çiğköfte" };

        public void SetTexts(List<float> productPrices, float totalProductPrice, float customerMoney, float change)
        {
            SetProductPricesToZero();
            for (int i = 0; i < productPrices.Count; i++)
            {
                productPriceTexts[i].text = productNames[UnityEngine.Random.Range(0, productNames.Length)] + ": " + productPrices[i].ToString();
            }
            totalProductPriceText.text = "Total: " + totalProductPrice.ToString();
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
            }
        }
        
    }
} 

