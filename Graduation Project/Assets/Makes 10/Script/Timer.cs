using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Makes10
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] public static float currentTime;
        [SerializeField] private SaveSystem saveSystem;
        private void Update()
        {
            currentTime += Time.deltaTime;
            if (currentTime % 120 >= 60)
            {
                saveSystem.Save();
                //game end
            }
        }
    }

}