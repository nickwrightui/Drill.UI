using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Drill.UI
{
    public class Drill_UI_Settings : MonoBehaviour
    {

        #region Variables

        public Slider masterVolumeSlider;
        public float masterVolume;
        public Slider musicVolumeSlider;
        public float musicVolume;
        public Slider soundVolumeSlider;
        public float soundVolume;
        public Slider tiltControlsSlider;
        public float tiltControls;
        public Slider tiltSensitivitySlider;
        public float tiltSensitivity;



        #endregion

        #region Main Methods

        private void Awake()
        {

            masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
            musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            soundVolume = PlayerPrefs.GetFloat("SoundVolume", 1f);
            tiltControls = PlayerPrefs.GetFloat("TiltControls", 0f);
            tiltSensitivity = PlayerPrefs.GetFloat("TiltSensetivity", 2f);

        }

        private void Start()
        {
            masterVolumeSlider.value = masterVolume;
            musicVolumeSlider.value = musicVolume;
            soundVolumeSlider.value = soundVolume;
            tiltControlsSlider.value = tiltControls;
            tiltSensitivitySlider.value = tiltSensitivity;
  
        }

        private void Update()
        {
            MasterVolumeSlider();
            MusicVolumeSlider();
            SoundVolumeSlider();
            TiltContolsSlider();
        }

        #endregion

        #region Helper Methods

        public void MasterVolumeSlider() // Sets the Master Volume Slider from PlayerPrefs
        {
            masterVolume = masterVolumeSlider.value;
            PlayerPrefs.SetFloat("MasterVolume", masterVolume);
            Drill.UI.Drill_UI_Manager.masterVolume = masterVolume;
        }

        public void MusicVolumeSlider() // Sets the Music Volume Slider from PlayerPrefs
        {
            musicVolume = musicVolumeSlider.value;
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
            Drill.UI.Drill_UI_Manager.musicVolume = musicVolume;
        }

        public void SoundVolumeSlider() // Sets the Sounds Volume Slider from PlayerPrefs
        {
            soundVolume = soundVolumeSlider.value;
            PlayerPrefs.SetFloat("SoundVolume", soundVolume);
            Drill.UI.Drill_UI_Manager.soundVolume = soundVolume;
        }

        public void TiltContolsSlider() // Sets the Tilt Controls Slider from PlayerPrefs
        {
            tiltControls = tiltControlsSlider.value;
            PlayerPrefs.SetFloat("TiltControls", tiltControls);
            if (tiltControls == 1)
            {
                Drill.UI.Drill_UI_Manager.tiltControls = true;
            }
            else
            {
                Drill.UI.Drill_UI_Manager.tiltControls = false;
            }
        }

        #endregion
    }
}

