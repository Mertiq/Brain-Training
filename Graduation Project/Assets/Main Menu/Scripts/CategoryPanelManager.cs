using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class CategoryPanelManager : MonoBehaviour
    {
        public GameObject CategoryCard;
        public GameObject viewport;
        public GamePanelManager gmp;
        public Sprite[] images;
        int count = 0;

        private void Start()
        {
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                GameObject card = Instantiate(CategoryCard, viewport.transform);
                card.GetComponent<CategoryCard>().SetCard(category, images[count++]);
                card.GetComponent<Button>().onClick.AddListener(() => gmp.InitializeGameCards(category));
                card.GetComponent<Button>().onClick.AddListener(() => gameObject.SetActive(false));
                card.GetComponent<Button>().onClick.AddListener(() => MainMenuAnimationController.LittleLittleShake(gmp.cardContainer));
            }
        }
    }
}
