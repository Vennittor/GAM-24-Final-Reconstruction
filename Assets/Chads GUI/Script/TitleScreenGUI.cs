using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreenGUI : MonoBehaviour 
{
	public float textFadeSpeed;
	public float textFade;
	public float titleSpeed;
	public float backgroudFadeSpeed;

	public bool isFading;
	public bool titleMoving;
	public bool backgroundFade;

	public Vector3 newTitlePosition = new Vector3 (0,0,0);

	public Text pressAnyButton;

	public Image title;
	public Image background;

	// Use this for initialization
	void Start () 
	{
		titleMoving = true;
		backgroundFade = true;
		newTitlePosition = new Vector3 (0,title.transform.localPosition.y,title.transform.localPosition.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		PressAnyButton ();
		TitleMovement ();
		BackgroundFade ();
	}
	void PressAnyButton ()
	{
		//Loads The Level
		if (Input.anyKey)
		{
			newTitlePosition = new Vector3 (-1000,title.transform.localPosition.y,title.transform.localPosition.z);
			backgroundFade = false;
			Invoke ("LoadLevel",0.75f);
			return;
		}

		//PressAnyButton Fading
		pressAnyButton.color = new Color (1,0,0,textFade);
		if (isFading == false) 
		{
			textFade += textFadeSpeed;
			if (textFade > 0.90f)
			{
				isFading = true;
			}
		}
		else
		{
			textFade -= textFadeSpeed;
			if (textFade < 0.1f)
			{
				isFading = false;
			}
		}
	}

	void TitleMovement ()
	{
		if (titleMoving == true) 
		{
			title.transform.localPosition = Vector3.Lerp(title.transform.localPosition,newTitlePosition,titleSpeed * Time.deltaTime);
		}
	}

	void BackgroundFade ()
	{
		if (backgroundFade == true) 
		{
			background.color = Color.Lerp (background.color,new Color(1,1,1),backgroudFadeSpeed);
		}
		else
		{
			background.color = Color.Lerp (background.color,new Color(0,0,0),backgroudFadeSpeed);
		}
	}

	void LoadLevel ()
	{
		Application.LoadLevel (1);
	}
}
