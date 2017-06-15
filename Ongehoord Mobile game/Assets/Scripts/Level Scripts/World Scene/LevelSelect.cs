using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class LevelSelect : MonoBehaviour {

    [System.Serializable]
    public class level
    {
        public string LevelText;
        public int Unlocked; //0 = not unlocked , 1 = unlocked
        public bool IsInteractable;

    }

    public GameObject levelButton;
    public GameObject levelButtonText;
    public Transform Spacer;

    public GameObject StartLevelPanel;
    public GameObject StartLevelPanelButton;
    private bool panelActive;

    public List<level> LevelList;
    

    void Start ()
    {
        FillList();
	}

    void FillList()
    {
        foreach (var level in LevelList)
        {
            GameObject newbutton = Instantiate(levelButton) as GameObject;
            LevelButton button = newbutton.GetComponent<LevelButton>();
            button.levelText.text = level.LevelText;
            

            if (PlayerPrefs.GetInt("03 Level_" + button.levelText.text) == 1 )//check if the previous level is unlocked.
            {
                level.Unlocked = 1;
                level.IsInteractable = true;
            }
           

            button.unlocked = level.Unlocked;
            button.GetComponent<Button>().interactable = level.IsInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => LoadLevel(button));
            newbutton.transform.SetParent(Spacer, false);
            //based on the points it will unlock stars
            string stars = "03 Level_" + button.levelText.text + "_stars";

            if (PlayerPrefs.GetInt(stars) >= 1)
            {
                button.Star1.SetActive(true);                
            }
            if (PlayerPrefs.GetInt(stars) >= 2)
            {
                button.Star2.SetActive(true);
            }
            if (PlayerPrefs.GetInt(stars) == 3)
            {
                button.Star3.SetActive(true);
            }

            SaveAll();
        }
    }

    void SaveAll()
    {
        /*if (PlayerPrefs.HasKey("03 Level_1"))
        {
            Debug.Log("PlayerPrefs Has Key: 03 Level_1");
            return;
        else*/
        {
            GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
            foreach (GameObject buttons in allButtons)
            {
                LevelButton button = buttons.GetComponent<LevelButton>();

                PlayerPrefs.SetInt("03 Level_" + button.levelText.text, button.unlocked);
            }
        }        
    }
        

    void LoadLevel(LevelButton button)
    {
        ToggleStartLevel();
        levelButtonText.GetComponent<Text>().text = "Level " + button.levelText.text;
        StartLevelPanelButton.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("03 Level_" + button.levelText.text));        
    }

    public void ToggleStartLevel()
    {

        if (panelActive == true)
        {
            StartLevelPanel.SetActive(false);
            panelActive = false;
        }
        else if (panelActive == false)
        {
            StartLevelPanel.SetActive(true);
            panelActive = true;
        }
       
        
    }
   
        
}
