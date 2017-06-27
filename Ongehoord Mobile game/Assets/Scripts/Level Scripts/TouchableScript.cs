using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CompleteProject
{

    public class TouchableScript : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Note")
            {
                Debug.Log("Note is in range");

                other.GetComponent<ObjectMovement>().touchable = true;
                other.GetComponent<ObjectMovement>().SwapRenderer();
            }
        }

    }
}