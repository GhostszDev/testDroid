using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class googlePlayService : MonoBehaviour {
	
	//varibles
	public Texture gPlusBtn;
	public int gPlusBtnWidth = Screen.width / 9;
	public int gPlusBtnHeight = Screen.height / 6;
	
	// Use this for initialization
	void Start () {
		
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void OnGUI(){
		
		if (GUI.Button(new Rect(Screen.width - gPlusBtnWidth - 10 , Screen.height - gPlusBtnHeight - 10, gPlusBtnWidth, gPlusBtnHeight), gPlusBtn)) { 
	
			Social.localUser.Authenticate((bool success) => {
				// handle success or failure
			});
		}
		
		if (GUI.Button(new Rect(10, 10, 300, 150), "Sign Out")) { 
			
			// sign out
			((PlayGamesPlatform) Social.Active).SignOut();
		}
		
		if (GUI.Button(new Rect(10, 170, 300, 150), "Leader Boards")) { 
			
			((PlayGamesPlatform) Social.Active).ShowLeaderboardUI("CgkI35Ov4YkMEAIQBg");
			
		}
		
	}
}