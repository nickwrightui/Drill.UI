using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace Drill.UI
{
    public class Drill_UI_Manager : MonoBehaviour
    {
        #region Variables

        int isPro; // Has the player purchased Pro, 0 is no, 1 is yes
        private int totalCoinInt; // int that stores players aquired coins
        private int climbedDistance; // int that stores the players climbed distance from last play
        private int highestReach; // int that stores the players highest distance they have reached
        private int bonusCoins; // int that holds bonus coins

        [Header("MainMenuScene Menu's")]
        public GameObject mainMenuWithAds; // Main Menu with banners 
        public GameObject mainMenuPro; // Main Menu without banners

        [Header("Counter")]
        public Text coinCount; // GameObject that displays players coins
        public TextMeshProUGUI climbedCount; // GameObject that displats players climbed distance
        public Text highestReachCount; // GameObject that displays players highest distance reached
        public TextMeshProUGUI bonusCoinCount; // GameObject that displats bonus coins

        public static float masterVolume; // Master Volume level between 0 and 1
        public static float musicVolume; // Music Volume level between 0 and 1
        public static float soundVolume; // Sound Volume level between 0 and 1
        public static bool tiltControls; // Tilt control toggle, 0 for no, 1 for yes

        [Header("Scene Navigation Names")]
        public string shopScene; // String for the name of the shop scene
        public string dailyChallenge; // String for the name of the Daily Challenge Scene
        public string settingsScene;  // String for the name of the settings scene
        public string playGame; // String for the name of the main game level scene
        public string mainMenu; // String for the name of the main menu scene

        [Header("Virtual Control Game Object")]
        public GameObject virtualControls; // GameObjecvt that holds virtual control assets
        
        #endregion

        #region Main Method

        public void Awake()
        {
            masterVolume = PlayerPrefs.GetFloat("MasterVolume");
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            soundVolume = PlayerPrefs.GetFloat("SoundVolume");
            isPro = PlayerPrefs.GetInt("IsPro", 0);
            highestReach = PlayerPrefs.GetInt("HighestReach", 0);

        }

        public void Start()
        {
            Scene scene = SceneManager.GetActiveScene();
            CoinUpdater();
            ClimbedDistanceUpdater();
            HighestReachUpdater();
            BonusCoinUpdater();

            if (scene.name == "MainMenuScene")
            {
                MenuPicker();
            }
        }

        public void Update()
        {
            CoinUpdater();
        }

        public void LateUpdate()
        {
            VirtualControlToggle();
        }

        #endregion

        #region Navigation

        public void LoadShopScene() // Method to load the Shop scene
        {
            if (SceneManager.GetSceneByName(shopScene) != null)
            {
                UIClickSound();
                SceneManager.LoadScene(shopScene);
            }
            else
            {
                Debug.Log(shopScene + " does not exist.");
            }
        }

        public void LoadDailyChallengeScene() // Method to load the Daily Challenge scene
        {
            if (SceneManager.GetSceneByName(dailyChallenge) != null)
            {
                Drill.UI.Drill_UI_Manager.UIClickSound();
                SceneManager.LoadScene(dailyChallenge);
            }
            else
            {
                Debug.Log(dailyChallenge + " does not exist!");
            }
        }

        public void LoadSettingsScene() // Method to load the Settings scene
        {
            if (SceneManager.GetSceneByName(settingsScene) != null)
            {
                Drill.UI.Drill_UI_Manager.UIClickSound();
                SceneManager.LoadScene(settingsScene);
            }
            else
            {
                Debug.Log(settingsScene + " does not exist!");
            }
        }

        public void LoadPlayGameScene() // Method to load the Main level scene
        {
            if (SceneManager.GetSceneByName(playGame) != null)
            {
                Drill.UI.Drill_UI_Manager.UIClickSound();
                SceneManager.LoadScene(playGame);
            }
            else
            {
                Debug.Log(playGame + " does not exist!");
            }
        }

        public void BackButton() // Navigtates back to the Main Menu when the back button is pressed
        {
            if (SceneManager.GetSceneByName("MainMenu") != null)
            {
                FindObjectOfType<Drill.Audio.AudioManager>().Play("UI_Back");
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                FindObjectOfType<Drill.Audio.AudioManager>().Play("UI_Back");
                Debug.Log("MainMenu does not exist!");
            }

        }

        #endregion

        #region Helper Methods

        void MenuPicker() // Checks if the player has paid for Pro and turns off Main menu adds if true
        {
            if (isPro == 1)
            {
                mainMenuWithAds.SetActive(false);
                mainMenuPro.SetActive(true);
            }
            else
            {
                mainMenuWithAds.SetActive(true);
                mainMenuPro.SetActive(false);
            }
        }

        void CoinUpdater() // Updates coin counters from PlayerPrefs
        {
            totalCoinInt = PlayerPrefs.GetInt("Coins", 0);

            if (coinCount != null)
            {
                coinCount.text = "$ " + PlayerPrefs.GetInt("Coins", 0).ToString();
            }
        }

        public static void UIClickSound() // Method to play UI sound when button is clicked
        {
            FindObjectOfType<Drill.Audio.AudioManager>().Play("UI_Click");
        }

        public void TiltControls() // Toggles Tilt Controls on and off.
        {
            tiltControls = !tiltControls;

        }

        public void ShopClickSound() // Non static method for Button OnClick() to produce UI click sound
        {
            UIClickSound();
        }

        public void VirtualControlToggle() // Toggles Virtual Controls depending on Tilt Setting
        {
            if (virtualControls != null)
            {
                if (tiltControls == true)
                {
                    virtualControls.SetActive(false);
                }
                else
                {
                    virtualControls.SetActive(true);
                }
            }

        }

        public void ReviewForm() // Button that opens browser with Playtesting Review Form
        {
            Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSdAoAu07TSllCWLD4v84LdGQHzfDeLH71lOhuwVQkxrXBLu0A/viewform?usp=sf_link");
        } 

        public void ClimbedDistanceUpdater() // Updates climbed distance counter from last play
        {
            if(climbedCount != null)
            {
                climbedCount.text = climbedDistance.ToString() + " M";
            }
        }

        public void HighestReachUpdater() // Updates best height counter from PlayerPrefs
        {
            if(highestReachCount != null)
            {
                highestReachCount.text = "Best: " + highestReach.ToString() + " M";
            }
        }

        public void BonusCoinUpdater() // Updates bonus coin counter from last play
        {
            if(bonusCoinCount != null)
            {
                bonusCoins = climbedDistance / 3;
                bonusCoinCount.text = "+ " + bonusCoins.ToString() + " $";
            }
        }

        #endregion
    }
}

