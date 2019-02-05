using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Drill.UI
{
    public class Drill_UI_Pause : MonoBehaviour
    {
        #region Variable

        private string objectiveName;

        public bool gameIsPaused = true;
        public GameObject pauseMenuUI;


        #endregion

        #region Main Methods

        public void Start()
        {
            objectiveName = GetComponentInChildren<Text>().name;
        }

        #endregion

        #region Helper Methods

        public void Quit() // Closes Application if Built, Closes Unity Playtest if Demo
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            //SceneManager.LoadScene("MainMenuScene");
            #else
            Application.Quit();
            #endif
        }

        public void Resume() // Sets game time to 1 and sets Pause Menu active to false
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

        public void Pause() // Sets game time to 0 and sets Pause Menu active to true
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

        public void Restart() // Reloads current loaded Scene
        {
            if (SceneManager.GetSceneByName("MainMenuScene") != null)
            {
                SceneManager.LoadScene("MainMenuScene");
            }
            else
            {
                Debug.Log("MainMenuScene does not exist!");
            }

        }
    }
        #endregion

}


