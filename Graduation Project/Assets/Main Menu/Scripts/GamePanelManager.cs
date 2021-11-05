using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class GamePanelManager : MonoBehaviour
    {
        public GameObject gameCard;
        public GameObject viewport;
        
        Game[] games;

        private void Start()
        {
            games = Resources.LoadAll<Game>("MainMenu/Games");

            foreach (var game in games)
            {
                gameCard.GetComponent<GameCard>().SetName(game.name);
                Instantiate(gameCard, viewport.transform);
            }

        }


    }
}
