using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour 
{
	public int playerCount;

	public float fadeSpeed;
	public float buttonSpeed;

	public bool fadeIn;
	public bool buttonMove;
	
	public GameObject playerDataHolder;
	public GameObject selectionGrid;
	public GameObject topButtons;
	public GameObject pOneSelection;
	public GameObject pTwoSelection;
	public GameObject pThreeSelection;
	public GameObject pFourSelection;

	public Vector3 selectionGridPosition;
	public Vector3 topButtonsPosition;

	public Image background;
	public Image pOneCharacter;
	public Image pTwoCharacter;
	public Image pThreeCharacter;
	public Image pFourCharacter;

	public Text playerCountText;
	public Text pOneCharacterText;
	public Text pTwoCharacterText;
	public Text pThreeCharacterText;
	public Text pFourCharacterText;

	public Sprite[] characterSprites;

	public enum TurnTracker{playerOne,playerTwo,playerThree,playerFour}

	public TurnTracker playerTurn;

	// Use this for initialization
	void Start () 
	{
		playerDataHolder = GameObject.Find ("DataHolder");
		fadeIn = true;
		buttonMove = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerCount = playerDataHolder.GetComponent<DataHolder> ().playerCount;
		playerCountText.text = "NUMBER OF PLAYERS    " + playerDataHolder.GetComponent<DataHolder> ().playerCount;

		PlayerSelectionDisplay ();
		Fade ();
	}

 	public void OptionsMenu ()
	{
		fadeIn = false;
		buttonMove = false;
		playerDataHolder.GetComponent<DataHolder> ().characterMenuLoad = true;
		Invoke ("LoadOptionsMenu",0.75f);
	}

	void LoadOptionsMenu ()
	{
		Application.LoadLevel (6);
	}

	//Fades the background in and out
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

	//Moves the selected character GUI into position
	void PlayerSelectionDisplay ()
	{
		//Moves the character selection grid and buttons
		if (buttonMove == true) 
		{
			selectionGridPosition = new Vector3 (0,60,0);
			topButtonsPosition = new Vector3 (0,0,0);
			selectionGrid.transform.localPosition = Vector3.Lerp (selectionGrid.transform.localPosition,selectionGridPosition,buttonSpeed * Time.deltaTime);
			topButtons.transform.localPosition = Vector3.Lerp (topButtons.transform.localPosition,topButtonsPosition,buttonSpeed * Time.deltaTime);
		}
		else
		{
			selectionGridPosition = new Vector3 (1500,60,0);
			topButtonsPosition = new Vector3 (0,1500,0);
			selectionGrid.transform.localPosition = Vector3.Lerp (selectionGrid.transform.localPosition,new Vector3(-500,60,0),buttonSpeed * Time.deltaTime);
			topButtons.transform.localPosition = Vector3.Lerp (topButtons.transform.localPosition,new Vector3 (0,500,0),buttonSpeed * Time.deltaTime);
		}

		//Moves selected character GUI
		if (playerCount >= 1)
		{
			pOneSelection.transform.localPosition = Vector3.Lerp
				(pOneSelection.transform.localPosition,new Vector3(0,0,0),buttonSpeed * Time.deltaTime);
		}
		else
		{
			pOneSelection.transform.localPosition = Vector3.Lerp
				(pOneSelection.transform.localPosition,new Vector3(0,-500,0),buttonSpeed * Time.deltaTime);
		}
		if (playerCount >= 2) 
		{
			pTwoSelection.transform.localPosition = Vector3.Lerp
				(pTwoSelection.transform.localPosition,new Vector3(200,0,0),buttonSpeed * Time.deltaTime);
		}
		else
		{
			pTwoSelection.transform.localPosition = Vector3.Lerp
				(pTwoSelection.transform.localPosition,new Vector3(200,-500,0),buttonSpeed * Time.deltaTime);
		}
		if (playerCount >= 3)
		{
			pThreeSelection.transform.localPosition = Vector3.Lerp
				(pThreeSelection.transform.localPosition,new Vector3(400,0,0),buttonSpeed * Time.deltaTime);
		}
		else
		{
			pThreeSelection.transform.localPosition = Vector3.Lerp
				(pThreeSelection.transform.localPosition,new Vector3(400,-500,0),buttonSpeed * Time.deltaTime);
		}
		if (playerCount == 4)
		{
			pFourSelection.transform.localPosition = Vector3.Lerp
				(pFourSelection.transform.localPosition,new Vector3(600,0,0),buttonSpeed * Time.deltaTime);
		}
		else
		{
			pFourSelection.transform.localPosition = Vector3.Lerp
				(pFourSelection.transform.localPosition,new Vector3(600,-500,0),buttonSpeed * Time.deltaTime);
		}
	}
	
	//BUTTONS CODE IS UNDER THIS POINT

	//playerCount controller
	public void PlayerCountIncrease ()
	{
		if (playerDataHolder.GetComponent<DataHolder>().playerCount < 4)
		{
			playerDataHolder.GetComponent<DataHolder>().playerCount ++;
		}
	}
	public void PlayerCountDecrease ()
	{
		if (playerDataHolder.GetComponent<DataHolder>().playerCount > 1)
		{
			playerDataHolder.GetComponent<DataHolder>().playerCount --;
		}
	}

	//Changes the player who is selecting their character
	public void pOneSelectButton ()
	{
		playerTurn = TurnTracker.playerOne;
	}
	public void pTwoSelectButton ()
	{
		playerTurn = TurnTracker.playerTwo;
	}
	public void pThreeSelectButton ()
	{
		playerTurn = TurnTracker.playerThree;
	}
	public void pFourSelectButton ()
	{
		playerTurn = TurnTracker.playerFour;
	}

	//Checks that everyone selected a character and starts the game
	public void BrawlButton ()
	{
		if (playerCount == 2) 
		{
			if (pOneCharacter.sprite != null && pTwoCharacter.sprite != null) 
			{
				Application.LoadLevel (4);
				buttonMove = false;
			}
		} 
		else if (playerCount == 3) 
		{
			if (pOneCharacter.sprite != null && pTwoCharacter.sprite != null && pThreeCharacter.sprite != null)
			{
				Application.LoadLevel (4);
				buttonMove = false;
			}
		}
		else if (playerCount == 4)
		{
			if (pOneCharacter.sprite != null && pTwoCharacter.sprite != null && 
			    pThreeCharacter.sprite != null && pFourCharacter.sprite != null)
			{
				Application.LoadLevel (4);
				buttonMove = false;
			}
		}
	}

	//Selects the character and applies it to correct players GUI
	public void Mario ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.mario;
			pOneCharacter.sprite = characterSprites[0];
			pOneCharacterText.text = "MARIO";
			pOneCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.mario;
			pTwoCharacter.sprite = characterSprites[0];
			pTwoCharacterText.text = "MARIO";
			pTwoCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.mario;
			pThreeCharacter.sprite = characterSprites[0];
			pThreeCharacterText.text = "MARIO";
			pThreeCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.mario;
			pFourCharacter.sprite = characterSprites[0];
			pFourCharacterText.text = "MARIO";
			pFourCharacter.color = new Color (1,1,1,1);
		}
	}
	public void DonkeyKong ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.donkeyKong;
			pOneCharacter.sprite = characterSprites[1];
			pOneCharacterText.text = "DONKEY KONG";
			pOneCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.donkeyKong;
			pTwoCharacter.sprite = characterSprites[1];
			pTwoCharacterText.text = "DONKEY KONG";
			pTwoCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.donkeyKong;
			pThreeCharacter.sprite = characterSprites[1];
			pThreeCharacterText.text = "DONKEY KONG";
			pThreeCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.donkeyKong;
			pFourCharacter.sprite = characterSprites[1];
			pFourCharacterText.text = "DONKEY KONG";
			pFourCharacter.color = new Color (1,1,1,1);
		}
	}
	public void Samus ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.samus;
			pOneCharacter.sprite = characterSprites[2];
			pOneCharacterText.text = "SAMUS";
			pOneCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.samus;
			pTwoCharacter.sprite = characterSprites[2];
			pTwoCharacterText.text = "SAMUS";
			pTwoCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.samus;
			pThreeCharacter.sprite = characterSprites[2];
			pThreeCharacterText.text = "SAMUS";
			pThreeCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.samus;
			pFourCharacter.sprite = characterSprites[2];
			pFourCharacterText.text = "SAMUS";
			pFourCharacter.color = new Color (1,1,1,1);
		}
	}
	public void Kirby ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.kirby;
			pOneCharacter.sprite = characterSprites[3];
			pOneCharacterText.text = "KIRBY";
			pOneCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.kirby;
			pTwoCharacter.sprite = characterSprites[3];
			pTwoCharacterText.text = "KIRBY";
			pTwoCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.kirby;
			pThreeCharacter.sprite = characterSprites[3];
			pThreeCharacterText.text = "KIRBY";
			pThreeCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.kirby;
			pFourCharacter.sprite = characterSprites[3];
			pFourCharacterText.text = "KIRBY";
			pFourCharacter.color = new Color (1,1,1,1);
		}
	}
	public void Luigi ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.luigi;
			pOneCharacter.sprite = characterSprites[4];
			pOneCharacterText.text = "LUIGI";
			pOneCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.luigi;
			pTwoCharacter.sprite = characterSprites[4];
			pTwoCharacterText.text = "LUIGI";
			pTwoCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.luigi;
			pThreeCharacter.sprite = characterSprites[4];
			pThreeCharacterText.text = "LUIGI";
			pThreeCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.luigi;
			pFourCharacter.sprite = characterSprites[4];
			pFourCharacterText.text = "LUIGI";
			pFourCharacter.color = new Color (1,1,1,1);
		}
		pOneCharacter.color = new Color (1,1,1,1);
	}
	public void Zelda ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.zelda;
			pOneCharacter.sprite = characterSprites[5];
			pOneCharacterText.text = "ZELDA";
			pOneCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.zelda;
			pTwoCharacter.sprite = characterSprites[5];
			pTwoCharacterText.text = "ZELDA";
			pTwoCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.zelda;
			pThreeCharacter.sprite = characterSprites[5];
			pThreeCharacterText.text = "ZELDA";
			pThreeCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.zelda;
			pFourCharacter.sprite = characterSprites[5];
			pFourCharacterText.text = "ZELDA";
			pFourCharacter.color = new Color (1,1,1,1);
		}
	}
	public void Yoshi ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.yoshi;
			pOneCharacter.sprite = characterSprites[6];
			pOneCharacterText.text = "YOSHI";
			pOneCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.yoshi;
			pTwoCharacter.sprite = characterSprites[6];
			pTwoCharacterText.text = "YOSHI";
			pTwoCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.yoshi;
			pThreeCharacter.sprite = characterSprites[6];
			pThreeCharacterText.text = "YOSHI";
			pThreeCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.yoshi;
			pFourCharacter.sprite = characterSprites[6];
			pFourCharacterText.text = "YOSHI";
			pFourCharacter.color = new Color (1,1,1,1);
		}
	}
	public void Bowser ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.bowser;
			pOneCharacter.sprite = characterSprites[7];
			pOneCharacterText.text = "BOWSER";
			pOneCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.bowser;
			pTwoCharacter.sprite = characterSprites[7];
			pTwoCharacterText.text = "BOWSER";
			pTwoCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.bowser;
			pThreeCharacter.sprite = characterSprites[7];
			pThreeCharacterText.text = "BOWSER";
			pThreeCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.bowser;
			pFourCharacter.sprite = characterSprites[7];
			pFourCharacterText.text = "BOWSER";
			pFourCharacter.color = new Color (1,1,1,1);
		}
	}

	public void Link ()
	{
		if (playerTurn == TurnTracker.playerOne) 
		{
			playerDataHolder.GetComponent<DataHolder> ().pOneSelection = DataHolder.CharacterSelection.link;
			pOneCharacter.sprite = characterSprites [8];
			pOneCharacterText.text = "LINK";
			pOneCharacter.color = new Color (1,1,1,1);
		} 
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder> ().pTwoSelection = DataHolder.CharacterSelection.link;
			pTwoCharacter.sprite = characterSprites [8];
			pTwoCharacterText.text = "LINK";
			pTwoCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder> ().pThreeSelection = DataHolder.CharacterSelection.link;
			pThreeCharacter.sprite = characterSprites [8];
			pThreeCharacterText.text = "LINK";
			pThreeCharacter.color = new Color (1,1,1,1);
		} 
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder> ().pFourSelection = DataHolder.CharacterSelection.link;
			pFourCharacter.sprite = characterSprites [8];
			pFourCharacterText.text = "LINK";
			pFourCharacter.color = new Color (1,1,1,1);
		}
	}

	public void ZeroSuitSamus ()
	{
		if (playerTurn == TurnTracker.playerOne) 
		{
			playerDataHolder.GetComponent<DataHolder> ().pOneSelection = DataHolder.CharacterSelection.zeroSuitSamus;
			pOneCharacter.sprite = characterSprites [9];
			pOneCharacterText.text = "ZERO SUIT SAMUS";
			pOneCharacter.color = new Color (1,1,1,1);
		} 
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder> ().pTwoSelection = DataHolder.CharacterSelection.zeroSuitSamus;
			pTwoCharacter.sprite = characterSprites [9];
			pTwoCharacterText.text = "ZERO SUIT SAMUS";
			pTwoCharacter.color = new Color (1,1,1,1);
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder> ().pThreeSelection = DataHolder.CharacterSelection.zeroSuitSamus;
			pThreeCharacter.sprite = characterSprites [9];
			pThreeCharacterText.text = "ZERO SUIT SAMUS";
			pThreeCharacter.color = new Color (1,1,1,1);
		} 
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder> ().pFourSelection = DataHolder.CharacterSelection.zeroSuitSamus;
			pFourCharacter.sprite = characterSprites [9];
			pFourCharacterText.text = "ZERO SUIT SAMUS";
			pFourCharacter.color = new Color (1,1,1,1);
		}
	}
}







