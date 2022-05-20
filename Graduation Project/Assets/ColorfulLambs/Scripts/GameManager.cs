using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ColorfulLambs
{
    public class GameManager : MonoBehaviour
    {
        private const float decreaseIntervalValue = 0.05f;
        private const float lowerLimitInterval = 0.15f;
        private const int incCountPerLevel = 4;

        public static Action<int> onClickLight;

        [SerializeField] private Light[] lights;

        [SerializeField] private RectTransform failScreen;
        [SerializeField] private RectTransform congScreen;
        [SerializeField] private RectTransform startScreen;
        [SerializeField] private RectTransform gameScreen;
        [SerializeField] private GameObject restartBtn;

        private AudioManager audioManager;

        private TextMeshProUGUI levelText;
        private TextMeshProUGUI bestScoreText;
        private TextMeshProUGUI newBestScoreText;
        private Button nextButton;

        private float timeIntervalBetweenLights = 1f;
        private int turnOnLightCount = 4;

        private List<Light> turnOnOrder;
        private int pressedCount = 0;
        private int level = 1;

        void Start()
        {
            audioManager = GetComponent<AudioManager>();
            newBestScoreText = failScreen.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            levelText = gameScreen.GetChild(0).GetComponent<TextMeshProUGUI>();
            bestScoreText = gameScreen.GetChild(1).GetComponent<TextMeshProUGUI>();
            nextButton = gameScreen.GetChild(2).GetComponent<Button>();
            bestScoreText.text = "Best Score: " + GetBestScore().ToString();
            turnOnOrder = new List<Light>();
        }

        private void OnEnable()
        {
            onClickLight += OnClickLight;
        }

        private IEnumerator TurnOnLightsRoutine()
        {
            int index = 0;
            audioManager.PlaySound("colorfulLambs_startSound");
            yield return new WaitForSeconds(2f);

            while (index < turnOnLightCount)
            {
                yield return new WaitForSeconds(1f);
                TurnOnRndLight(index++);
            }

            EnableLightButtons();
            yield break;
        }

        public void GenerateRandomList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                int rnd = UnityEngine.Random.Range(0, lights.Length);
                turnOnOrder.Add(lights[rnd]);
            }

            StartCoroutine(TurnOnLightsRoutine());
        }

        private void TurnOnRndLight(int index)
        {
            audioManager.PlaySound("colorfulLambs_turnOnSound");
            turnOnOrder[index].TurnOnLight();
        }

        private void EnableLightButtons()
        {
            foreach (Light light in lights)
            {
                light.EnableInteraction();
            }
        }

        private void DisableLightButtons()
        {
            foreach (Light light in lights)
            {
                light.DisableInteraction();
            }
        }

        private void OnClickLight(int index)
        {
            if (turnOnOrder[pressedCount].index == index)
            {
                audioManager.PlaySound("colorfulLambs_rightClickSound");

                if (pressedCount == turnOnOrder.Count - 1)
                {
                    OnPlayerSucceed();
                }
            }
            else
            {
                audioManager.PlaySound("colorfulLambs_failSound");
                StartCoroutine(OpenFailScreen());
            }

            pressedCount++;
        }

        private void OnPlayerSucceed()
        {
            nextButton.gameObject.SetActive(true);
            audioManager.PlaySound("colorfulLambs_correctSound");
            DisableLightButtons();
        }

        private void SetLevelSettings()
        {
            if (timeIntervalBetweenLights > lowerLimitInterval)
            {
                timeIntervalBetweenLights -= decreaseIntervalValue;
            }

            if (level % incCountPerLevel == 0)
            {
                turnOnLightCount += 1;
            }
        }

        private void SetNewBestScore()
        {
            int bestScore = PlayerPrefs.GetInt("ColorfulLambsBestScore");

            if (bestScore != 0)
            {
                if (bestScore < level)
                {
                    PlayerPrefs.SetInt("ColorfulLambsBestScore", level);
                    newBestScoreText.gameObject.SetActive(true);
                }
            }
            else
            {
                PlayerPrefs.SetInt("ColorfulLambsBestScore", level);
                newBestScoreText.gameObject.SetActive(true);
            }
        }

        private int GetBestScore()
        {
            int bestScore = PlayerPrefs.GetInt("ColorfulLambsBestScore");

            if (bestScore == 0)
            {
                return 1;
            }
            else
            {
                return bestScore;
            }
        }

        private IEnumerator OpenFailScreen()
        {
            failScreen.gameObject.SetActive(true);
            DisableLightButtons();
            SetNewBestScore(); 
            yield return failScreen.DOScale(1.3f, 1f).WaitForCompletion();
            yield return failScreen.DOScale(1f, 0.5f).WaitForCompletion();
            restartBtn.SetActive(true);
        }

        #region Button Methods

        public void StartGameButton()
        {
            startScreen.gameObject.SetActive(false);
            gameScreen.gameObject.SetActive(true);

            GenerateRandomList(4);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void NextRound()
        {
            turnOnOrder.Clear();
            level += 1;
            levelText.text = "Level: " + level.ToString();
            pressedCount = 0;
            SetLevelSettings();
            nextButton.gameObject.SetActive(false);
            GenerateRandomList(turnOnLightCount);
        }

        #endregion

        private void OnDisable()
        {
            onClickLight -= OnClickLight;
        }
    }
}