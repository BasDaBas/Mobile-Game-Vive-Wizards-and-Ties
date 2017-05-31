using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that has to be attached to the Music Notes.

public class DestroyByContact : MonoBehaviour {

    public int scoreValue;
    private GameManager gameManager;

    void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        if (gameManager == null)
        {
            Debug.Log("Cannot find 'GameManager' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            //Destroy Music Note, no score added
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            //Destroy Music Note, Add Score 
            gameManager.AddScore(scoreValue);
            Destroy(gameObject);
        }
        
    }
}
