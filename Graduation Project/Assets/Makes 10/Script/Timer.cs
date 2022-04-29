using UnityEngine;

namespace Makes_10.Script
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