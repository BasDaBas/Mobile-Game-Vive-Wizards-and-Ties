using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

namespace CompleteProject
{
    public class GameManager : MonoBehaviour
    {

        
        private bool isPaused;
        private float initialFixedDelta;
        private GameObject buttons;

        public GameObject PopUpMenuPanel;
        public GameObject EndGamePanel;


        public Text scoreText;
        public Text inGameScoreText;
        public Text statusText;

        public static int score;
        private int coinsEarned;
        private int starsEarned;


        // Use this for initialization
        void Start()
        {

            initialFixedDelta = Time.fixedDeltaTime;
        }

        // Update is called once per frame
        void Update()
        {

        }

        //Go To world Scene and unlocks the next level.
        public void GoToWorldScene()
        {
            //Check if the score of the previous game is above 25(1 star) to unlock the next level
            if (PlayerPrefs.GetInt("03 Level_" + (SceneManager.GetActiveScene().buildIndex - 4) + "_score") >= 25)// -4 to get the current buildindex
            {
                PlayerPrefs.SetInt("03 Level_" + (SceneManager.GetActiveScene().buildIndex - 3), 1);//Sets Next Scene active.  taking -3 of the index to get the buildindex of the next level
                Debug.Log("enough points scored to unlock the next level,Good Job!");
            }
            else
            {
                Debug.Log("Not enough points scored to unlock the next level, Try again!");
            }

            SceneManager.LoadScene(3); //load WorldScene
        }


        public void WinLoseCondtion(bool won)
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex - 4; // -4 because there are 4 scenes before this
            string worldScore = "03 Level_" + currentLevel + "_score";

            if (won == true) {                
                //it will check the score (if there is one that has more points) so it wont give less points then you already had on this level.
                if (PlayerPrefs.GetInt(worldScore) <= score)
                {
                    score = 75;//TODO: For Testing now, needs to be changed
                    coinsEarned = 10;
                    starsEarned = 2;
                    ShopManager.coins += coinsEarned;
                    PlayerPrefs.SetInt(worldScore, score);
                }
                else {
                    score = PlayerPrefs.GetInt(worldScore);
                } 
            }
            else {
                //it will check the score (if there is one that has more points) so it wont give less points then you already had on this level.
                if (PlayerPrefs.GetInt(worldScore) <= score)
                {
                    score = 15;//TODO: For Testing now, needs to be changed
                    coinsEarned = 2;
                    starsEarned = 0;
                    PlayerPrefs.SetInt(worldScore, score);

                }
            }

            //storing the score, coinsEarned and starEarned into the Unity Analatyics
            Analytics.CustomEvent("Game Completed", new Dictionary<string, object>
            {
                { "Level", currentLevel},
                { "Points", score},
                { "Coins", coinsEarned},
                { "Stars", starsEarned}
            });

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
            else if (score <= 24)
            {
                statusText.text = "Try Again!";
            }
        }


        public void PopOpMenu()
        {
            if (isPaused)
            {
                isPaused = false;
                ResumeGame();
            }
            else if (!isPaused)
            {
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

        public void AddScore(int newScoreValue)
        {
            score += newScoreValue;
            UpdateScore();
        }

        void UpdateScore()
        {
            inGameScoreText.text = "Score: " + score;
        }


    }
}

