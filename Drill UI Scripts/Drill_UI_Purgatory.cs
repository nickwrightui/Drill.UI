using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Drill.UI
{
    public class Drill_UI_Purgatory : MonoBehaviour
    {
        #region Variables

        bool gameIsPaused = true;
        float timer;
        public float waitTime;
        public int respawnCost;

        public Image heartFill;
        public GameObject purgatoryUI;

        #endregion

        #region Main Methods

        public void Update()
        {
            if (gameIsPaused)
            {
                timer += Time.deltaTime;
                TimerCountdown();

                if(timer > waitTime)
                {
                    // death animation added here
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }

        #endregion

        #region Helper Methods

        public void Pause() // Sets game time to 0 
        {
            purgatoryUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

        public void RespawnByCoin() // Sets game time to 1
        {
            if (PlayerPrefs.GetInt("Coins", 0) > respawnCost)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - respawnCost);
                purgatoryUI.SetActive(false);
                Time.timeScale = 1f;
                gameIsPaused = false;
                // respawn player and give "invicible for few seconds"
            }


        }

        public void TimerCountdown()
        {
            float fillPercentage = 1 - (timer / waitTime);
            heartFill.fillAmount = fillPercentage;
            Debug.Log("T-minus " + (waitTime - timer).ToString());
        }

        #endregion
    }
}

