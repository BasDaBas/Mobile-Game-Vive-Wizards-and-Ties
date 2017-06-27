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

        public Text ItemName;
        public Text cost;
        public Text description;


        // Use this for initialization
        void Start()
        {
            SetButton();
            
        }

        void SetButton()
        {
            ItemName.text = player.shields[shieldNumber].itemName;
            cost.text = "$" + player.shields[shieldNumber].cost.ToString();
            description.text = player.shields[shieldNumber].description;

        }

        public void OnClick()
        {
            if (gameObject.tag == "Shield")
            {
                if (ShopManager.coins >= player.shields[shieldNumber].cost)//if we have enough coins to buy the item
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
            else
            {
                if (ShopManager.coins >= player.shields[shieldNumber].cost)//if we have enough coins to buy the item
                {
                    PlayerPrefsManager.AddEarplugs(); //Adds an earplug 
                    ShopManager.coins -= player.shields[shieldNumber].cost;//take the money
                    ShopManager.earplugs++;
                    Debug.Log("Bought Earplug");
                }
                else
                {
                    Debug.Log("Not enough Money");
                }
            }
            
        }        

            // Update is called once per frame
            void Update()
        {

        }
    }
}



