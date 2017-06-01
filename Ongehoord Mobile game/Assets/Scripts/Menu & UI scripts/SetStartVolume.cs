using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    private MusicManager musicManager;

	// Use this for initialization
	void Start ()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager)
        {
            float volume = PlayerPrefsManager.GetMasterVolume();
            musicManager.SetVolume(volume);
        }
        else
        {
            Debug.LogWarning("No Music Manager found in Start scene, Can't set volume");
        }
	}
	
	
}
