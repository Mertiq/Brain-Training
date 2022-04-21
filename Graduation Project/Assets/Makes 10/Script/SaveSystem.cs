using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Makes10
{
    public class SaveSystem : MonoBehaviour
    {
        [SerializeField] private float highScore;

        private void Start()
        {
            highScore = PlayerPrefs.GetFloat("makes10highscore");
        }

        public void Save()
        {
            float newScore = ScoreManager.score;
            ScoreManager.score = 0;
            if (newScore < highScore)
            {
                PlayerPrefs.SetFloat("makes10highscore", newScore);
                highScore = PlayerPrefs.GetFloat("makes10highscore");
                //yeni higscore
            }
            else
            {
                //olmadı
            }
        }
    }
}
