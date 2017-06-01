using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

    public bool Touchable;
    public Transform PlayerPos;
    public float TransSpeed;
    RaycastHit hit;
    float point = 100;
    Ray ray;


	// Use this for initialization
	void Start () {
  
	    	
	}

    // Update is called once per frame
    void Update() {
        if(Input.touchCount> 0 && Input.GetTouch(0).phase == TouchPhase.Began && Touchable == true)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit, point))
            {
                Debug.Log(gameObject.name);
                Destroy(hit.transform.gameObject);
                
                
            }
        }
      
               
           

        float step = TransSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, PlayerPos.position, step);
		
	}
    
}
