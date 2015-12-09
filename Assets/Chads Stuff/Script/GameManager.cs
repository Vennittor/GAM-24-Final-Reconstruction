using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	public GameObject deathSpawn;
	public GameObject[] characters;
	public GameObject[] stages;

	public List<GameObject> possibleWinners;

	// Use this for initialization
	void Start () 
	{
		playerDataHolder = GameObject.Find ("DataHolder");
		playerCount = playerDataHolder.GetComponent<DataHolder> ().playerCount;

		StageSpawn ();
		FindPlayreSpawners ();
		InitialSpawn ();
		SetLives ();
		PossibleWinnersList ();
		InvokeRepeating ("RemoveLooser",1f,0.5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Winning ();
	}

	void Winning ()
	{
		if (possibleWinners.Count <= 1) 
		{
			Invoke ("LoadVictoryScreen",1f);
		}
	}

	void LoadVictoryScreen ()
	{
		Application.LoadLevel (7);
	}
	void SetLives ()
	{
		playerOne.GetComponent<TempPlayerController> ().lives =
			playerDataHolder.GetComponent<DataHolder> ().livesCount;
		playerTwo.GetComponent<TempPlayerController> ().lives =
			playerDataHolder.GetComponent<DataHolder> ().livesCount;
		if (playerCount > 2)
		{
			playerThree.GetComponent<TempPlayerController> ().lives =
				playerDataHolder.GetComponent<DataHolder> ().livesCount;
		}
		if (playerCount > 3)
		{
			playerFour.GetComponent<TempPlayerController> ().lives =
				playerDataHolder.GetComponent<DataHolder> ().livesCount;
		}
	}

	void PossibleWinnersList ()
	{
		possibleWinners.Add (playerOne);
		possibleWinners.Add (playerTwo);
		if (playerDataHolder.GetComponent<DataHolder> ().playerCount >= 3) 
		{
			possibleWinners.Add (playerThree);
		}
		if (playerDataHolder.GetComponent<DataHolder> ().playerCount >= 4) 
		{
			possibleWinners.Add (playerFour);
		}
		playerDataHolder.GetComponent<DataHolder> ().possibleWinnersList = possibleWinners;
	}

	void RemoveLooser ()
	{
		if (playerOne.GetComponent<TempPlayerController>().lives <= 0)
		{
			possibleWinners.Remove (playerOne);
		}
		if (playerDataHolder.GetComponent<DataHolder> ().playerCount == 2) 
		{

		}
		if (playerTwo.GetComponent<TempPlayerController>().lives <= 0)
		{
			possibleWinners.Remove (playerTwo);
		}
		if (playerCount > 2) 
		{
			if (playerThree.GetComponent<TempPlayerController>().lives <= 0)
			{
				possibleWinners.Remove (playerThree);
			}
		}
		if (playerCount > 3) 
		{
			if (playerFour.GetComponent<TempPlayerController>().lives <= 0)
			{
				possibleWinners.Remove (playerFour);
			}
		}
		playerDataHolder.GetComponent<DataHolder> ().possibleWinnersList = possibleWinners;
		playerDataHolder.GetComponent<DataHolder> ().winnerName = 
			possibleWinners [0].GetComponent<TempPlayerController> ().characterName;
	}

	void Respawn ()
	{
		if (playerOne.GetComponent<TempPlayerController>().lives > 0)
		{
			if (playerOne.GetComponent<TempPlayerController>().isDead == true)
			{
				playerOne.GetComponent<BoxCollider>().enabled = false;
				playerOne.transform.position = deathSpawn.transform.position;
			}
		}
		if (playerTwo.GetComponent<TempPlayerController>().lives > 0)
		{
			if (playerTwo.GetComponent<TempPlayerController>().isDead == true)
			{
				playerTwo.GetComponent<BoxCollider>().enabled = false;
				playerTwo.transform.position = deathSpawn.transform.position;
			}
		}
		
		if (playerCount > 2) 
		{
			if (playerThree.GetComponent<TempPlayerController>().lives > 0)
			{
				if (playerThree.GetComponent<TempPlayerController>().isDead == true)
				{
					playerThree.GetComponent<BoxCollider>().enabled = false;
					playerThree.transform.position = deathSpawn.transform.position;
				}
			}
		}
		if (playerCount > 3) 
		{
			if (playerFour.GetComponent<TempPlayerController>().lives > 0)
			{
				if (playerFour.GetComponent<TempPlayerController>().isDead == true)
				{
					playerFour.GetComponent<BoxCollider>().enabled = false;
					playerFour.transform.position = deathSpawn.transform.position;
				}
			}
		}
		
		//Dropdown
		if (Input.anyKey)
		{
			playerOne.GetComponent<TempPlayerController>().isDead = false;
			playerOne.GetComponent<BoxCollider>().enabled = true;
		}
	}

	void StageSpawn ()
	{
		//Stage Spawn
		if (playerDataHolder.GetComponent<DataHolder>().stageSelection == DataHolder.StageSelect.finalDestination)
		{
			Instantiate (stages[0],new Vector3(0,-2,0),transform.rotation);
		}
		else if (playerDataHolder.GetComponent<DataHolder>().stageSelection == DataHolder.StageSelect.pokemonStadium)
		{
			Instantiate (stages[1],new Vector3(0,-2,0),transform.rotation);
		}
		else if (playerDataHolder.GetComponent<DataHolder>().stageSelection == DataHolder.StageSelect.hyrule)
		{
			Instantiate (stages[2],new Vector3(0,-2,0),transform.rotation);
		}
		else if (playerDataHolder.GetComponent<DataHolder>().stageSelection == DataHolder.StageSelect.greenyGreens)
		{
			Instantiate (stages[3],new Vector3(0,-2,0),transform.rotation);
		}
		else if (playerDataHolder.GetComponent<DataHolder>().stageSelection == DataHolder.StageSelect.yoshiIsland)
		{
			Instantiate (stages[4],new Vector3(0,-2,0),transform.rotation);
		}
		else if (playerDataHolder.GetComponent<DataHolder>().stageSelection == DataHolder.StageSelect.frigateOrpheon)
		{
			Instantiate (stages[5],new Vector3(0,-2,0),transform.rotation);
		}

	}

	void FindPlayreSpawners ()
	{
		pOneSpawn = GameObject.Find ("SpawnerOne");
		pTwoSpawn = GameObject.Find ("SpawnerTwo");
		pThreeSpawn = GameObject.Find ("SpawnerThree");
		pFourSpawn = GameObject.Find ("SpawnerFour");
	}

	void InitialSpawn ()
	{
		//Player One
		if (playerDataHolder.GetComponent<DataHolder>().pOneSelection == DataHolder.CharacterSelection.mario)
		{
			playerOne = Instantiate (characters[0],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pOneSelection == DataHolder.CharacterSelection.donkeyKong)
		{
			playerOne = Instantiate (characters[1],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pOneSelection == DataHolder.CharacterSelection.samus)
		{
			playerOne = Instantiate (characters[2],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pOneSelection == DataHolder.CharacterSelection.kirby)
		{
			playerOne = Instantiate (characters[3],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pOneSelection == DataHolder.CharacterSelection.luigi)
		{
			playerOne = Instantiate (characters[4],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pOneSelection == DataHolder.CharacterSelection.zelda)
		{
			playerOne = Instantiate (characters[5],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pOneSelection == DataHolder.CharacterSelection.yoshi)
		{
			playerOne = Instantiate (characters[6],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pOneSelection == DataHolder.CharacterSelection.bowser)
		{
			playerOne = Instantiate (characters[7],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pOneSelection == DataHolder.CharacterSelection.link)
		{
			playerOne = Instantiate (characters[8],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pOneSelection == DataHolder.CharacterSelection.zeroSuitSamus)
		{
			playerOne = Instantiate (characters[9],pOneSpawn.transform.position,pOneSpawn.transform.rotation) as GameObject;
		}
		playerOne.name = "PlayerOne";
		
		//Player Two
		if (playerDataHolder.GetComponent<DataHolder>().pTwoSelection == DataHolder.CharacterSelection.mario)
		{
			playerTwo = Instantiate (characters[0],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pTwoSelection == DataHolder.CharacterSelection.donkeyKong)
		{
			playerTwo = Instantiate (characters[1],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pTwoSelection == DataHolder.CharacterSelection.samus)
		{
			playerTwo = Instantiate (characters[2],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pTwoSelection == DataHolder.CharacterSelection.kirby)
		{
			playerTwo = Instantiate (characters[3],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pTwoSelection == DataHolder.CharacterSelection.luigi)
		{
			playerTwo = Instantiate (characters[4],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pTwoSelection == DataHolder.CharacterSelection.zelda)
		{
			playerTwo = Instantiate (characters[5],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pTwoSelection == DataHolder.CharacterSelection.yoshi)
		{
			playerTwo = Instantiate (characters[6],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pTwoSelection == DataHolder.CharacterSelection.bowser)
		{
			playerTwo = Instantiate (characters[7],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pTwoSelection == DataHolder.CharacterSelection.link)
		{
			playerTwo = Instantiate (characters[8],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		else if (playerDataHolder.GetComponent<DataHolder>().pTwoSelection == DataHolder.CharacterSelection.zeroSuitSamus)
		{
			playerTwo = Instantiate (characters[9],pTwoSpawn.transform.position,pTwoSpawn.transform.rotation) as GameObject;
		}
		playerTwo.name = "PlayreTwo";

		//Player Three
		if (playerCount > 2)
		{
			if (playerDataHolder.GetComponent<DataHolder>().pThreeSelection == DataHolder.CharacterSelection.mario)
			{
				playerThree = Instantiate (characters[0],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pThreeSelection == DataHolder.CharacterSelection.donkeyKong)
			{
				playerThree = Instantiate (characters[1],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pThreeSelection == DataHolder.CharacterSelection.samus)
			{
				playerThree = Instantiate (characters[2],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pThreeSelection == DataHolder.CharacterSelection.kirby)
			{
				playerThree = Instantiate (characters[3],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pThreeSelection == DataHolder.CharacterSelection.luigi)
			{
				playerThree = Instantiate (characters[4],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pThreeSelection == DataHolder.CharacterSelection.zelda)
			{
				playerThree = Instantiate (characters[5],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pThreeSelection == DataHolder.CharacterSelection.yoshi)
			{
				playerThree = Instantiate (characters[6],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pThreeSelection == DataHolder.CharacterSelection.bowser)
			{
				playerThree = Instantiate (characters[7],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pThreeSelection == DataHolder.CharacterSelection.link)
			{
				playerThree = Instantiate (characters[8],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pThreeSelection == DataHolder.CharacterSelection.zeroSuitSamus)
			{
				playerThree = Instantiate (characters[9],pThreeSpawn.transform.position,pThreeSpawn.transform.rotation) as GameObject;
			}
			playerThree.name = "PlayerThree";
		}
		
		//Player Four
		if (playerCount > 3) 
		{
			if (playerDataHolder.GetComponent<DataHolder>().pFourSelection == DataHolder.CharacterSelection.mario)
			{
				playerFour = Instantiate (characters[0],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pFourSelection == DataHolder.CharacterSelection.donkeyKong)
			{
				playerFour = Instantiate (characters[1],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pFourSelection == DataHolder.CharacterSelection.samus)
			{
				playerFour = Instantiate (characters[2],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pFourSelection == DataHolder.CharacterSelection.kirby)
			{
				playerFour = Instantiate (characters[3],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pFourSelection == DataHolder.CharacterSelection.luigi)
			{
				playerFour = Instantiate (characters[4],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pFourSelection == DataHolder.CharacterSelection.zelda)
			{
				playerFour = Instantiate (characters[5],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pFourSelection == DataHolder.CharacterSelection.yoshi)
			{
				playerFour = Instantiate (characters[6],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pFourSelection == DataHolder.CharacterSelection.bowser)
			{
				playerFour = Instantiate (characters[7],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pFourSelection == DataHolder.CharacterSelection.link)
			{
				playerFour = Instantiate (characters[8],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			else if (playerDataHolder.GetComponent<DataHolder>().pFourSelection == DataHolder.CharacterSelection.zeroSuitSamus)
			{
				playerFour = Instantiate (characters[9],pFourSpawn.transform.position,pFourSpawn.transform.rotation) as GameObject;
			}
			playerFour.name = "PlayerFour";
		}
	}
}













