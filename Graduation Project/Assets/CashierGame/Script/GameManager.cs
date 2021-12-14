using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace CashierGame
{
    public class GameManager : MonoBehaviour
    {
        float totalProductPrice;
        float customerMoney;
        float change = 0;

        private void Start()
        {
            CreateNewLevel();
        }

        void CreateNewLevel()
        {
            change = 0;
            float tempTotalProductPrice = 0;
            float tempCustomerMoney;

            List<float> tempProductPrices = new List<float>();

            int rand = UnityEngine.Random.Range(1, 4);
            for (int i = 0; i < rand; i++)
            {
                int price = UnityEngine.Random.Range(1, 20);
                tempProductPrices.Add(price);
                tempTotalProductPrice += tempProductPrices[i];
            }

            tempCustomerMoney = UnityEngine.Random.Range(tempTotalProductPrice+.25f, tempTotalProductPrice * 2.2f);
            tempCustomerMoney = Roll(tempCustomerMoney);
            totalProductPrice = tempTotalProductPrice;
            customerMoney = tempCustomerMoney;

            GetComponent<CanvasManager>().SetTexts(tempProductPrices, totalProductPrice, customerMoney, change);
        }

        float Roll(float a)
        {
            // if given parameter is 88.71, it will return 88.50.
            return System.Convert.ToSingle(System.Math.Round(a - (System.Math.Round(a, 2) % 0.25f), 2));
        }

        public void AddChanges(float a)
        {
            change += a;
            GetComponent<CanvasManager>().SetChangeText(change);
        }

        public void Control()
        {
            if (totalProductPrice + change == customerMoney)
            {
                Invoke("CreateNewLevel", .75f);
            }
        }

        public void DeleteChange()
        {
            change = 0;
            GetComponent<CanvasManager>().SetChangeText(change);
        }

    }
}

