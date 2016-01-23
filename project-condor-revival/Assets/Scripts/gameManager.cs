using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameManager : MonoBehaviour {

	public float timeLeft;
	public int  num1;
	public int  num2;
	public int  signal;
	public int  playerSignal;
	public int  numResult;
	public Text timeText;
	public Text num1Text;
	public Text num2Text;
	public Text numResultText;
	public bool gameOver;



	// Use this for initialization
	void Start () {
		timeLeft = 99;
		gameOver = false;
		Randomize ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			timeLeft -= Time.deltaTime;
			timeText.text = ""+timeLeft;
			if(timeLeft < 0){
				GameOver();
			}
		}

	}

	public void Randomize()
	{
		//		randomValueType = Random.Range(3, 5);
		num1 = Random.Range (0, 99);
		num2 = Random.Range (1, 99);
		signal = Random.Range (1, 4);
		if (signal == 1) 
		{
			numResult = num1 + num2;
		}
		else if(signal == 2) 
		{
			numResult = num1 - num2;
		}
		else if(signal == 3) 
		{
			numResult = num1 * num2;
		}
		else if(signal == 4)
		{
			numResult = num1 / num2;
		}
		num1Text.text = ""+num1;
		num2Text.text = ""+num2;
		numResultText.text = ""+numResult;
	}

	public void GameOver()
	{
		gameOver = true;
	}

	public void clickMais()
	{
		playerSignal = 1;
		Randomize ();
	}

	public void clickMenos()
	{
		playerSignal = 2;
		Randomize ();
	}

	public void clickMult()
	{
		playerSignal = 3;
		Randomize ();
	}

	public void clickDiv()
	{
		playerSignal = 4;
		Randomize ();
	}
}
