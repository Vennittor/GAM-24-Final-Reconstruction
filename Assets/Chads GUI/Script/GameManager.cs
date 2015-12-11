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

	// Use this for initialization
	void Start () 
	{
		spawns = GameObject.FindGameObjectsWithTag ("Spawners");
		playerDataHolder = GameObject.Find ("DataHolder");
		playerCount = playerDataHolder.GetComponent<DataHolder> ().playerCount;
		AddToCharacters ();
		InitialSpawn ();
	}

	void AddToCharacters()
	{
		character.Add (DataHolder.CharacterSelection.kirby, typeof(KirbyCharacter));
//		character.Add (DataHolder.CharacterSelection.link, typeof(LinkCharacter));
//		character.Add (DataHolder.CharacterSelection.donkeyKong, typeof(DonkeyKongCharacter));
//		character.Add (DataHolder.CharacterSelection.mario, typeof(MarioCharacter));
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













