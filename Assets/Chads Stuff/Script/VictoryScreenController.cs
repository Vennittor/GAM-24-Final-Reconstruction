using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class VictoryScreenController : MonoBehaviour 
{
	public string winnerName;

	public GameObject dataHolder;
	public GameObject topText;
	public GameObject winnerSpriteObject;
	public GameObject winnerTextObject;

	public Sprite[] characterSprites;

	public Image winnerSprite;

	public Text winnerText;

	// Use this for initialization
	void Start () 
	{
		dataHolder = GameObject.Find ("DataHolder");
		winnerName = dataHolder.GetComponent<DataHolder> ().winnerName;
		Invoke ("DetermineWinner",1.0f);
		InvokeRepeating ("WinnerMovement",1.5f,0.0001f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		TopTextMovement ();
	}

	void TopTextMovement ()
	{
		topText.transform.localPosition = Vector3.Lerp (topText.transform.localPosition,new Vector3 (0,0,0),2.75f * Time.deltaTime);
	}

	void WinnerMovement ()
	{
		winnerSpriteObject.transform.localPosition = Vector3.Lerp (winnerSpriteObject.transform.localPosition,new Vector3 (0,0,0),2.5f * Time.deltaTime);
		winnerTextObject.transform.localPosition = Vector3.Lerp (winnerTextObject.transform.localPosition,new Vector3 (0,0,0),2.5f * Time.deltaTime);
	}

	void DetermineWinner ()
	{
		winnerText.text = winnerName;
		if (winnerName == "MARIO") 
		{
			winnerSprite.sprite = characterSprites[0];
		}
		else if (winnerName == "DONKEY KONG")
		{
			winnerSprite.sprite = characterSprites[1];
		}
		else if (winnerName == "SAMUS")
		{
			winnerSprite.sprite = characterSprites[2];
		}
		else if (winnerName == "KIRBY")
		{
			winnerSprite.sprite = characterSprites[3];
		}
		else if (winnerName == "LUIGI")
		{
			winnerSprite.sprite = characterSprites[4];
		}
		else if (winnerName == "ZELDA")
		{
			winnerSprite.sprite = characterSprites[5];
		}
		else if (winnerName == "YOSHI")
		{
			winnerSprite.sprite = characterSprites[6];
		}
		else if (winnerName == "BOWSER")
		{
			winnerSprite.sprite = characterSprites[7];
		}
		else if (winnerName == "LINK")
		{
			winnerSprite.sprite = characterSprites[8];
		}
		else if (winnerName == "ZERO SUIT SAMUS")
		{
			winnerSprite.sprite = characterSprites[9];
		}
	}
}







