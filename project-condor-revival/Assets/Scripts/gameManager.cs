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
    public Text countAcertosText;
    public Text countErrosText;
    public bool gameOver;
    public int countAcertos;
    public int countErros;
    AudioSource audio;
    public AudioClip AudioRight;
    public AudioClip AudioWrong;
    public GameObject resultBar;
    public GameObject buttonsGroup;
    public GameObject postGameButtonsGroup;


    // Use this for initialization
    void Start ()
    {
        gameOver = false;
        audio = GetComponent<AudioSource>();
        resultBar = GameObject.FindGameObjectWithTag("resultBar");
        buttonsGroup = GameObject.FindGameObjectWithTag("buttonsGroup");
        postGameButtonsGroup = GameObject.FindGameObjectWithTag("postGameButtonsGroup");
        resultBar.SetActive(false);
        postGameButtonsGroup.SetActive(false);
        timeLeft = 99;
        countAcertos = 0;
        countErros = 0;
		Randomize ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!gameOver)
        {
			timeLeft -= Time.deltaTime;
			timeText.text = ""+timeLeft;
            if (timeLeft < 10)
            {
                timeText.color = Color.red;
            }
            if (timeLeft < 0)
            {
				GameOver();
			}
		}

	}

	public void Randomize()
	{
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
        resultBar.SetActive(true);
        postGameButtonsGroup.SetActive(true);
        buttonsGroup.SetActive(false);
        gameOver = true;
        countAcertosText.text = "="+countAcertos;
        countErrosText.text = "="+countErros;
    }

	public void clickMais()
	{
		playerSignal = 1;
        if (playerSignal == signal)
        {
            countAcertos += 1;
            audio.PlayOneShot(AudioRight, 0.7F);
        }
        else
        {
            audio.PlayOneShot(AudioWrong, 0.7F);
            countErros += 1;
        }
		Randomize ();
	}

	public void clickMenos()
	{
		playerSignal = 2;
        if (playerSignal == signal)
        {
            countAcertos += 1;
            audio.PlayOneShot(AudioRight, 0.7F);
        }
        else
        {
            audio.PlayOneShot(AudioWrong, 0.7F);
            countErros += 1;
        }
        Randomize ();
	}

	public void clickMult()
	{
		playerSignal = 3;
        if (playerSignal == signal)
        {
            countAcertos += 1;
            audio.PlayOneShot(AudioRight, 0.7F);
        }
        else
        {
            audio.PlayOneShot(AudioWrong, 0.7F);
            countErros += 1;
        }
        Randomize ();
	}

	public void clickDiv()
	{
		playerSignal = 4;
        if (playerSignal == signal)
        {
            countAcertos += 1;
            audio.PlayOneShot(AudioRight, 0.7F);
        }
        else
        {
            audio.PlayOneShot(AudioWrong, 0.7F);
            countErros += 1;
        }
        Randomize ();
	}

    public void reloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void exit()
    {
        Application.Quit();
    }

}
