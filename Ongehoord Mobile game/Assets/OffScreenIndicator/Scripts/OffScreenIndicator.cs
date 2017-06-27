using UnityEngine;
using System.Collections.Generic;
using UnityEngine.VR;
using System.Collections;

/// <summary>
/// Off screen indicator.
/// Classic wrapper, user doesn't need to worry about implementation
/// </summary>
namespace CompleteProject{
	public class OffScreenIndicator : MonoBehaviour {

		public bool	enableDebug = true;	
		public GameObject canvas;
		public int Canvas_circleRadius = 5; //size in pixels
		public int Canvas_border = 10; // when Canvas is Square pixels in border
		public int Canvas_indicatorSize = 100; //size in pixels
		public Indicator[] indicators;
		//public List<MusicNotes> targets = new List<MusicNotes>();
		//public 
		private OffScreenIndicatorManager manager;

        void Awake()
        {

            manager = gameObject.AddComponent<OffScreenIndicatorManagerCanvas>();
            (manager as OffScreenIndicatorManagerCanvas).indicatorsParentObj = canvas;
            (manager as OffScreenIndicatorManagerCanvas).circleRadius = Canvas_circleRadius;
            (manager as OffScreenIndicatorManagerCanvas).border = Canvas_border;
            (manager as OffScreenIndicatorManagerCanvas).indicatorSize = Canvas_indicatorSize;

            manager.indicators = indicators;
            manager.enableDebug = enableDebug;
            manager.CheckFields();
           
        }

        void LateUpdate()
        {
            paint();
        }

        void paint()
        {
            GameObject[] musicNotes = GameObject.FindGameObjectsWithTag("Notes");

            foreach (GameObject notes in musicNotes)
            {
                if (notes.GetComponent<alive>().noteIsAlive == true)
                {
                    AddIndicator(notes.GetComponent<Transform>().transform, 0);//0 because there is no ID?

                }
                else if (notes.GetComponent<alive>().noteIsAlive == false)
                {
                    Debug.Log("Remove Indicator");
                    RemoveIndicator(notes.GetComponent<Transform>().transform);
                }                             
            }           
        }

       

		public void AddIndicator(Transform target, int indicatorID){
			manager.AddIndicator(target, indicatorID);
		}

		public void RemoveIndicator(Transform target){
			manager.RemoveIndicator(target);
		}

	}

	/// <summary>
	/// Indicator.
	/// References and colors for indicator sprites
	/// </summary>
	[System.Serializable]
	public class Indicator{
		public Sprite onScreenSprite;
		public Color onScreenColor = Color.white;
		public bool onScreenRotates;
		public Sprite offScreenSprite;
		public Color offScreenColor = Color.white;
		public bool offScreenRotates;
		public Vector3 targetOffset;
		/// <summary>
		/// Both sprites need to have the same transition
		/// aswell both sprites need to have the same duration.
		/// </summary>
		public Transition transition;
		public float transitionDuration = 1;
		[System.NonSerialized]
		public bool showOnScreen;
		[System.NonSerialized]
		public bool showOffScreen;

		public enum Transition{
			None,
			Fading,
			Scaling
		}
	}

	/*[System.Serializable]
	public class MusicNotes{
        public Transform target;
		public int indicatorID;
	}*/
}