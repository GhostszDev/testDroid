using UnityEngine;
using System.Collections;

public class testScr : MonoBehaviour {

	public int note = 1;

	public GUIText nT;

	// Update is called once per frame
	void Update () {

		if (GameObject.Find ("MainCamera").GetComponent<menuScr> ().cutScene) {

			switch(note){
				case 1:
					nT.text = "Great Voice: Hey kid! You see that\n switch over there?";
				break;

				case 2:
					nT.text = "Great Voice: You know if you Press the\n Action Button you can activate it.";
				break;

				default:
					nT.text = "default";

				break;
			}
		}
	
	}
}
