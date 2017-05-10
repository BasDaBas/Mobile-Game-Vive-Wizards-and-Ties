using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //A way to Unlock Levels
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsLevelUnlocked(1));
        print(PlayerPrefsManager.IsLevelUnlocked(2));
        print(PlayerPrefsManager.IsLevelUnlocked(3));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
