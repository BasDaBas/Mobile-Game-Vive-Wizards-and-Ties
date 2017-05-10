using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

    public LevelManager levelManager;

    private float volume;

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();        
        volume = PlayerPrefsManager.GetMasterVolume();
        Debug.Log("Start function checking volume; " + volume);
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.SetVolume(volume);
	}

    //Function used for the back button in the options scene to make sure everything is saved.
    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volume);
        Debug.Log("Save and Exit Called. Volume = " + volume);

        levelManager.LoadLevel("01a Start Menu");        
    }

    public void ToggleMusic()
    {
        if (volume == 0)  {
            volume = 1;
            musicManager.SetVolume(volume);
            Debug.Log("Volume Not Muted");
        } else  {
            volume = 0;
            musicManager.SetVolume(volume);
            Debug.Log("Volume Muted");
        }
        
    }

    public void ResetGame()
    {
        PlayerPrefsManager.DeleteAllPreferences();
    }
}
