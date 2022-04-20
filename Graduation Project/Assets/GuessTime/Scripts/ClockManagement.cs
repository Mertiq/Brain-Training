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

    private void Awake()
    {
        
    }
    private void Start()
    {
        StartCoroutine(GameTimer());
    }
    IEnumerator GameTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if (minute >= 55)
            {
                hour++;
                minute = 0;
            }
            else
            {
                minute += 5;
            }
            Debug.Log("Hour: " + hour + ", Min: " + minute);
            iTween.RotateTo(minuteHand, iTween.Hash("z", minute * 6 * -1, "time", 1, "easetype", "easeOutElasic"));
            float hourDistance = (float)(minute) / 60f;
            iTween.RotateTo(hourHand, iTween.Hash("z", (hour + hourDistance) * 360 / 12 * -1, "time",1, "easetype", "easeOutElastic"));
        }
        
    }

    public void GenerateRandomClock()
    {
        int randomHour = Random.Range(0, 12);
        int randomMin = Random.Range(0, 60);
    }
}
