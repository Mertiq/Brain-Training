using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class SceneChanger : MonoBehaviour
    {
        private string _sceneName;
        public void LoadScene(GameCard gameCard)
        {
            _sceneName = gameCard.sceneName;
            Invoke(nameof(LoadSceneWithDelay),.5f);
        }

        public void LoadSceneWithDelay()
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
