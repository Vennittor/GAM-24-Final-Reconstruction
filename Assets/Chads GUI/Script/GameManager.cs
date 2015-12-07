using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public int playerCount;

	public GameObject playerDataHolder;
	//players
	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject playerThree;
	public GameObject playerFour;
	//spawns
	public GameObject pOneSpawn;
	public GameObject pTwoSpawn;
	public GameObject pThreeSpawn;
	public GameObject pFourSpawn;
	public GameObject[] characters;
	public GameObject[] stages;

	// Use this for initialization
	void Start () 
	{
		playerDataHolder = GameObject.Find ("PlayerDataHolder");
		playerCount = playerDataHolder.GetComponent<PlayerDataHolder> ().playerCount;
		InitialSpawn ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void InitialSpawn ()
	{
		//Stage Spawn
		if (playerDataHolder.GetComponent<PlayerDataHolder>().stageSelection == PlayerDataHolder.StageSelect.finalDestination)
		{
			Instantiate (stages[0],new Vector3(0,-2,0),transform.rotation);
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().stageSelection == PlayerDataHolder.StageSelect.pokemonStadium)
		{
			Instantiate (stages[1],new Vector3(0,-2,0),transform.rotation);
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().stageSelection == PlayerDataHolder.StageSelect.hyrule)
		{
			Instantiate (stages[2],new Vector3(0,-2,0),transform.rotation);
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().stageSelection == PlayerDataHolder.StageSelect.greenyGreens)
		{
			Instantiate (stages[3],new Vector3(0,-2,0),transform.rotation);
		}

		//Player One
		if (playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection == PlayerDataHolder.CharacterSelection.mario)
		{
			playerOne = Instantiate (characters[0],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection == PlayerDataHolder.CharacterSelection.donkeyKong)
		{
			playerOne = Instantiate (characters[1],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection == PlayerDataHolder.CharacterSelection.samus)
		{
			playerOne = Instantiate (characters[2],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection == PlayerDataHolder.CharacterSelection.kirby)
		{
			playerOne = Instantiate (characters[3],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection == PlayerDataHolder.CharacterSelection.luigi)
		{
			playerOne = Instantiate (characters[4],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection == PlayerDataHolder.CharacterSelection.zelda)
		{
			playerOne = Instantiate (characters[5],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection == PlayerDataHolder.CharacterSelection.yoshi)
		{
			playerOne = Instantiate (characters[6],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pOneSelection == PlayerDataHolder.CharacterSelection.bowser)
		{
			playerOne = Instantiate (characters[7],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		
		//Player Two
		if (playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection == PlayerDataHolder.CharacterSelection.mario)
		{
			playerTwo = Instantiate (characters[0],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection == PlayerDataHolder.CharacterSelection.donkeyKong)
		{
			playerTwo = Instantiate (characters[1],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection == PlayerDataHolder.CharacterSelection.samus)
		{
			playerTwo = Instantiate (characters[2],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection == PlayerDataHolder.CharacterSelection.kirby)
		{
			playerTwo = Instantiate (characters[3],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection == PlayerDataHolder.CharacterSelection.luigi)
		{
			playerTwo = Instantiate (characters[4],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection == PlayerDataHolder.CharacterSelection.zelda)
		{
			playerTwo = Instantiate (characters[5],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection == PlayerDataHolder.CharacterSelection.yoshi)
		{
			playerTwo = Instantiate (characters[6],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<PlayerDataHolder>().pTwoSelection == PlayerDataHolder.CharacterSelection.bowser)
		{
			playerTwo = Instantiate (characters[7],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		
		//Player Three
		if (playerCount > 2)
		{
			if (playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection == PlayerDataHolder.CharacterSelection.mario)
			{
				playerThree = Instantiate (characters[0],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection == PlayerDataHolder.CharacterSelection.donkeyKong)
			{
				playerThree = Instantiate (characters[1],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection == PlayerDataHolder.CharacterSelection.samus)
			{
				playerThree = Instantiate (characters[2],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection == PlayerDataHolder.CharacterSelection.kirby)
			{
				playerThree = Instantiate (characters[3],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection == PlayerDataHolder.CharacterSelection.luigi)
			{
				playerThree = Instantiate (characters[4],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection == PlayerDataHolder.CharacterSelection.zelda)
			{
				playerThree = Instantiate (characters[5],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection == PlayerDataHolder.CharacterSelection.yoshi)
			{
				playerThree = Instantiate (characters[6],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pThreeSelection == PlayerDataHolder.CharacterSelection.bowser)
			{
				playerThree = Instantiate (characters[7],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
		}
		
		//Player Four
		if (playerCount > 3) 
		{
			if (playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection == PlayerDataHolder.CharacterSelection.mario)
			{
				playerFour = Instantiate (characters[0],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection == PlayerDataHolder.CharacterSelection.donkeyKong)
			{
				playerFour = Instantiate (characters[0],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection == PlayerDataHolder.CharacterSelection.samus)
			{
				playerFour = Instantiate (characters[0],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection == PlayerDataHolder.CharacterSelection.kirby)
			{
				playerFour = Instantiate (characters[0],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection == PlayerDataHolder.CharacterSelection.luigi)
			{
				playerFour = Instantiate (characters[0],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection == PlayerDataHolder.CharacterSelection.zelda)
			{
				playerFour = Instantiate (characters[0],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection == PlayerDataHolder.CharacterSelection.yoshi)
			{
				playerFour = Instantiate (characters[0],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<PlayerDataHolder>().pFourSelection == PlayerDataHolder.CharacterSelection.bowser)
			{
				playerFour = Instantiate (characters[0],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
		}
	}
}













