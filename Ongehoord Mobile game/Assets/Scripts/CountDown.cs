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

        void Awake()
        {
            spawningObjects = spawningObjects.GetComponent<SpawningObjects>();
            gameManager = gameManager.GetComponent<GameManager>();
            StartCoroutine(CountdownTimer());
        }


        IEnumerator CountdownTimer()
        {
            if (i >= 1)
            {
                countdownObjects[i - 1].SetActive(false);
                countdownObjects[i].SetActive(true);
            }
            i++;

            yield return new WaitForSeconds(1.0f);

            if (countdownObjects.Length != i)
            {
                StartCoroutine(CountdownTimer());
            }
            else
            {
                //Call function that starts the game.
                spawningObjects.gameRunning = true;
                gameManager.gameIsPlaying = true;


                gameObject.SetActive(false);
                //this is so the countdowntimer can be re used if you want to play the level again.
                countdownObjects[i - 1].SetActive(false);
                i = 0;
                countdownObjects[i].SetActive(true);
            }
        }

    }
}
