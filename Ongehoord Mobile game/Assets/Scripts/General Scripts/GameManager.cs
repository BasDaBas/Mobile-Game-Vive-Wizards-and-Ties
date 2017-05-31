using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private bool isPaused;
    private float initialFixedDelta;
    private GameObject buttons;

    public GameObject PopUpMenuPanel;
    public GameObject EndGamePanel;

    public Text scoreText;
    public Text statusText;
    public int score;


    // Use this for initialization
    void Start () {              

        initialFixedDelta = Time.fixedDeltaTime;

        LevelButton button = buttons.GetComponent<LevelButton>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Go To world Scene and unlocks the next level.
    //TODO: Setup Score
    public void GoToWorldScene()
    {
        PlayerPrefs.SetInt("03 Level_" + (SceneManager.GetActiveScene().buildIndex - 3) + "_score", score); //Used to give a score so we can test if the stars work.

        //Check if the score of the previous game is above 25(1 star) to unlock the next level
        if (PlayerPrefs.GetInt("03 Level_" +    (SceneManager.GetActiveScene().buildIndex - 3) + "_score") >= 25)// -3 to get the current buildindex
        {
            PlayerPrefs.SetInt("03 Level_" + (SceneManager.GetActiveScene().buildIndex - 2), 1);//Sets Next Scene active.  taking -2 of the index to get the buildindex of the next level
            Debug.Log("enough points scored to unlock the next level,Good Job!");
        }
        else
        {
            Debug.Log("Not enough points scored to unlock the next level, Try again!");
        }

        
        
        SceneManager.LoadScene(3); //load WorldScene
    }


    public void WinCondtion()
    {
        score = 75; 
        SetScoreText();
        EndGamePanel.SetActive(true);
    }

    public void LoseCondition()
    {
        score = 15;
        SetScoreText();
        EndGamePanel.SetActive(true);
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 25)
        {
            statusText.text = "Good Job!";
        }
        else if(score <= 24)
        {
            statusText.text = "Try Again!";
        }
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
