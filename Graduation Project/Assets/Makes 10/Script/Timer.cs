﻿using UnityEngine;

namespace Makes10
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] public static float currentTime;
        private void Update()
        {
            currentTime += Time.deltaTime;
        }
    }

}