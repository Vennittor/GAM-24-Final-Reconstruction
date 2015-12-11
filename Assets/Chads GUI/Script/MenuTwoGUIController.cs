using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuTwoGUIController : MonoBehaviour 
{
	public float fadeSpeed;
	public float buttonSpeed;

	public bool fadeIn;
	public bool buttonMove;

	public GameObject brawlRotationButtons;
	public GameObject RSTNButtons;

	public Vector3 newBRPositoin;
	public Vector3 newRSTNPosition;

	public Image background;

	// Use this for initialization
	void Start () 
	{
		fadeIn = true;
		buttonMove = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Fade ();
		ButtonMovement ();
	}

	void Fade ()
	{
		if (fadeIn == true)
		{
			background.color = Color.Lerp (background.color,new Color (1,1,1),fadeSpeed);
		}
		else
		{
			background.color = Color.Lerp (background.color,new Color (0,0,0),fadeSpeed);
		}
	}

	void ButtonMovement ()
	{

		if (buttonMove == true) 
		{
			brawlRotationButtons.transform.localPosition = Vector3.Lerp (brawlRotationButtons.transform.localPosition,newBRPositoin,buttonSpeed * Time.deltaTime);
			RSTNButtons.transform.localPosition = Vector3.Lerp (RSTNButtons.transform.localPosition,newRSTNPosition,buttonSpeed * Time.deltaTime);
		}
		else
		{
			newBRPositoin = new Vector3 (brawlRotationButtons.transform.localPosition.x,1000,brawlRotationButtons.transform.localPosition.z);
			newRSTNPosition = new Vector3 (1000,RSTNButtons.transform.localPosition.y,RSTNButtons.transform.localPosition.z);
			brawlRotationButtons.transform.localPosition = Vector3.Lerp (brawlRotationButtons.transform.localPosition,newBRPositoin,buttonSpeed * Time.deltaTime);
			RSTNButtons.transform.localPosition = Vector3.Lerp (RSTNButtons.transform.localPosition,newRSTNPosition,buttonSpeed * Time.deltaTime);
		}
	}

	public void BackButton ()
	{
		fadeIn = false;
		buttonMove = false;
		Invoke ("LoadMainMenu",.75f);
	}

	public void BrawlButton ()
	{
		fadeIn = false;
		buttonMove = false;
		Invoke ("LoadCharacterSelect",.75f);
	}

	void LoadMainMenu ()
	{
		Application.LoadLevel (1);
	}

	void LoadCharacterSelect ()
	{
		Application.LoadLevel (3);
	}
}









