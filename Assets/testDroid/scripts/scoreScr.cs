using UnityEngine;
using System.Collections;

public class scoreScr : MonoBehaviour {

	int coins;
	int money;
	int score;
	int increaseCoin;
	int increaseMoney;
	int countdown = 100;

	public GUITexture coinsGUI;
	public GUITexture moneyGUI;

	public GUIText coinsText;
	public GUIText moneyText;
	public GUIText scoreText;
	public GUIText notice;

	bool signInBonus = false;
	bool noticeBool = false;

	// Use this for initialization
	void Start () {

		money = 1000;
		coins = 5;
		score = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		coinsText.text = coins.ToString();
		moneyText.text = "$ " + money.ToString();
		scoreText.text = score.ToString();

		if (GameObject.Find ("MainCamera").GetComponent<menuScr> ().autoSignin && signInBonus == false) {

			increaseCoin = 10;
			increaseMoney = 1000;

			coins += increaseCoin;
			money += increaseMoney;
			signInBonus = true;

			noticeBool = true;

		}

		if(countdown < 0){

			countdown = 0;

		}

		if (noticeBool){

			notice.text = "You got recieved " + increaseCoin + " coins./n You got recieved " + increaseMoney + " dollars";
			countdown--;

		}
	
	}
}
