using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClockManagement : MonoBehaviour
{
    // Start is called before the first frame update
    int hour = 0;
    int minute = 0;
    public GameObject minuteHand;
    public GameObject hourHand;
    public Text guessText;
    int exactHour;
    int exactMinute;
    int retryCount;
    float pointScale = 0.2f;
    private void Awake()
    {
        exactHour = GenerateRandomHour();
        exactMinute = GenerateRandomMinute();
        guessText.text = GenerateClockText();
        retryCount = 1;
    }
    private void Start()
    {
        StartCoroutine(GameTimer());
        Invoke(nameof(LostTime), 2.0f);
    }

    private void LostTime()
    {
        guessText.gameObject.SetActive(false);
    }
    IEnumerator GameTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            if (minute >= 45)
            {
                
                hour++;
                if(hour >= 12)
                {
                    hour = 0;
                }
                minute = 0;
            }
            else
            {
                minute += 15;
            }
            Debug.Log("Hour : " + hour + " Minute: " + minute);
            iTween.RotateTo(minuteHand, iTween.Hash("z", minute * 6 * -1, "time", 1, "easetype", "linear"));
            float hourDistance = (float)(minute) / 60f;
            iTween.RotateTo(hourHand, iTween.Hash("z", (hour + hourDistance) * 360 / 12 * -1, "time",1, "easetype", "linear"));
        }
        
    }
    public string GenerateClockText()
    {
        string hourStr = "";
        string minuteStr = "";
        if (exactHour < 10)
        {
            hourStr += "0";
        }
        if(exactMinute < 10)
        {
            minuteStr += "0";
        }
        hourStr += exactHour;
        minuteStr += exactMinute;

        return hourStr + ":" + minuteStr;
    }
    public int GenerateRandomHour()
    {
        return Random.Range(0, 3);
    }
    public int GenerateRandomMinute() {
        int[] quarters  = new int[4] { 0, 15, 30, 45 } ;
        int randomIndex = Random.Range(0, quarters.Length);
        return quarters[randomIndex];
    }
    public bool IsClockGuessed()
    {
        return (hour == exactHour && minute == exactMinute);
    }
    public void PrintGuessResult()
    {
        if (IsClockGuessed())
        {
            float point = CalculatePoint();
            Debug.Log("Yess is guessed!");
            Debug.Log(point);
        }else
        {
            retryCount++;
        }
    }
    public float CalculatePoint()
    {
        float point = (Time.timeSinceLevelLoad * Random.Range(2f, 7f)) / (retryCount * pointScale);
        return point;
    }
}
