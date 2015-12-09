using UnityEngine;
using System.Collections;

public class PlayerDataHolder : MonoBehaviour 
{
	public int playerCount;

	public string pOneCharacterName;
	public string pTwoCharacterName;
	public string pThreeCharacterName;
	public string pFourCharacterName;

	public Sprite[] characterPortraits;
	public Sprite[] stockImages;
	public Sprite pOnePortrait;
	public Sprite pTwoPortrait;
	public Sprite pThreePortrait;
	public Sprite pFourPortrait;
	public Sprite pOneStock;
	public Sprite pTwoStock;
	public Sprite pThreeStock;
	public Sprite pFourStock;

	public enum CharacterSelection {mario,donkeyKong,samus,kirby,
									luigi,zelda,yoshi,bowser}

	public CharacterSelection pOneSelection;
	public CharacterSelection pTwoSelection;
	public CharacterSelection pThreeSelection;
	public CharacterSelection pFourSelection;

	public enum StageSelect {none,finalDestination,pokemonStadium,hyrule,greenyGreens}

	public StageSelect stageSelection;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerInfo ();
	}

	void PlayerInfo ()
	{
		//Player One
		if (pOneSelection == CharacterSelection.mario)
		{
			pOneCharacterName = "MARIO";
			pOnePortrait = characterPortraits[0];
			pOneStock = stockImages[0];
		}
		else if (pOneSelection == CharacterSelection.donkeyKong)
		{
			pOneCharacterName = "DONKEY KONG";
			pOnePortrait = characterPortraits[1];
			pOneStock = stockImages[1];
		}
		else if (pOneSelection == CharacterSelection.samus)
		{
			pOneCharacterName = "SAMUS";
			pOnePortrait = characterPortraits[2];
			pOneStock = stockImages[2];
		}
		else if (pOneSelection == CharacterSelection.kirby)
		{
			pOneCharacterName = "KIRBY";
			pOnePortrait = characterPortraits[3];
			pOneStock = stockImages[3];
		}
		else if (pOneSelection == CharacterSelection.luigi)
		{
			pOneCharacterName = "LUIGI";
			pOnePortrait = characterPortraits[4];
			pOneStock = stockImages[4];
		}
		else if (pOneSelection == CharacterSelection.zelda)
		{
			pOneCharacterName = "ZELDA";
			pOnePortrait = characterPortraits[5];
			pOneStock = stockImages[5];
		}
		else if (pOneSelection == CharacterSelection.yoshi)
		{
			pOneCharacterName = "YOSHI";
			pOnePortrait = characterPortraits[6];
			pOneStock = stockImages[6];
		}
		else if (pOneSelection == CharacterSelection.bowser)
		{
			pOneCharacterName = "BOWSER";
			pOnePortrait = characterPortraits[7];
			pOneStock = stockImages[7];
		}

		//Player Two
		if (pTwoSelection == CharacterSelection.mario)
		{
			pTwoCharacterName = "MARIO";
			pTwoPortrait = characterPortraits[0];
			pTwoStock = stockImages[0];
		}
		else if (pTwoSelection == CharacterSelection.donkeyKong)
		{
			pTwoCharacterName = "DONKEY KONG";
			pTwoPortrait = characterPortraits[1];
			pTwoStock = stockImages[1];
		}
		else if (pTwoSelection == CharacterSelection.samus)
		{
			pTwoCharacterName = "SAMUS";
			pTwoPortrait = characterPortraits[2];
			pTwoStock = stockImages[2];
		}
		else if (pTwoSelection == CharacterSelection.kirby)
		{
			pTwoCharacterName = "KIRBY";
			pTwoPortrait = characterPortraits[3];
			pTwoStock = stockImages[3];
		}
		else if (pTwoSelection == CharacterSelection.luigi)
		{
			pTwoCharacterName = "LUIGI";
			pTwoPortrait = characterPortraits[4];
			pTwoStock = stockImages[4];
		}
		else if (pTwoSelection == CharacterSelection.zelda)
		{
			pTwoCharacterName = "ZELDA";
			pTwoPortrait = characterPortraits[5];
			pTwoStock = stockImages[5];
		}
		else if (pTwoSelection == CharacterSelection.yoshi)
		{
			pTwoCharacterName = "YOSHI";
			pTwoPortrait = characterPortraits[6];
			pTwoStock = stockImages[6];
		}
		else if (pTwoSelection == CharacterSelection.bowser)
		{
			pTwoCharacterName = "BOWSER";
			pTwoPortrait = characterPortraits[7];
			pTwoStock = stockImages[7];
		}

		//Player Three
		if (pThreeSelection == CharacterSelection.mario)
		{
			pThreeCharacterName = "MARIO";
			pThreePortrait = characterPortraits[0];
			pThreeStock = stockImages[0];
		}
		else if (pThreeSelection == CharacterSelection.donkeyKong)
		{
			pThreeCharacterName = "DONKEY KONG";
			pThreePortrait = characterPortraits[1];
			pThreeStock = stockImages[1];
		}
		else if (pThreeSelection == CharacterSelection.samus)
		{
			pThreeCharacterName = "SAMUS";
			pThreePortrait = characterPortraits[2];
			pThreeStock = stockImages[2];
		}
		else if (pThreeSelection == CharacterSelection.kirby)
		{
			pThreeCharacterName = "KIRBY";
			pThreePortrait = characterPortraits[3];
			pThreeStock = stockImages[3];
		}
		else if (pThreeSelection == CharacterSelection.luigi)
		{
			pThreeCharacterName = "LUIGI";
			pThreePortrait = characterPortraits[4];
			pThreeStock = stockImages[4];
		}
		else if (pThreeSelection == CharacterSelection.zelda)
		{
			pThreeCharacterName = "ZELDA";
			pThreePortrait = characterPortraits[5];
			pThreeStock = stockImages[5];
		}
		else if (pThreeSelection == CharacterSelection.yoshi)
		{
			pThreeCharacterName = "YOSHI";
			pThreePortrait = characterPortraits[6];
			pThreeStock = stockImages[6];
		}
		else if (pThreeSelection == CharacterSelection.bowser)
		{
			pThreeCharacterName = "BOWSER";
			pThreePortrait = characterPortraits[7];
			pThreeStock = stockImages[7];
		}

		//Player Four
		if (pFourSelection == CharacterSelection.mario)
		{
			pFourCharacterName = "MARIO";
			pFourPortrait = characterPortraits[0];
			pFourStock = stockImages[0];
		}
		else if (pFourSelection == CharacterSelection.donkeyKong)
		{
			pFourCharacterName = "DONKEY KONG";
			pFourPortrait = characterPortraits[1];
			pFourStock = stockImages[1];
		}
		else if (pFourSelection == CharacterSelection.samus)
		{
			pFourCharacterName = "SAMUS";
			pFourPortrait = characterPortraits[2];
			pFourStock = stockImages[2];
		}
		else if (pFourSelection == CharacterSelection.kirby)
		{
			pFourCharacterName = "KIRBY";
			pFourPortrait = characterPortraits[3];
			pFourStock = stockImages[3];
		}
		else if (pFourSelection == CharacterSelection.luigi)
		{
			pFourCharacterName = "LUIGI";
			pFourPortrait = characterPortraits[4];
			pFourStock = stockImages[4];
		}
		else if (pFourSelection == CharacterSelection.zelda)
		{
			pFourCharacterName = "ZELDA";
			pFourPortrait = characterPortraits[5];
			pFourStock = stockImages[5];
		}
		else if (pFourSelection == CharacterSelection.yoshi)
		{
			pFourCharacterName = "YOSHI";
			pFourPortrait = characterPortraits[6];
			pFourStock = stockImages[6];
		}
		else if (pFourSelection == CharacterSelection.bowser)
		{
			pFourCharacterName = "BOWSER";
			pFourPortrait = characterPortraits[7];
			pFourStock = stockImages[7];
		}
	}
}

















