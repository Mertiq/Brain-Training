using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class SceneChanger : MonoBehaviour
    {
        public void LoadScene(GameCard gameCard)
        {
            SceneManager.LoadScene(gameCard.sceneName);
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
