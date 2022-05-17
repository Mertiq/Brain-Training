using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TopPanelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
  
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
    }
}
