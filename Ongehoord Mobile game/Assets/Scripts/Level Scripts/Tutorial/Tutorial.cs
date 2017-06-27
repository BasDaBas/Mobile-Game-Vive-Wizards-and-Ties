using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    int i = 0;
    public GameObject[] tutorialText;
    

    public void NextTutorialText(GameObject go)
    {

        if (i == tutorialText.Length - 1)
        {
            go.SetActive(false);
        }
        else
        {
            tutorialText[i].SetActive(false);
            tutorialText[i + 1].SetActive(true);
        }      
       
        i++;
    }
}
