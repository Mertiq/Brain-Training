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

        private string targetText;

        void Start()
        {
            targetText = WordsList[GetRandomNum()];
            targetTextUi.text = targetText;
        }

        private int GetRandomNum()
        {
            return Random.Range(0, WordsList.Length);
        }

        public void AddCaughtLetter(string letter)
        {
            caughtLettersTextUi.text += letter;
        }
    }
}
