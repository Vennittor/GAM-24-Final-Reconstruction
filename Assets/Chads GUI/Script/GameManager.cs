using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour 
{
	public int playerCount;
	Dictionary<DataHolder.CharacterSelection, Type> character = new Dictionary<DataHolder.CharacterSelection, Type>();

	public GameObject playerDataHolder;
	//players
	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject playerThree;
	public GameObject playerFour;
	//spawns
	public GameObject[] spawns;
	public GameObject[] characters;
	public GameObject[] stages;

	public List<GameObject> possibleWinners = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		spawns = GameObject.FindGameObjectsWithTag ("Spawners");
		playerDataHolder = GameObject.Find ("DataHolder");
		playerCount = playerDataHolder.GetComponent<DataHolder> ().playerCount;
		AddToCharacters ();
		InitialSpawn ();
		PossibleWinnersList ();
	}

	void Update ()
	{
		Winning ();
		RemoveLooser ();
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
		if (playerOne.GetComponent<BaseCharacter>().lives <= 0)
		{
			possibleWinners.Remove (playerOne);
		}
		if (playerTwo.GetComponent<BaseCharacter>().lives <= 0)
		{
			possibleWinners.Remove (playerTwo);
		}
		if (playerCount > 2) 
		{
			if (playerThree.GetComponent<BaseCharacter>().lives <= 0)
			{
				possibleWinners.Remove (playerThree);
			}
		}
		if (playerCount > 3) 
		{
			if (playerFour.GetComponent<BaseCharacter>().lives <= 0)
			{
				possibleWinners.Remove (playerFour);
			}
		}
		playerDataHolder.GetComponent<DataHolder> ().possibleWinnersList = possibleWinners;
		playerDataHolder.GetComponent<DataHolder> ().winnerName = possibleWinners [0].gameObject.name;
	}
	


	void Winning ()
	{
		if (possibleWinners.Count <= 1) 
		{
			Application.LoadLevel (7);
		}
	}

	void AddToCharacters()
	{
		character.Add (DataHolder.CharacterSelection.kirby, typeof(KirbyCharacter));
		character.Add (DataHolder.CharacterSelection.link, typeof(LinkCharacter));
		character.Add (DataHolder.CharacterSelection.zeroSuitSamus, typeof(SamusCharacter));
		character.Add (DataHolder.CharacterSelection.mario, typeof(MarioCharacter));
	}

	void InitialSpawn ()
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

		for (int i=0; i<playerCount; i++)
		{
			GameObject temp = (GameObject)Instantiate(characters[0], spawns[i].transform.position, spawns[i].transform.rotation);
			Type value;
			temp.name = "Player"+(i+1);

			if (i == 0)
				playerOne = temp;
			else if (i == 1)
				playerTwo = temp;
			else if (i == 2)
				playerThree = temp;
			else if (i == 3)
				playerFour = temp;

			if (character.TryGetValue(playerDataHolder.GetComponent<DataHolder>().characters[i], out value))
			{
				temp.AddComponent(value);
			}
		}
	}
}













