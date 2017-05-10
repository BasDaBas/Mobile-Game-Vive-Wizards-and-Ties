using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Dont destroy on load: " + name);

        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Level auto next disabled, Use a positive number in seconds");
        }
        else {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
        
	}	

	public void LoadNextLevel(){
        Debug.Log("LoadNextLevel Requested");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
	}
    	
    public void Quit()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Debug.Log("Quit requested");
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }    

}
