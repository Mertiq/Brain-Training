﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Utilities
{
    public class Timer : MonoBehaviour
    {
        public static float currentTime = 0.0f;

        private void Update()
        {
            currentTime += Time.deltaTime;
        }
        public static float GetCurrentTime()
        {
            return currentTime;
        }
    }
}
