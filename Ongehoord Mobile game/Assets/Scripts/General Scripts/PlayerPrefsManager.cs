using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string LEVEL_KEY = "level_unlocked_";
    const string UNLOCKABLE_KEY = "item unlocked";
    const string EARPLUG_KEY = "earplug unlocked";

    public static int Earplug = 0;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }  else {
            Debug.LogError("Master volume out of range!");
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void Unlockables(int unlockable)
    {
        PlayerPrefs.SetFloat(UNLOCKABLE_KEY, unlockable);
    }

    public static float GetUnlockables()
    {
        return PlayerPrefs.GetFloat(UNLOCKABLE_KEY);
    }

    public static float GetEarplug()
    {
        return PlayerPrefs.GetFloat(EARPLUG_KEY);
    }

    public static void AddEarplugs()
    {
        Earplug++;
        PlayerPrefs.SetFloat(EARPLUG_KEY, Earplug);
    }

    public static void RemoveEarplugs()
    {
        Earplug--;
        PlayerPrefs.SetFloat(EARPLUG_KEY,Earplug);
    }

    /*public static void UnlockLevel(int level) {
        if (level <= SceneManager.sceneCountInBuildSettings - 1) { //checking of the level is actually in the build order.
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //use 1 for true since we can't use bools
        } else {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }
    

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()); //gets the Int from the given key
        bool IsLevelUnlocked = (levelValue == 1); //if the given level value is 1 , islevelunlocked is true

        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            return IsLevelUnlocked;
        } else {
            Debug.LogError("Trying to query level not in build order");
            return false;
        }
    }*/

    public static void DeleteAllPreferences()
    {
        PlayerPrefs.DeleteAll();
    }

}
