using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuGUIController : MonoBehaviour 
{
	public float colorChangeSpeed;
	public float buttonSpeed;

	public bool fadeIn;
	public bool moveButtonsIn;

	public GameObject groupAndSoloButtons;
	public GameObject bottomFourButtons;

	public Vector3 newGroupSoloPosition;
	public Vector3 newBottomFourPosition;

	public Image background;

	// Use this for initialization
	void Start () 
	{
		fadeIn = true;
		moveButtonsIn = true;
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
			background.color = Color.Lerp (background.color,new Color(1,1,1),colorChangeSpeed);
		}
		else
		{
			background.color = Color.Lerp (background.color,new Color(0,0,0),colorChangeSpeed);
		}
	}

	void ButtonMovement ()
	{
		if (moveButtonsIn == true) 
		{
			groupAndSoloButtons.transform.localPosition = Vector3.Lerp(groupAndSoloButtons.transform.localPosition,newGroupSoloPosition,buttonSpeed * Time.deltaTime);
			bottomFourButtons.transform.localPosition = Vector3.Lerp(bottomFourButtons.transform.localPosition,newBottomFourPosition,buttonSpeed * Time.deltaTime);
		}
		else 
		{
			newGroupSoloPosition = new Vector3 (groupAndSoloButtons.transform.localPosition.x,1500,groupAndSoloButtons.transform.localPosition.z);
			newBottomFourPosition = new Vector3 (bottomFourButtons.transform.localPosition.x,-1500,bottomFourButtons.transform.localPosition.z);
			groupAndSoloButtons.transform.localPosition = Vector3.Lerp(groupAndSoloButtons.transform.localPosition,newGroupSoloPosition,buttonSpeed * Time.deltaTime);
			bottomFourButtons.transform.localPosition = Vector3.Lerp(bottomFourButtons.transform.localPosition,newBottomFourPosition,buttonSpeed * Time.deltaTime);
		}
	}

	public void GroupButton ()
	{
		fadeIn = false;
		moveButtonsIn = false;
		Invoke ("LoadMenuTwo", 0.75f);
	}

	public void OptionsButton ()
	{
		fadeIn = false;
		moveButtonsIn = false;
		Invoke ("LoadOptionsMenu",0.75f);
	}

	void LoadMenuTwo ()
	{
		Application.LoadLevel (2);
	}

	void LoadOptionsMenu ()
	{
		Application.LoadLevel (6);
	}
}
