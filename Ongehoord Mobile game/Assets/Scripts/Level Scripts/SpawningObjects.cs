using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningObjects : MonoBehaviour {

    public GameObject Note;
    private float maxTime = 6;
    private float minTime = 2;
    private float time;

    private float spawnTime;

    public List<GameObject> notes = new List<GameObject>();

    void Start()
    {
        SetTimer();
        time = minTime;
        
        
    }
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time > spawnTime)
        {
            SpawnNote();
           
            SetTimer();            
         
        }
    }

    public GameObject GetNote()
    {
   
        for (int i = 0; i < notes.Count; i++)
        {
            if (!notes[i].activeInHierarchy)
            {
                notes[i].SetActive(true);
                return notes[i];
            }
        }
        GameObject go = Instantiate(Note, transform.position, Quaternion.identity);
        notes.Add(go);
        return go;
    }

    void SpawnNote()
    {
        GameObject god = GetNote();
        Debug.Log(spawnTime);
        time = 0;
        
    }
    void SetTimer()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

  


}
