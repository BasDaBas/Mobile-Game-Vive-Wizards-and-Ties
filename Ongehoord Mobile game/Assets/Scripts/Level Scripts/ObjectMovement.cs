using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class ObjectMovement : MonoBehaviour
    {

        public bool touchable;
        public Transform playerPos;
        private Transform storage;
        // public Transform SpawnPos;
        public float transSpeed;
        RaycastHit hit;
        float point = 100;
        Ray ray;
        private GameManager gameManager;

        public bool touched = false;

        public Shader hightlightShader;

        void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            storage = GameObject.Find("Storage").GetComponent<Transform>();

            var lookDir = playerPos.position - transform.position;
            lookDir.y = 90; // keep only the horizontal direction
            transform.rotation = Quaternion.LookRotation(lookDir);

            gameObject.GetComponentInParent<alive>().noteIsAlive = true;

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && touchable == true)
            {
                
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out hit, point) && touched == false)
                {
                    
                    gameObject.GetComponentInParent<alive>().noteIsAlive = false;
                    gameManager.AddScore(10);
                    gameManager.totalNotesHit++;
                    gameObject.transform.position = storage.position;
                    gameObject.SetActive(false);
                    touchable = false;
                    gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
                    

                }

                
            }

            float step = transSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,playerPos.position, step);

            //If the player didnt catch the notes
            if (transform.position == playerPos.position)
            {
                Debug.Log("Missed note");
                Handheld.Vibrate();
                gameManager.takeDamage();
                transform.position = storage.position;
                gameObject.GetComponentInParent<alive>().noteIsAlive = false;
                touchable = false;
                gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
                gameObject.SetActive(false);
                
            }            
        }

        public void SwapRenderer()
        {
            gameObject.GetComponent<Renderer>().material.shader = hightlightShader;  
        }
    }    
}

