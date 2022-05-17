using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorfulLambs
{
    public class GameManager : MonoBehaviour
    {
        public static Action<int> onClickLight;
        [SerializeField] private Light[] lights;
        private List<int> randomList;
        private List<int> uniqueNumbers;
        private List<Light> turnOnOrder;
        private int pressedCount = 0;

        void Start()
        {
            turnOnOrder = new List<Light>();
            randomList = new List<int>();
            uniqueNumbers = new List<int>();
            GenerateRandomList();
            StartCoroutine(TurnOnLightsRoutine());
        }

        private void OnEnable()
        {
            onClickLight += OnClickLight;
        }

        private IEnumerator TurnOnLightsRoutine()
        {
            int index = 0;
            yield return new WaitForSeconds(2f);
            TurnOnRndLight(index++);
            yield return new WaitForSeconds(1f);
            TurnOnRndLight(index++);
            yield return new WaitForSeconds(1f);
            TurnOnRndLight(index++);
            yield return new WaitForSeconds(1f);
            TurnOnRndLight(index++);
            EnableLightButtons();
        }
        public void GenerateRandomList()
        {
            for (int i = 0; i < 4; i++)
            {
                uniqueNumbers.Add(i);
            }
            for (int i = 0; i < 4; i++)
            {
                int ranNum = uniqueNumbers[UnityEngine.Random.Range(0, uniqueNumbers.Count)];
                randomList.Add(ranNum);
                uniqueNumbers.Remove(ranNum);
            }
        }

        private void TurnOnRndLight(int index)
        {
                lights[randomList[index]].TurnOnLight();
                turnOnOrder.Add(lights[randomList[index]]);

        }

        private void EnableLightButtons()
        {
            foreach (Light light in lights)
            {
                light.EnableInteraction();
            }
        }



        private void OnClickLight(int index)
        {
            if (turnOnOrder[pressedCount].index == index)
            {
                Debug.Log("dogru");

                if (pressedCount == turnOnOrder.Count - 1)
                {
                    Debug.Log("bitti");
                }
            }
            else
            {
                Debug.Log("yanlış");
            }

            pressedCount++;
        }

        private void OnDisable()
        {
            onClickLight -= OnClickLight;
        }
    }
}