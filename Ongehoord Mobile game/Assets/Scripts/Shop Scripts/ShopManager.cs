﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{
    public class ShopManager : MonoBehaviour
    {
        public static int coins;
        public Text textCoins;

        private bool panelOpen;

        public GameObject mainPanel;
        public GameObject IAPPanel;

        // Use this for initialization
        void Start()
        {
            panelOpen = false;
        }

        // Update is called once per frame
        void Update()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
            textCoins.text = coins.ToString();
        }

        public void OpenShopPanel()
        {
            if (panelOpen == false)
            {
                mainPanel.SetActive(false);
                IAPPanel.SetActive(true);
                panelOpen = true;
            }
            else
            {
                mainPanel.SetActive(true);
                IAPPanel.SetActive(false);
                panelOpen = false;
            }
        }
        
    }
}
