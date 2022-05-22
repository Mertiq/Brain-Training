using System.Collections;
using System.Collections.Generic;
using Main_Menu.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class GamePanelManager : MonoBehaviour
    {
        public GameObject gameCard;
        public GameObject cardContainer;
        [SerializeField] private GameObject fadePanel;

        
        
        Game[] games;

        private void Awake()
        {
            games = Resources.LoadAll<Game>("MainMenu/Games");
        }

        public void InitializeGameCards(Category category)
        {
            gameObject.SetActive(true);

            for (int i = 0; i < cardContainer.transform.childCount; i++)
            {
                Destroy(cardContainer.transform.GetChild(i).gameObject);
            }

            var counter = 0;
            foreach (var game in games)
            {
                if (game.category != category) continue;
                gameCard.GetComponent<GameCard>().SetGameCard(game._name, game.description, game.image);
                GameObject card = Instantiate(gameCard, cardContainer.transform);
                card.GetComponent<Button>().onClick.AddListener(() => MainMenuAnimationController.FadeInAnim(fadePanel));
                counter++;
            }
            SetCardContainerOffset(counter);
        }

        void SetCardContainerOffset(int gamesCount)
        {
            int cardHeight = ResourceManager.offsetIncreaseValueCardContainer;
            int bottomPadding = ResourceManager.bottomPaddingForGameCardContainer;
            int defaultSize = ResourceManager.defaultCardContainerSize;
            RectTransform rectTransform = cardContainer.GetComponent<RectTransform>();
            cardContainer.GetComponent<RectTransform>().offsetMin = new Vector2(rectTransform.offsetMin.x, -1*((Mathf.Ceil((gamesCount / 2f)) * cardHeight) + bottomPadding - defaultSize));
        }
    }
}
