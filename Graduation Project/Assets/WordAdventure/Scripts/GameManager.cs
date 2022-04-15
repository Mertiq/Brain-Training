using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WordAdventure
{

    public class GameManager : MonoBehaviour
    {
        private readonly string[] WordsList = { "Box", "Punch" };

        [SerializeField] private TMPro.TextMeshProUGUI targetTextUi;

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
    }
}
