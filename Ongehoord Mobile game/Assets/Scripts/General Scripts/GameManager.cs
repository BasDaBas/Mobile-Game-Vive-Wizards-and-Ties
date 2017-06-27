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
        public bool gameIsPlaying;
        private float initialFixedDelta;
        private GameObject buttons;

        [Header("PopUp Menu Visuals")]
        public GameObject PopUpMenuPanel;
        public GameObject EndGamePanel;        
        public Text scoreText;
        public Text inGameScoreText;
        public Text inGameTimeText;
        public Text statusText;
        public Text cochleaDamage;
        public GameObject[] starsUnlocked;
        public Image cochlea;

        [HideInInspector]
        public static int score;

        private int coinsEarned;
        private int starsEarned;

        [Header("Start Game visuals")]
        public SpawningObjects spawningObjects;
        public float playTime;
        public GameObject countdownPanel;

        public int totalNotesHit;
        public int totalNotes;
        public float cochleaHealth;
        private float cochleaSpeed = 1;

        private GameObject musicManager;

        // Use this for initialization
        void Start()
        {
            spawningObjects = spawningObjects.GetComponent<SpawningObjects>();
            musicManager = GameObject.Find("MusicManager");
            musicManager.SetActive(false);
            initialFixedDelta = Time.fixedDeltaTime;

            cochleaHealth = 100;
            cochleaDamage.text = cochleaHealth + "%";

                       
        }

        // Update is called once per frame
        void Update()
        {
            if (gameIsPlaying == true)
            {
                playTime -= Time.deltaTime;
                if (playTime < 4)// stop spawning notes in the last 4 sec to make sure there is no note when the game is already ended.
                {                    
                    spawningObjects.gameRunning = false;//Game Ended                   
                }
                if (playTime < 0)
                {
                    gameIsPlaying = false;
                    SetEndGamePanel(false);                    
                }
                if (cochleaHealth == 0)
                {
                    gameIsPlaying = false;
                    SetEndGamePanel(true);

                    Time.timeScale = 0;
                    Time.fixedDeltaTime = 0;
                }
            }

            inGameTimeText.text = "Time: " + Mathf.Round(playTime);
        }

        public void StartGame(GameObject startGameButton)
        {
            countdownPanel.SetActive(true);
            startGameButton.SetActive(false);
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

            if (Time.timeScale == 0 || Time.fixedDeltaTime == 0) 
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = 1;
            }
            

            SceneManager.LoadScene(3); //load WorldScene
        }


        public void EndGameCondition(int coins, int stars)
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex - 4; // -4 because there are 4 scenes before this
            string _worldScore = "03 Level_" + currentLevel + "_score";
            string _stars = "03 Level_" + currentLevel + "_stars";

            //it will check the score (if there is one that has more points) so it wont give less points then you already had on this level.
            if (PlayerPrefs.GetInt(_worldScore) <= score)//means you have more points now than previous play
            {
                coinsEarned = coins;
                starsEarned = stars;
                ShopManager.coins += coinsEarned;
                PlayerPrefs.SetInt(_worldScore, score);
                PlayerPrefs.SetInt(_stars, stars);

            }
            else//if the player had less points than previous score
            {
                coinsEarned = coins;
            }
            //changes the opacity of the stars based on how many stars are unlocked
            for (int i = 0; i < stars; i++) {
                starsUnlocked[i].SetActive(true);

            }


            //storing the score, coinsEarned and starEarned into the Unity Analatyics
            Analytics.CustomEvent("Game Completed", new Dictionary<string, object>
            {
                { "Level", currentLevel},
                { "Points", score},
                { "Coins", coinsEarned},
                { "Stars", starsEarned}
            });

            EndGamePanel.SetActive(true);
        }

        public void SetEndGamePanel(bool gameover)
        {

            if (gameover)
            {
                EndGameCondition(Mathf.RoundToInt(totalNotesHit / 4), 0);
                statusText.text = "Try Again!";
            }
            else
            {
                //Condition 1 (3 stars)
                if (totalNotesHit >= (totalNotes / 5) * 4)
                {
                    EndGameCondition(Mathf.RoundToInt(totalNotesHit / 4), 3);
                    statusText.text = "Amazing!";

                }
                //Condition 2 (2 stars)
                else if (totalNotesHit < (totalNotes / 5) * 4 && totalNotesHit > (totalNotes / 5) * 3)
                {
                    EndGameCondition(Mathf.RoundToInt(totalNotesHit / 4), 2);
                    statusText.text = "Good Job!";
                }
                // Condition 3 (1 star)
                else if (totalNotesHit < totalNotes / 5 * 3 && totalNotesHit > (totalNotes / 5) * 2)
                {
                    EndGameCondition(Mathf.RoundToInt(totalNotesHit / 4), 1);
                    statusText.text = "Well done!";
                }
                else
                {
                    EndGameCondition(Mathf.RoundToInt(totalNotesHit / 4), 0);
                    statusText.text = "Try Again!";
                }
            }          

            scoreText.text = "Score: " + score.ToString();
            

            //reset
            totalNotes = 0;
            totalNotesHit = 0;
            score = 0;
        }             


        public void PopOpMenu()
        {
            if (isPaused)
            {
                isPaused = false;
                musicManager.GetComponent<AudioSource>().Play();
                ResumeGame();
            }
            else if (!isPaused)
            {
                isPaused = true;
                musicManager.GetComponent<AudioSource>().Pause();
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

        public void StartMusic()
        {
            musicManager.SetActive(true);
            playTime = musicManager.GetComponent<AudioSource>().clip.length;
            
            Debug.Log("Cochleahealth = " + cochleaHealth);
            Debug.Log("Song is playing");
        }

        public void takeDamage()
        {
            cochlea.fillAmount -= 0.04f;
            cochleaHealth -= 4f;
            cochleaDamage.text = cochleaHealth + "%";
        }

        public void LoadWorldScene()
        {
            
            Time.timeScale = 1f;
            Time.fixedDeltaTime = initialFixedDelta;       

            
            musicManager.SetActive(true);
           
            

            SceneManager.LoadScene("02a World Scene");

        }


    }
}

