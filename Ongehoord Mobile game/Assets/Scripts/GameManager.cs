using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool isPaused;
    private float initialFixedDelta;

    public GameObject PopUpMenuPanel;


	// Use this for initialization
	void Start () {              

        initialFixedDelta = Time.fixedDeltaTime;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Go To world Scene and unlocks the next level.
    //TODO: Setup Score
    public void GoToWorldScene()
    {       
        PlayerPrefs.SetInt("03 Level_" + (SceneManager.GetActiveScene().buildIndex - 2), 1);//Sets Next Scene active.  taking -2 of the index to get the buildindex of the next level
        PlayerPrefs.SetInt("03 Level_" + (SceneManager.GetActiveScene().buildIndex - 3) + "_score", 50);
        SceneManager.LoadScene(3); //load WorldScene
    }


    public void PopOpMenu()
    {
        if (isPaused) {
            isPaused = false;
            ResumeGame();
        } else if(!isPaused) {
            isPaused = true;
            PauseGame();
        }
    }


    void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = initialFixedDelta;

        PopUpMenuPanel.SetActive(false);

    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;

        PopUpMenuPanel.SetActive(true);
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
}
