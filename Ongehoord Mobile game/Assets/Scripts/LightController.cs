using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    public GameObject[] lights;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(switchThroughLights());
    }

    // Update is called once per frame
    void Update () {
		
	}

    IEnumerator switchThroughLights()
    {
        

        yield return new WaitForSeconds(1);
        lights[0].SetActive(false);
        lights[1].SetActive(true);
        yield return new WaitForSeconds(1);
        lights[1].SetActive(false);
        lights[2].SetActive(true);
        yield return new WaitForSeconds(1);
        lights[2].SetActive(false);
        lights[3].SetActive(true);
        yield return new WaitForSeconds(1);
        lights[3].SetActive(false);
        lights[4].SetActive(true);
        yield return new WaitForSeconds(1);
        lights[4].SetActive(false);
        lights[0].SetActive(true);
       
        StartCoroutine(switchThroughLights());



    }
}
