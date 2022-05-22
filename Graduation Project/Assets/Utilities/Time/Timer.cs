using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Utilities
{
    public class Timer : MonoBehaviour
    {
        public float currentTime = 0.0f;

        private void Update()
        {
            currentTime += Time.deltaTime;
        }
        public float GetCurrentTime()
        {
            return currentTime;
        }
    }
}
