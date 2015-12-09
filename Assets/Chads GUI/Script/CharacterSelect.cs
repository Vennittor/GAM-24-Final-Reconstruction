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
		fadeIn = true;
		buttonMove = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerCount = playerDataHolder.GetComponent<PlayerDataHolder> ().playerCount;
		playerCountText.text = "NUMBER OF PLAYERS    " + playerDataHolder.GetComponent<PlayerDataHolder> ().playerCount;

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
		if (playerDataHolder.GetComponent<PlayerDataHolder>().playerCount < 4)
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().playerCount ++;
		}
	}
	public void PlayerCountDecrease ()
	{
		if (playerDataHolder.GetComponent<PlayerDataHolder>().playerCount > 1)
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().playerCount --;
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
			playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection = PlayerDataHolder.CharacterSelection.mario;
			pOneCharacter.sprite = characterSprites[0];
			pOneCharacterText.text = "MARIO";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection = PlayerDataHolder.CharacterSelection.mario;
			pTwoCharacter.sprite = characterSprites[0];
			pTwoCharacterText.text = "MARIO";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection = PlayerDataHolder.CharacterSelection.mario;
			pThreeCharacter.sprite = characterSprites[0];
			pThreeCharacterText.text = "MARIO";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection = PlayerDataHolder.CharacterSelection.mario;
			pFourCharacter.sprite = characterSprites[0];
			pFourCharacterText.text = "MARIO";
		}
	}
	public void DonkeyKong ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection = PlayerDataHolder.CharacterSelection.donkeyKong;
			pOneCharacter.sprite = characterSprites[1];
			pOneCharacterText.text = "DONKEY KONG";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection = PlayerDataHolder.CharacterSelection.donkeyKong;
			pTwoCharacter.sprite = characterSprites[1];
			pTwoCharacterText.text = "DONKEY KONG";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection = PlayerDataHolder.CharacterSelection.donkeyKong;
			pThreeCharacter.sprite = characterSprites[1];
			pThreeCharacterText.text = "DONKEY KONG";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection = PlayerDataHolder.CharacterSelection.donkeyKong;
			pFourCharacter.sprite = characterSprites[1];
			pFourCharacterText.text = "DONKEY KONG";
		}
	}
	public void Samus ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection = PlayerDataHolder.CharacterSelection.samus;
			pOneCharacter.sprite = characterSprites[2];
			pOneCharacterText.text = "SAMUS";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection = PlayerDataHolder.CharacterSelection.samus;
			pTwoCharacter.sprite = characterSprites[2];
			pTwoCharacterText.text = "SAMUS";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection = PlayerDataHolder.CharacterSelection.samus;
			pThreeCharacter.sprite = characterSprites[2];
			pThreeCharacterText.text = "SAMUS";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection = PlayerDataHolder.CharacterSelection.samus;
			pFourCharacter.sprite = characterSprites[2];
			pFourCharacterText.text = "SAMUS";
		}
	}
	public void Kirby ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection = PlayerDataHolder.CharacterSelection.kirby;
			pOneCharacter.sprite = characterSprites[3];
			pOneCharacterText.text = "KIRBY";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection = PlayerDataHolder.CharacterSelection.kirby;
			pTwoCharacter.sprite = characterSprites[3];
			pTwoCharacterText.text = "KIRBY";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection = PlayerDataHolder.CharacterSelection.kirby;
			pThreeCharacter.sprite = characterSprites[3];
			pThreeCharacterText.text = "KIRBY";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection = PlayerDataHolder.CharacterSelection.kirby;
			pFourCharacter.sprite = characterSprites[3];
			pFourCharacterText.text = "KIRBY";
		}
	}
	public void Luigi ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection = PlayerDataHolder.CharacterSelection.luigi;
			pOneCharacter.sprite = characterSprites[4];
			pOneCharacterText.text = "LUIGI";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection = PlayerDataHolder.CharacterSelection.luigi;
			pTwoCharacter.sprite = characterSprites[4];
			pTwoCharacterText.text = "LUIGI";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection = PlayerDataHolder.CharacterSelection.luigi;
			pThreeCharacter.sprite = characterSprites[4];
			pThreeCharacterText.text = "LUIGI";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection = PlayerDataHolder.CharacterSelection.luigi;
			pFourCharacter.sprite = characterSprites[4];
			pFourCharacterText.text = "LUIGI";
		}
	}
	public void Zelda ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection = PlayerDataHolder.CharacterSelection.zelda;
			pOneCharacter.sprite = characterSprites[5];
			pOneCharacterText.text = "ZELDA";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection = PlayerDataHolder.CharacterSelection.zelda;
			pTwoCharacter.sprite = characterSprites[5];
			pTwoCharacterText.text = "ZELDA";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection = PlayerDataHolder.CharacterSelection.zelda;
			pThreeCharacter.sprite = characterSprites[5];
			pThreeCharacterText.text = "ZELDA";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection = PlayerDataHolder.CharacterSelection.zelda;
			pFourCharacter.sprite = characterSprites[5];
			pFourCharacterText.text = "ZELDA";
		}
	}
	public void Yoshi ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection = PlayerDataHolder.CharacterSelection.yoshi;
			pOneCharacter.sprite = characterSprites[6];
			pOneCharacterText.text = "YOSHI";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection = PlayerDataHolder.CharacterSelection.yoshi;
			pTwoCharacter.sprite = characterSprites[6];
			pTwoCharacterText.text = "YOSHI";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection = PlayerDataHolder.CharacterSelection.yoshi;
			pThreeCharacter.sprite = characterSprites[6];
			pThreeCharacterText.text = "YOSHI";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection = PlayerDataHolder.CharacterSelection.yoshi;
			pFourCharacter.sprite = characterSprites[6];
			pFourCharacterText.text = "YOSHI";
		}
	}
	public void Bowser ()
	{
		if (playerTurn == TurnTracker.playerOne)
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection = PlayerDataHolder.CharacterSelection.bowser;
			pOneCharacter.sprite = characterSprites[7];
			pOneCharacterText.text = "BOWSER";
		}
		else if (playerTurn == TurnTracker.playerTwo) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection = PlayerDataHolder.CharacterSelection.bowser;
			pTwoCharacter.sprite = characterSprites[7];
			pTwoCharacterText.text = "BOWSER";
		}
		else if (playerTurn == TurnTracker.playerThree) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection = PlayerDataHolder.CharacterSelection.bowser;
			pThreeCharacter.sprite = characterSprites[7];
			pThreeCharacterText.text = "BOWSER";
		}
		else if (playerTurn == TurnTracker.playerFour) 
		{
			playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection = PlayerDataHolder.CharacterSelection.bowser;
			pFourCharacter.sprite = characterSprites[7];
			pFourCharacterText.text = "BOWSER";
		}
	}
}







