using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelButton : MonoBehaviour {

    public Text levelText;  //used for the text of the button. number 1, 2 , 3 etc.
    public int unlocked;    //to check if the level is unlocked. 0 = locked, 1 = unlocked
    public GameObject Star1;    //reference to the stars under the button to activate them.
    public GameObject Star2;    //reference to the stars under the button to activate them.
    public GameObject Star3;    //reference to the stars under the button to activate them.
}
