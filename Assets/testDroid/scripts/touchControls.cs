using UnityEngine;
using System.Collections;

public class touchControls : MonoBehaviour {

	public GUITexture leftBtn;
	public GUITexture rightBtn;

	public GameObject yetti;

	float h;
	float v;

	float speed = 0.2f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		foreach (Touch touch in Input.touches){
			
			if(touch.phase == TouchPhase.Stationary && leftBtn.HitTest(touch.position)){

				h = speed;
				
			}

			if(touch.phase == TouchPhase.Stationary && rightBtn.HitTest(touch.position)){
				
				h = -speed;
				
			}

		}

		yetti.transform.Translate(h,0,0 * speed* Time.deltaTime);

	}
}
