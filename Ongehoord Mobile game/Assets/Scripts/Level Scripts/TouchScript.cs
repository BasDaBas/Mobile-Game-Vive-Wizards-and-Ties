using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour {

    private Touch initTouch = new Touch();
    public Camera cam;

    private float rotX = 0f;
    private float rotY = 0f;

    public float rotSpeed = 5;
    public float dir = 1;
    private Vector3 origRot;

    void Start()
    {
        origRot = cam.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }

            if(touch.phase == TouchPhase.Moved)
            {
                float deltaX = initTouch.position.x - touch.position.x;
                float deltaY = initTouch.position.y - touch.position.y;
                rotX -= deltaX * Time.deltaTime *rotSpeed * dir;
                rotY += deltaY * Time.deltaTime * rotSpeed * dir;
                rotY = Mathf.Clamp(rotY, -20f, 20f);
                rotX = Mathf.Clamp(rotX, -10f, 10f);
              
                cam.transform.eulerAngles = new Vector3(rotY, rotX, 0f);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
	}

    public void OnGUI()
    {
        foreach (Touch touch in Input.touches)
        {
            string message = "";
            message += "ID: " + touch.fingerId + "\n";
            message += "Phase: " + touch.phase.ToString() + "\n";
            message += "TapCount: " + touch.tapCount + "\n";
            message += "PositionX: " + touch.position.x + "\n";
            message += "PositionY: " + touch.position.y + "\n";

            int num = touch.fingerId;
            GUI.Label(new Rect(0 + 130 * num, 0, 120, 100), message);
        }
    }


}
