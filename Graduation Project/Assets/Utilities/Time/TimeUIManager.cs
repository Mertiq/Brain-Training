using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Utilities
{
    [RequireComponent(typeof(Timer))]
    public class TimeUIManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timeText;
        private Timer timer;
        private System.Action<GameObject> onTimeSet;

        public void AddOnTimeSetListener(System.Action<GameObject> action)
        {
            onTimeSet += action;
        }
        private void Awake()
        {
            timer = gameObject.GetComponent<Timer>();
        }
        private void Update()
        {
            SetTimeText(Timer.GetCurrentTime());
        }
        private void SetTimeText(float currentTime)
        {
            var seconds = (int)currentTime % 60;
            var minute = (int)currentTime / 60;

            switch (seconds < 10)
            {
                case true when minute < 10:
                    timeText.text = "0" + minute + ":0" + seconds;
                    break;
                case true:
                    timeText.text = minute + ":0" + seconds;
                    break;
                default:
                    {
                        if (minute < 10)
                        {
                            timeText.text = "0" + minute + ":" + seconds;
                        }
                        break;
                    }
            }
            onTimeSet?.Invoke(timeText.gameObject);
        }
    }
}