using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class OptionManager : MonoBehaviour {


    public Sprite musicOnImage;
    public Sprite musicOffImage;
    public Button musicButton;

    private float volume;

    MusicManager musicManager;

	// Use this for initialization
	void Start ()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volume = PlayerPrefsManager.GetMasterVolume();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (volume <= 0)
        {
            musicButton.image.sprite = musicOffImage;

        }
        else if (volume >= 0)
        {
            musicButton.image.sprite = musicOnImage;

        }
    }

    //Function used for the back button in the options scene to make sure everything is saved.
    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volume);
        SceneManager.LoadScene("01a Start Menu");        
    }

    public void ToggleMusic()
    {

        if (musicManager == null)
        {
            musicManager = GameObject.FindObjectOfType<MusicManager>();
        }

        if (volume == 0)  {
            volume = 1;
            musicManager.SetVolume(volume);
            musicButton.image.sprite = musicOnImage;
            //not muted
            
        } else  {
            volume = 0;
            musicManager.SetVolume(volume);
            musicButton.image.sprite = musicOffImage;
            //muted
        }
        
    }

    public void profilePlayer()
    {
        Gender gender = Gender.Female;
        // Use this call to designate the user gender
        Analytics.SetUserGender(gender);
        int birthYear = 1994;
        Debug.Log(birthYear);
        // Use this call to designate the user birth year
        Analytics.SetUserBirthYear(birthYear);

    }

    public void ResetGame()
    {
        PlayerPrefsManager.DeleteAllPreferences();
    }
}
