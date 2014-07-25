using UnityEngine;
using System.Collections;

public class touchControls : MonoBehaviour {

	public GUITexture leftBtn;
	public GUITexture rightBtn;

	public GameObject yetti;

	bool left;
	bool right;

	float h;
	float v;
	float speed = 0.2f;

	int ro = 0;


	// Use this for initialization
	void Start () {

		left = true;
		right = false;


	
	}
	
	// Update is called once per frame
	void Update () {
	
		foreach (Touch touch in Input.touches){
			
			if(touch.phase == TouchPhase.Stationary && leftBtn.HitTest(touch.position)){

				h = -speed;

				if(ro == 180){
					left = true;
				}

				if (left){
					yetti.transform.Rotate(0,180,0);
					left = false;
				}
				
			}

			else if(touch.phase == TouchPhase.Ended){

				h = 0.0f;
			}

			if(touch.phase == TouchPhase.Stationary && rightBtn.HitTest(touch.position)){
				
				h = speed;
				right = true;

				if(right){
					yetti.transform.Rotate(0,270,0);
					right = false;
				}
				
			}

			else if(touch.phase == TouchPhase.Ended){

				h = 0.0f;
			}

		}

		yetti.transform.Translate(h,0,0 * speed* Time.deltaTime);

	}
}
