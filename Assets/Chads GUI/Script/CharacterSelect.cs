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
	public bool selectingCharacters;
	
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
	public Text pOnePlayerText;
	public Text pTwoPlayerText;
	public Text pThreePlayerText;
	public Text pFourPlayerText;

	public Sprite[] characterSprites;

	public enum TurnTracker{playerOne,playerTwo,playerThree,playerFour}

	public TurnTracker playerTurn;

	// Use this for initialization
	void Start () 
	{
		playerDataHolder = GameObject.Find ("DataHolder");
		fadeIn = true;
		buttonMove = true;
		selectingCharacters = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerCount = playerDataHolder.GetComponent<DataHolder> ().playerCount;
		playerCountText.text = "NUMBER OF PLAYERS    " + playerDataHolder.GetComponent<DataHolder> ().playerCount;

		PlayerSelectionDisplay ();
		Fade ();
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
			selectionGrid.transform.localPosition = Vector3.Lerp (selectionGrid.transform.localPosition,new Vector3(-1500,60,0),buttonSpeed * Time.deltaTime);
			topButtons.transform.localPosition = Vector3.Lerp (topButtons.transform.localPosition,new Vector3 (0,500,0),buttonSpeed * Time.deltaTime);
		}

		//Moves selected character GUI
		if (selectingCharacters == true) 
		{
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
		else
		{
			pOneSelection.transform.localPosition = Vector3.Lerp
				(pOneSelection.transform.localPosition,new Vector3(0,-500,0),buttonSpeed * Time.deltaTime);
			pTwoSelection.transform.localPosition = Vector3.Lerp
				(pTwoSelection.transform.localPosition,new Vector3(200,-500,0),buttonSpeed * Time.deltaTime);
			pThreeSelection.transform.localPosition = Vector3.Lerp
				(pThreeSelection.transform.localPosition,new Vector3(400,-500,0),buttonSpeed * Time.deltaTime);
			pFourSelection.transform.localPosition = Vector3.Lerp
				(pFourSelection.transform.localPosition,new Vector3(600,-500,0),buttonSpeed * Time.deltaTime);
		}
	}

	void LoadStageSelect ()
	{
		buttonMove = false;
		Application.LoadLevel (4);
	}

	void LoadMenuTwo ()
	{
		buttonMove = false;
		Application.LoadLevel (2);
	}

	void LoadOptionsMenu ()
	{
		buttonMove = false;
		Application.LoadLevel (6);
	}

	//BUTTONS CODE IS UNDER THIS POINT

	public void Back ()
	{
		buttonMove = false;
		selectingCharacters = false;
		Invoke ("LoadMenuTwo",0.75f);
	}

	public void Options ()
	{
		buttonMove = false;
		selectingCharacters = false;
		playerDataHolder.GetComponent<DataHolder> ().characterMenuLoad = true;
		Invoke ("LoadOptionsMenu",0.75f);
	}

	//Toggles CPU
	public void POneToggle ()
	{
		if (playerDataHolder.GetComponent<DataHolder> ().pOneIsPlayer == true) 
		{
			playerDataHolder.GetComponent<DataHolder> ().pOneIsPlayer = false;
			pOnePlayerText.text = "CPU";
		}
		else 
		{
			playerDataHolder.GetComponent<DataHolder> ().pOneIsPlayer = true;
			pOnePlayerText.text = "PLAYER 1";
		}
	}
	public void PTwoToggle ()
	{
		if (playerDataHolder.GetComponent<DataHolder> ().pTwoIsPlayer == true) 
		{
			playerDataHolder.GetComponent<DataHolder> ().pTwoIsPlayer = false;
			pTwoPlayerText.text = "CPU";
		}
		else 
		{
			playerDataHolder.GetComponent<DataHolder> ().pTwoIsPlayer = true;
			pTwoPlayerText.text = "PLAYER 2";
		}
	}
	public void PThreeToggle ()
	{
		if (playerDataHolder.GetComponent<DataHolder> ().pThreeIsPlayer == true) 
		{
			playerDataHolder.GetComponent<DataHolder> ().pThreeIsPlayer = false;
			pThreePlayerText.text = "CPU";
		}
		else 
		{
			playerDataHolder.GetComponent<DataHolder> ().pThreeIsPlayer = true;
			pThreePlayerText.text = "PLAYER 3";
		}
	}
	public void PFourToggle ()
	{
		if (playerDataHolder.GetComponent<DataHolder> ().pFourIsPlayer == true) 
		{
			playerDataHolder.GetComponent<DataHolder> ().pFourIsPlayer = false;
			pFourPlayerText.text = "CPU";
		}
		else 
		{
			playerDataHolder.GetComponent<DataHolder> ().pFourIsPlayer = true;
			pFourPlayerText.text = "PLAYER 4";
		}
	}

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
				buttonMove = false;
				selectingCharacters = false;
				Invoke ("LoadStageSelect",0.75f);
			}
		} 
		else if (playerCount == 3) 
		{
			if (pOneCharacter.sprite != null && pTwoCharacter.sprite != null && pThreeCharacter.sprite != null)
			{
				buttonMove = false;
				selectingCharacters = false;
				Invoke ("LoadStageSelect",0.75f);
			}
		}
		else if (playerCount == 4)
		{
			if (pOneCharacter.sprite != null && pTwoCharacter.sprite != null && 
			    pThreeCharacter.sprite != null && pFourCharacter.sprite != null)
			{
				buttonMove = false;
				selectingCharacters = false;
				Invoke ("LoadStageSelect",0.75f);
			}
		}
	}

	//Selects the character and applies it to correct players GUI
	public void Mario ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.mario;
			pOneCharacter.color = new Color (1,1,1,1);
			pOneCharacter.sprite = characterSprites[0];
			pOneCharacterText.text = "MARIO";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.mario;
			pTwoCharacter.color = new Color (1,1,1,1);
			pTwoCharacter.sprite = characterSprites[0];
			pTwoCharacterText.text = "MARIO";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.mario;
			pThreeCharacter.color = new Color (1,1,1,1);
			pThreeCharacter.sprite = characterSprites[0];
			pThreeCharacterText.text = "MARIO";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.mario;
			pFourCharacter.color = new Color (1,1,1,1);
			pFourCharacter.sprite = characterSprites[0];
			pFourCharacterText.text = "MARIO";
		}
	}
	public void DonkeyKong ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.donkeyKong;
			pOneCharacter.color = new Color (1,1,1,1);
			pOneCharacter.sprite = characterSprites[1];
			pOneCharacterText.text = "DONKEY KONG";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.donkeyKong;
			pTwoCharacter.color = new Color (1,1,1,1);
			pTwoCharacter.sprite = characterSprites[1];
			pTwoCharacterText.text = "DONKEY KONG";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.donkeyKong;
			pThreeCharacter.color = new Color (1,1,1,1);
			pThreeCharacter.sprite = characterSprites[1];
			pThreeCharacterText.text = "DONKEY KONG";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.donkeyKong;
			pFourCharacter.color = new Color (1,1,1,1);
			pFourCharacter.sprite = characterSprites[1];
			pFourCharacterText.text = "DONKEY KONG";
		}
	}
//	public void Samus ()
//	{
//		if (playerTurn == TurnTracker.playerOne)
//		{
//			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.samus;
//			pOneCharacter.color = new Color (1,1,1,1);
//			pOneCharacter.sprite = characterSprites[2];
//			pOneCharacterText.text = "SAMUS";
//		}
//		else if (playerTurn == TurnTracker.playerTwo) 
//		{
//			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.samus;
//			pTwoCharacter.color = new Color (1,1,1,1);
//			pTwoCharacter.sprite = characterSprites[2];
//			pTwoCharacterText.text = "SAMUS";
//		}
//		else if (playerTurn == TurnTracker.playerThree) 
//		{
//			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.samus;
//			pThreeCharacter.color = new Color (1,1,1,1);
//			pThreeCharacter.sprite = characterSprites[2];
//			pThreeCharacterText.text = "SAMUS";
//		}
//		else if (playerTurn == TurnTracker.playerFour) 
//		{
//			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.samus;
//			pFourCharacter.color = new Color (1,1,1,1);
//			pFourCharacter.sprite = characterSprites[2];
//			pFourCharacterText.text = "SAMUS";
//		}
//	}
	public void Kirby ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.kirby;
			pOneCharacter.color = new Color (1,1,1,1);
			pOneCharacter.sprite = characterSprites[3];
			pOneCharacterText.text = "KIRBY";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.kirby;
			pTwoCharacter.color = new Color (1,1,1,1);
			pTwoCharacter.sprite = characterSprites[3];
			pTwoCharacterText.text = "KIRBY";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.kirby;
			pThreeCharacter.color = new Color (1,1,1,1);
			pThreeCharacter.sprite = characterSprites[3];
			pThreeCharacterText.text = "KIRBY";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.kirby;
			pFourCharacter.color = new Color (1,1,1,1);
			pFourCharacter.sprite = characterSprites[3];
			pFourCharacterText.text = "KIRBY";
		}
	}
//	public void Luigi ()
//	{
//		if (playerTurn == TurnTracker.playerOne)
//		{
//			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.luigi;
//			pOneCharacter.color = new Color (1,1,1,1);
//			pOneCharacter.sprite = characterSprites[4];
//			pOneCharacterText.text = "LUIGI";
//		}
//		else if (playerTurn == TurnTracker.playerTwo) 
//		{
//			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.luigi;
//			pTwoCharacter.color = new Color (1,1,1,1);
//			pTwoCharacter.sprite = characterSprites[4];
//			pTwoCharacterText.text = "LUIGI";
//		}
//		else if (playerTurn == TurnTracker.playerThree) 
//		{
//			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.luigi;
//			pThreeCharacter.color = new Color (1,1,1,1);
//			pThreeCharacter.sprite = characterSprites[4];
//			pThreeCharacterText.text = "LUIGI";
//		}
//		else if (playerTurn == TurnTracker.playerFour) 
//		{
//			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.luigi;
//			pFourCharacter.color = new Color (1,1,1,1);
//			pFourCharacter.sprite = characterSprites[4];
//			pFourCharacterText.text = "LUIGI";
//		}
//	}
//	public void Zelda ()
//	{
//		if (playerTurn == TurnTracker.playerOne)
//		{
//			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.zelda;
//			pOneCharacter.color = new Color (1,1,1,1);
//			pOneCharacter.sprite = characterSprites[5];
//			pOneCharacterText.text = "ZELDA";
//		}
//		else if (playerTurn == TurnTracker.playerTwo) 
//		{
//			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.zelda;
//			pTwoCharacter.color = new Color (1,1,1,1);
//			pTwoCharacter.sprite = characterSprites[5];
//			pTwoCharacterText.text = "ZELDA";
//		}
//		else if (playerTurn == TurnTracker.playerThree) 
//		{
//			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.zelda;
//			pThreeCharacter.color = new Color (1,1,1,1);
//			pThreeCharacter.sprite = characterSprites[5];
//			pThreeCharacterText.text = "ZELDA";
//		}
//		else if (playerTurn == TurnTracker.playerFour) 
//		{
//			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.zelda;
//			pFourCharacter.color = new Color (1,1,1,1);
//			pFourCharacter.sprite = characterSprites[5];
//			pFourCharacterText.text = "ZELDA";
//		}
//	}
//	public void Yoshi ()
//	{
//		if (playerTurn == TurnTracker.playerOne)
//		{
//			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.yoshi;
//			pOneCharacter.color = new Color (1,1,1,1);
//			pOneCharacter.sprite = characterSprites[6];
//			pOneCharacterText.text = "YOSHI";
//		}
//		else if (playerTurn == TurnTracker.playerTwo) 
//		{
//			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.yoshi;
//			pTwoCharacter.color = new Color (1,1,1,1);
//			pTwoCharacter.sprite = characterSprites[6];
//			pTwoCharacterText.text = "YOSHI";
//		}
//		else if (playerTurn == TurnTracker.playerThree) 
//		{
//			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.yoshi;
//			pThreeCharacter.color = new Color (1,1,1,1);
//			pThreeCharacter.sprite = characterSprites[6];
//			pThreeCharacterText.text = "YOSHI";
//		}
//		else if (playerTurn == TurnTracker.playerFour) 
//		{
//			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.yoshi;
//			pFourCharacter.color = new Color (1,1,1,1);
//			pFourCharacter.sprite = characterSprites[6];
//			pFourCharacterText.text = "YOSHI";
//		}
//	}
	public void Bowser ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.bowser;
			pOneCharacter.color = new Color (1,1,1,1);
			pOneCharacter.sprite = characterSprites[7];
			pOneCharacterText.text = "BOWSER";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.bowser;
			pTwoCharacter.color = new Color (1,1,1,1);
			pTwoCharacter.sprite = characterSprites[7];
			pTwoCharacterText.text = "BOWSER";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.bowser;
			pThreeCharacter.color = new Color (1,1,1,1);
			pThreeCharacter.sprite = characterSprites[7];
			pThreeCharacterText.text = "BOWSER";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.bowser;
			pFourCharacter.color = new Color (1,1,1,1);
			pFourCharacter.sprite = characterSprites[7];
			pFourCharacterText.text = "BOWSER";
		}
	}

	public void Link ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.link;
			pOneCharacter.color = new Color (1,1,1,1);
			pOneCharacter.sprite = characterSprites[8];
			pOneCharacterText.text = "LINK";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.link;
			pTwoCharacter.color = new Color (1,1,1,1);
			pTwoCharacter.sprite = characterSprites[8];
			pTwoCharacterText.text = "LINK";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.link;
			pThreeCharacter.color = new Color (1,1,1,1);
			pThreeCharacter.sprite = characterSprites[8];
			pThreeCharacterText.text = "LINK";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.link;
			pFourCharacter.color = new Color (1,1,1,1);
			pFourCharacter.sprite = characterSprites[8];
			pFourCharacterText.text = "LINK";
		}
	}

	public void ZeroSuitSamus ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<DataHolder>().pOneSelection = DataHolder.CharacterSelection.zeroSuitSamus;
			pOneCharacter.color = new Color (1,1,1,1);
			pOneCharacter.sprite = characterSprites[9];
			pOneCharacterText.text = "ZERO SUIT SAMUS";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<DataHolder>().pTwoSelection = DataHolder.CharacterSelection.zeroSuitSamus;
			pTwoCharacter.color = new Color (1,1,1,1);
			pTwoCharacter.sprite = characterSprites[9];
			pTwoCharacterText.text = "ZERO SUIT SAMUS";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<DataHolder>().pThreeSelection = DataHolder.CharacterSelection.zeroSuitSamus;
			pThreeCharacter.color = new Color (1,1,1,1);
			pThreeCharacter.sprite = characterSprites[9];
			pThreeCharacterText.text = "ZERO SUIT SAMUS";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<DataHolder>().pFourSelection = DataHolder.CharacterSelection.zeroSuitSamus;
			pFourCharacter.color = new Color (1,1,1,1);
			pFourCharacter.sprite = characterSprites[9];
			pFourCharacterText.text = "ZERO SUIT SAMUS";
		}
	}
}







