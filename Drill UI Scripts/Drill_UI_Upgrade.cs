using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace Drill.UI
{
    public class Drill_UI_Upgrade : MonoBehaviour
    {
        #region Variable

        private int totalCoinInt;

        [SerializeField]
        public int[] costLevel = new int[6];
        private int costIndex;

        private string upgradeNameString;
        private string upgradeDescriptionString;

        public Text upgradeName;
        public Text upgradeDescription;
        public Slider upgradeLevel;

        #endregion

        #region Main Methods

        private void Start()
        {
            upgradeNameString = this.gameObject.name;

            Debug.Log("TotalCoin " + totalCoinInt);
            Debug.Log(upgradeNameString + "Upgrade Level " + upgradeLevel.value);

        }

        private void Update()
        {
            if (costIndex != 4)
            {
                costIndex = Mathf.RoundToInt(upgradeLevel.value);
            }

        }

        #endregion

        #region Helper Methods

        public void OnValueChanged(float value) // No Idea only debugging
        {
            Debug.Log("New Value " + value);
        }

        public void OnClick() // Called when purchase button is pressed. Will purchase upgrade, check for max level, and coin
        {
            if(totalCoinInt >= costLevel[costIndex] && upgradeLevel.value != 5)
            {
                totalCoinInt -= costLevel[costIndex];
                upgradeLevel.value += 1;
                Debug.Log("New Total Coin " + totalCoinInt);
            }
            else if(upgradeLevel.value == 5)
            {
                Debug.Log("Upgrade " + upgradeName + " is at its Max Level!!");
            }
            else
            {
                Debug.Log("You do not have enough coins to purchase that upgrade.");
            }
        }

        #endregion
    }
}

