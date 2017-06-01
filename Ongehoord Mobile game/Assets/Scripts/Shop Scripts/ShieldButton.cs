using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{
    public class ShieldButton : MonoBehaviour
    {
        public Player player;
        public int shieldNumber;

        public Text name;
        public Text cost;
        public Text description;

        private AudioSource source;


        // Use this for initialization
        void Start()
        {
            source = GetComponent<AudioSource>();
            SetButton();
            
        }

        void SetButton()
        {
            string costString = player.shields[shieldNumber].cost.ToString();
            name.text = player.shields[shieldNumber].itemName;
            cost.text = "$" + player.shields[shieldNumber].cost.ToString();
            description.text = player.shields[shieldNumber].description;

        }

        public void OnClick()
        {
            if (ShopManager.coins >= player.shields[shieldNumber].cost )//if we have enough coins to buy the item
            {
                Debug.Log("Enough Money to buy item");
                ShopManager.coins -= player.shields[shieldNumber].cost;//take the money
                PlayerPrefsManager.Unlockables(shieldNumber);//set the unlocked item in the prefs manager
                player.currentShield = shieldNumber;//equip the item
            }
            else
            {
                Debug.Log("Not enough Money");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}



