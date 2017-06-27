using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class SpawningObjects : MonoBehaviour {

        public bool gameRunning = false;
        public float spawnedNotes;

        public GameObject[] Notes;
        public GameObject[] SpawnPoints;

        [Header("Min and Max time before a note spawns")]
        public float maxTime = 2f;
        public float minTime = 1.0f;

        private float time;
        int location;
        private float spawnTime;
        public List<GameObject> notes = new List<GameObject>();

        public GameManager gameManager;

        void Start()
        {
            gameManager = gameManager.GetComponent<GameManager>();

            SetTimer();
            time = minTime;


        }
        void FixedUpdate()
        {
            if (gameRunning == true)
            {
                time += Time.deltaTime;
                if (time > spawnTime)
                {
                    SpawnNote();
                    gameManager.totalNotes++; //to track how many notes are spawned total in the game.
                    SetTimer();

                } 
            }
        }

        public GameObject GetNote()
        {
            int r = Random.Range(0, Notes.Length);

            for (int i = 0; i < notes.Count; i++)
            {
                if (!notes[i].gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
                {
                    Debug.Log("Note not active in scene");
                    notes[i].transform.position = SpawnPoints[location].transform.position;
                    notes[i].gameObject.transform.GetChild(0).transform.position = SpawnPoints[location].transform.position;
                    notes[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    notes[i].GetComponent<alive>().noteIsAlive = true;

                    return notes[i];
                }
            }
            GameObject go = Instantiate(Notes[r], SpawnPoints[location].transform.position, Quaternion.identity);
            notes.Add(go);
            return go;
        }

        public void SpawnNote()
        {
            location = Random.Range(0, SpawnPoints.Length);
            GameObject god = GetNote();
            time = 0;

        }
        void SetTimer()
        {
            spawnTime = Random.Range(minTime, maxTime);
        }
    }
}
