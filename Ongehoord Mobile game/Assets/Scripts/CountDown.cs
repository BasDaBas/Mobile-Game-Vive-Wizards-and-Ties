using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class CountDown : MonoBehaviour
    {

        int i = 0;
        public GameObject[] countdownObjects;

        public SpawningObjects spawningObjects;
        public GameManager gameManager;

        void Start()
        {
            spawningObjects = spawningObjects.GetComponent<SpawningObjects>();
            gameManager = gameManager.GetComponent<GameManager>();
            /*i = 0;
            StartCoroutine(CountdownTimer());  */      
            
        }

        public void StartCountdownTimer()
        {
            i = 0;
            StartCoroutine(CountdownTimer());
        }


        IEnumerator CountdownTimer()
        {
            Debug.Log("Start Timer");
            Debug.Log("i = " + i);
            if (i >= 1)
            {
                Debug.Log("Test");
                countdownObjects[i - 1].SetActive(false);
                countdownObjects[i].SetActive(true);
            }
            i++;
            Debug.Log("i = " + i);
            yield return new WaitForSeconds(1.0f);
            Debug.Log("countdown objects lenght = " + countdownObjects.Length);
            if (countdownObjects.Length != i)
            {
                Debug.Log("start coroutine");
                StartCoroutine(CountdownTimer());
            }
            else
            {
                //Call function that starts the game.
                spawningObjects.gameRunning = true;
                gameManager.gameIsPlaying = true;
                gameManager.StartMusic();
                //this is so the countdowntimer can be re used if you want to play the level again.
                countdownObjects[i - 1].SetActive(false);
                i = 0;
                countdownObjects[i].SetActive(true);

                gameObject.SetActive(false);
               
            }
        }

    }
}