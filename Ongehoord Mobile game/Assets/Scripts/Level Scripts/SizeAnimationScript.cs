using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeAnimationScript : MonoBehaviour {

    public float speed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * speed;
    }
}
