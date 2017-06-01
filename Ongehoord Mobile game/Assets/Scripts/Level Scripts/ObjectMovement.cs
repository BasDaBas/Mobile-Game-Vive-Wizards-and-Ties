using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

    public bool Touchable;
    public Transform PlayerPos;
    public Transform SpawnPos;
    public float TransSpeed;
    RaycastHit hit;
    float point = 100;
    Ray ray;
    bool gekke = true;


    // Update is called once per frame
    void Update() {
        if(Input.touchCount> 0 && Input.GetTouch(0).phase == TouchPhase.Began && Touchable == true)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit, point))
            {
                Debug.Log(gameObject.name);
                
                
                
            }
        }               
         
        float step = TransSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, PlayerPos.position, step);	

        if(transform.position == PlayerPos.position)
        {
            transform.position = SpawnPos.position;
            gameObject.SetActive(false);
            
            
        }
	}

    
}
