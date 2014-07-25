using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class menuScr : MonoBehaviour {

	//varibles
	public GameObject menuBg;
	public GameObject quitBG;

	public GUIText noteText;

	public bool autoSignin = false;
	bool quitMenu = false;
	bool pauseMenu = false;
	public bool cutScene = false;

	public GUITexture resume;
	public GUITexture googlePlus;
	public GUITexture settings;
	public GUITexture quit;
	public GUITexture yes;
	public GUITexture no;
	public GUITexture play;


	// Use this for initialization
	void Start () {

		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape) && Application.loadedLevel != 0 && cutScene == false) {

			if(pauseMenu){
				pauseMenu = false;
			} else {
				pauseMenu = true;
			}

		}

		if (pauseMenu && Application.loadedLevel != 0 && cutScene == false) {

			menuBg.SetActiveRecursively(true);

			foreach (Touch touch in Input.touches){

				if(touch.phase == TouchPhase.Stationary && resume.HitTest(touch.position)){

					pauseMenu = false;

				}

				if(touch.phase == TouchPhase.Stationary && googlePlus.HitTest(touch.position)){
					
					Social.localUser.Authenticate((bool success) => {
						// handle success or failure

						if(success){

							autoSignin = true;

						}

					});
					
				}

				if(touch.phase == TouchPhase.Stationary && settings.HitTest(touch.position)){
					

					
				}

				if(touch.phase == TouchPhase.Stationary && quit.HitTest(touch.position)){
					
					quitMenu = true;
					quitBG.SetActiveRecursively(true);
					menuBg.SetActiveRecursively(false);
					
				}
				

			}

		} else {

			menuBg.SetActiveRecursively(false);
		}

		if(cutScene == false){
			foreach (Touch touch in Input.touches) {

				if(touch.phase == TouchPhase.Stationary && play.HitTest(touch.position) && Application.loadedLevel != 1){
				
					Application.LoadLevel(1);
				
				}
			}

		if (Application.loadedLevel != 0) {

				play.enabled = false;

		}
	
	}

		if (quitMenu && Application.loadedLevel != 0 && cutScene == false) {
			foreach (Touch touch in Input.touches) {
			
				if (touch.phase == TouchPhase.Stationary && yes.HitTest (touch.position) && Application.loadedLevel != 0) {
				
					Application.Quit ();
				
				}
			
				if (touch.phase == TouchPhase.Stationary && no.HitTest (touch.position) && Application.loadedLevel != 0) {
				
					quitMenu = false;
					quitBG.SetActiveRecursively (false);
					menuBg.SetActiveRecursively (true);
				
				}
			
			} 
		}else{

			quitBG.SetActiveRecursively (false);

		}

		if (cutScene == true) {

			noteText.enabled = true;

		}else{

			noteText.enabled = false;
		}
	}
	
}