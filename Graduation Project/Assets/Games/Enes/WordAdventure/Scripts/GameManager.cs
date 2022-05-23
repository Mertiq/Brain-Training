using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WordAdventure
{

    public class GameManager : MonoBehaviour
    {
        private readonly string[] WordsList = { "BOX", "PUNCH", "BOMB", "PUSH" };

        [SerializeField] private TMPro.TextMeshProUGUI targetTextUi;
        [SerializeField] private TMPro.TextMeshProUGUI caughtLettersTextUi;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private TextMeshProUGUI endGameText;

        private string targetText;

        void Start()
        {
            targetText = WordsList[GetRandomNum()];
            targetTextUi.text = targetText;
        }

        public void AddCaughtLetter(string letter)
        {
                caughtLettersTextUi.text += letter;
                CheckGameEnd();
        }

        private int GetRandomNum()
        {
            return Random.Range(0, WordsList.Length);
        }

        private void CheckGameEnd()
        {
            for(int i = 0; i < caughtLettersTextUi.text.Length; i++)
            {
                if(caughtLettersTextUi.text[i] != targetText[i])
                {
                    Time.timeScale = 0;
                    endGamePanel.SetActive(true);
                }
                else
                {
                    if(caughtLettersTextUi.text.Length == targetText.Length)
                    {
                        Time.timeScale = 0;
                        endGamePanel.SetActive(true);
                    }
                }
            }
        }
    }
}
