using UnityEngine;

namespace CashierGame
{
    [CreateAssetMenu(fileName = "Product", menuName = "ScriptableObjects/CashierGame/Product", order = 1)]
    public class Product : ScriptableObject
    {
        [SerializeField] private string productName;
        [SerializeField] private float productPrice;

        public string ProductName
        {
            get => productName;
            set => productName = value;
        }

        public float ProductPrice
        {
            get => productPrice;
            set => productPrice = value;
        }
    }
}