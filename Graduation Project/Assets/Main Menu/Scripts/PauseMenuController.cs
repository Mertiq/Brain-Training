using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class PauseMenuController : MonoBehaviour
    {
        public void Pause(GameObject pausePanel)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void Continue(GameObject pausePanel)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void MainMenu()
        {
            Time.timeScale = 1;
            Screen.orientation = ScreenOrientation.Portrait;
            SceneManager.LoadScene("Main Menu");
        }
    }
}

