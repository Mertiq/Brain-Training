using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

namespace TowerOfHanoi
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Stick targetStick;
        [SerializeField] private int totalBlockCount;

        [SerializeField] private TextMeshProUGUI moveCountText;
        [SerializeField] private TextMeshProUGUI tutorialText;
        [SerializeField] private TextMeshProUGUI endGameText;
        [SerializeField] private TextMeshProUGUI timer;
        [SerializeField] private GameObject button;

        private int moveCount = 0;
        private int time = 0;

        private void Start()
        {
            StartCoroutine(TutorialRoutine());
            StartCoroutine(TimerRoutine());
        }

        private void OnEnable()
        {
            Block.OnBlockPlaced += OnBlockPlaced;
        }

        private void OnBlockPlaced()
        {
            moveCountText.text = "Move Count: " + (++moveCount).ToString();

            if (targetStick.blocks.Count == totalBlockCount)
            {
                StartCoroutine(EndGameRoutine());
            }
        }

        private IEnumerator TimerRoutine()
        {
            yield return new WaitForSeconds(1f);
            timer.text = "Time: " + (++time).ToString();
            StartCoroutine(TimerRoutine());
        }

        private IEnumerator TutorialRoutine()
        {
            yield return tutorialText.DOFade(0f, 3f).WaitForCompletion();
        }

        private IEnumerator EndGameRoutine()
        {
            endGameText.DOFade(1f, 1.25f);
            yield return endGameText.transform.DOScale(new Vector3(1f, 1f, 1f), 1.25f).WaitForCompletion();
            yield return endGameText.transform.DOScale(new Vector3(.75f, .75f, 1f), 1.25f).SetLoops(6, LoopType.Yoyo).WaitForCompletion();
            button.SetActive(true);
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnDisable()
        {
            Block.OnBlockPlaced -= OnBlockPlaced;
        }
    }
}