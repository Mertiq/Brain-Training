using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class GamePanelManager : MonoBehaviour
    {
        public GameObject gameCard;
        public GameObject cardContainer;
        
        Game[] games;

        private void Awake()
        {
            games = Resources.LoadAll<Game>("MainMenu/Games");
        }
        public void InitializeGameCards(string category)
        {
            gameObject.SetActive(true);
            int counter = 0;
            foreach (var game in games)
            {
                if(game.category.ToString() == category)
                {
                    gameCard.GetComponent<GameCard>().SetGameCard(game._name, game.description, game.image);
                    Instantiate(gameCard, cardContainer.transform);
                    counter++;
                }
            }
            SetCardContainerOffset(counter);
        }

        void SetCardContainerOffset(int gamesCount)
        {
            int cardHeight = ResourceManager.instance.offsetIncreaseValueCardContainer;
            int bottomPadding = ResourceManager.instance.bottomPaddingForGameCardContainer;
            int defaultSize = ResourceManager.instance.defaultCardContainerSize;
            RectTransform rectTransform = cardContainer.GetComponent<RectTransform>();
            cardContainer.GetComponent<RectTransform>().offsetMin = new Vector2(rectTransform.offsetMin.x, -1*((Mathf.Ceil((gamesCount / 2f)) * cardHeight) + bottomPadding - defaultSize));
        }
    }
}
