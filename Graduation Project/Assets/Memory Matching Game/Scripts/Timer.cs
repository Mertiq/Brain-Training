using TMPro;
using UnityEngine;

namespace MemoryMatchingGame
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