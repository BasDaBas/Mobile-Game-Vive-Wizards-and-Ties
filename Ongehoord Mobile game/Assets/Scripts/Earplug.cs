using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earplug : MonoBehaviour {

    public GameObject waveSpawner;
    public Button earplugButton;
    public Text earplugButtonText;
    private bool turnedOn = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerPrefsManager.GetEarplug() <= 0)
        {
            earplugButton.interactable = false;
        }
        else if (PlayerPrefsManager.GetEarplug() >= 1)
        {
            earplugButton.interactable = true;
        }

        earplugButtonText.text = PlayerPrefsManager.GetEarplug().ToString();


    }

    public void OnClickEarplug()
    {
        if (PlayerPrefsManager.GetEarplug() >= 1)
        {
            PlayerPrefsManager.RemoveEarplugs();
            TurnOffMusicSpawner();
            Invoke("TurnOffMusicSpawner", 4);                                 
        }
    }

    void TurnOffMusicSpawner()
    {
        if (turnedOn)
        {
            Debug.Log("Turn off notes spawner");
            turnedOn = false;
            waveSpawner.SetActive(false);
        }
        else
        {
            Debug.Log("Turn on notes spawner");
            turnedOn = true;
            waveSpawner.SetActive(true);
        }
    }
}
