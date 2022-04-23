using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CashierGame
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

