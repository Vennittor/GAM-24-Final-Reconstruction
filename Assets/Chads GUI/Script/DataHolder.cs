using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataHolder : MonoBehaviour 
{
	public int playerCount;
	public int livesCount;

	public float itemSpawnDelay;

	public bool characterMenuLoad = false;
	public bool pOneIsPlayer;
	public bool pTwoIsPlayer;
	public bool pThreeIsPlayer;
	public bool pFourIsPlayer;

	public string winnerName;

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

	public List <GameObject> possibleWinnersList;

	public List <ItemSelector.itemName> veryRare;
	public List <ItemSelector.itemName> rare;
	public List <ItemSelector.itemName> uncommon;
	public List <ItemSelector.itemName> common;

	public enum itemName {FAN, BEAMSWORD, HOMERUNBAT, POKEBALL, BO_OMB,
		ICE, METAL,MUSHROOM,LASERGUN,STAR,SMASHBALL,BUNNYEARS,
		HAMMER,PILL,SHELL,TOMATO,FIREFLOWER,TRIPMINE,BANANAPEEL,
		BUMPER};

	public enum CharacterSelection {mario,donkeyKong,samus,kirby,
									luigi,zelda,yoshi,bowser,link,zeroSuitSamus}

	public CharacterSelection[] characters = new CharacterSelection[4];
	public Vector3[] colliderSizes = new Vector3[4];

	public CharacterSelection pOneSelection;
	public CharacterSelection pTwoSelection;
	public CharacterSelection pThreeSelection;
	public CharacterSelection pFourSelection;

	public enum StageSelect {none,finalDestination,pokemonStadium,hyrule,greenyGreens,yoshiIsland,frigateOrpheon}

	public StageSelect stageSelection;

	public AudioSource menuMusic;

	//mouse pointer
	public Texture2D handTexture;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (transform.gameObject);
		pOneIsPlayer = true;
		pTwoIsPlayer = true;
		pThreeIsPlayer = true;
		pFourIsPlayer = true;
		Cursor.SetCursor (handTexture,Vector2.zero,CursorMode.Auto);
		menuMusic.Play ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerInfo ();
//		ItemSpawner ();
	}

	void ItemSpawner ()
	{
		if (Application.loadedLevel == 5)
		{
			menuMusic.Stop ();
			GameObject itemSpawn;
			itemSpawn = GameObject.Find ("ItemSpawn");
			itemSpawn.GetComponent<ItemSelector>().veryRare = veryRare;
			itemSpawn.GetComponent<ItemSelector>().rare = rare;
			itemSpawn.GetComponent<ItemSelector>().unCommon = uncommon;
			itemSpawn.GetComponent<ItemSelector>().common = common;

//			//Fallback code incase we cant get items lists to work
//			//Very Rare Items
			itemSpawn.GetComponent<ItemSelector>().dontSpawn.Add (ItemSelector.itemName.SMASHBALL);
			itemSpawn.GetComponent<ItemSelector>().dontSpawn.Add (ItemSelector.itemName.HAMMER);
            itemSpawn.GetComponent<ItemSelector>().veryRare.Add(ItemSelector.itemName.STAR);
            itemSpawn.GetComponent<ItemSelector>().veryRare.Add(ItemSelector.itemName.TOMATO);
            //Rare Items
            itemSpawn.GetComponent<ItemSelector>().dontSpawn.Add (ItemSelector.itemName.HOMERUNBAT);
			itemSpawn.GetComponent<ItemSelector>().rare.Add (ItemSelector.itemName.MUSHROOM);
			itemSpawn.GetComponent<ItemSelector>().rare.Add (ItemSelector.itemName.FAN);
			itemSpawn.GetComponent<ItemSelector>().dontSpawn.Add (ItemSelector.itemName.LASERGUN);
			//Uncommon Items
			itemSpawn.GetComponent<ItemSelector>().dontSpawn.Add (ItemSelector.itemName.BEAMSWORD);
			itemSpawn.GetComponent<ItemSelector>().unCommon.Add (ItemSelector.itemName.POKEBALL);
			itemSpawn.GetComponent<ItemSelector>().unCommon.Add (ItemSelector.itemName.BO_OMB);
			itemSpawn.GetComponent<ItemSelector>().unCommon.Add (ItemSelector.itemName.ICE);
			itemSpawn.GetComponent<ItemSelector>().unCommon.Add (ItemSelector.itemName.METAL);
			
		itemSpawn.GetComponent<ItemSelector>().unCommon.Add (ItemSelector.itemName.BUNNYEARS);
			//Common Items
			itemSpawn.GetComponent<ItemSelector>().common.Add (ItemSelector.itemName.PILL);
			itemSpawn.GetComponent<ItemSelector>().common.Add (ItemSelector.itemName.SHELL);
			
			itemSpawn.GetComponent<ItemSelector>().dontSpawn.Add (ItemSelector.itemName.FIREFLOWER);
			itemSpawn.GetComponent<ItemSelector>().dontSpawn.Add (ItemSelector.itemName.TRIPMINE);
			itemSpawn.GetComponent<ItemSelector>().common.Add (ItemSelector.itemName.BANANAPEEL);
			itemSpawn.GetComponent<ItemSelector>().common.Add (ItemSelector.itemName.BUMPER);
			//Change spawn rate
			itemSpawn.GetComponent<ItemSpawner>().spawnRate = itemSpawnDelay;
		}
	}


	void PlayerInfo ()
	{
		//Player One
		if (pOneSelection == CharacterSelection.mario)
		{
			pOneCharacterName = "MARIO";
			pOnePortrait = characterPortraits[0];
			pOneStock = stockImages[0];
			characters[0] = CharacterSelection.mario;
			colliderSizes[0] = new Vector3(1f, 2.5f, 1f);
		}
		else if (pOneSelection == CharacterSelection.donkeyKong)
		{
			pOneCharacterName = "DONKEY KONG";
			pOnePortrait = characterPortraits[1];
			pOneStock = stockImages[1];
			characters[0] = CharacterSelection.donkeyKong;
		}
		else if (pOneSelection == CharacterSelection.samus)
		{
			pOneCharacterName = "SAMUS";
			pOnePortrait = characterPortraits[2];
			pOneStock = stockImages[2];
			characters[0] = CharacterSelection.samus;
		}
		else if (pOneSelection == CharacterSelection.kirby)
		{
			pOneCharacterName = "KIRBY";
			pOnePortrait = characterPortraits[3];
			pOneStock = stockImages[3];
			characters[0] = CharacterSelection.kirby;
			colliderSizes[0] = new Vector3(1f, 1f, 1f);
		}
		else if (pOneSelection == CharacterSelection.luigi)
		{
			pOneCharacterName = "LUIGI";
			pOnePortrait = characterPortraits[4];
			pOneStock = stockImages[4];
			characters[0] = CharacterSelection.luigi;
		}
		else if (pOneSelection == CharacterSelection.zelda)
		{
			pOneCharacterName = "ZELDA";
			pOnePortrait = characterPortraits[5];
			pOneStock = stockImages[5];
			characters[0] = CharacterSelection.zelda;
		}
		else if (pOneSelection == CharacterSelection.yoshi)
		{
			pOneCharacterName = "YOSHI";
			pOnePortrait = characterPortraits[6];
			pOneStock = stockImages[6];
			characters[0] = CharacterSelection.yoshi;
		}
		else if (pOneSelection == CharacterSelection.bowser)
		{
			pOneCharacterName = "BOWSER";
			pOnePortrait = characterPortraits[7];
			pOneStock = stockImages[7];
			characters[0] = CharacterSelection.bowser;
		}
		else if (pOneSelection == CharacterSelection.link)
		{
			pOneCharacterName = "LINK";
			pOnePortrait = characterPortraits[8];
			pOneStock = stockImages[8];
			characters[0] = CharacterSelection.link;
			colliderSizes[0] = new Vector3(1f, 2.5f, 1f);
		}
		else if (pOneSelection == CharacterSelection.zeroSuitSamus)
		{
			pOneCharacterName = "ZERO SUIT SAMUS";
			pOnePortrait = characterPortraits[9];
			pOneStock = stockImages[9];
			characters[0] = CharacterSelection.zeroSuitSamus;
			colliderSizes[0] = new Vector3(1f, 3.5f, 1f);
		}

		//Player Two
		if (pTwoSelection == CharacterSelection.mario)
		{
			pTwoCharacterName = "MARIO";
			pTwoPortrait = characterPortraits[0];
			pTwoStock = stockImages[0];
			characters[1] = CharacterSelection.mario;
			colliderSizes[1] = new Vector3(1f, 2.5f, 1f);
		}
		else if (pTwoSelection == CharacterSelection.donkeyKong)
		{
			pTwoCharacterName = "DONKEY KONG";
			pTwoPortrait = characterPortraits[1];
			pTwoStock = stockImages[1];
			characters[1] = CharacterSelection.donkeyKong;
		}
		else if (pTwoSelection == CharacterSelection.samus)
		{
			pTwoCharacterName = "SAMUS";
			pTwoPortrait = characterPortraits[2];
			pTwoStock = stockImages[2];
			characters[1] = CharacterSelection.samus;
		}
		else if (pTwoSelection == CharacterSelection.kirby)
		{
			pTwoCharacterName = "KIRBY";
			pTwoPortrait = characterPortraits[3];
			pTwoStock = stockImages[3];
			characters[1] = CharacterSelection.kirby;
			colliderSizes[1] = new Vector3(1f, 1f, 1f);
		}
		else if (pTwoSelection == CharacterSelection.luigi)
		{
			pTwoCharacterName = "LUIGI";
			pTwoPortrait = characterPortraits[4];
			pTwoStock = stockImages[4];
			characters[1] = CharacterSelection.luigi;
		}
		else if (pTwoSelection == CharacterSelection.zelda)
		{
			pTwoCharacterName = "ZELDA";
			pTwoPortrait = characterPortraits[5];
			pTwoStock = stockImages[5];
			characters[1] = CharacterSelection.zelda;
		}
		else if (pTwoSelection == CharacterSelection.yoshi)
		{
			pTwoCharacterName = "YOSHI";
			pTwoPortrait = characterPortraits[6];
			pTwoStock = stockImages[6];
			characters[1] = CharacterSelection.yoshi;
		}
		else if (pTwoSelection == CharacterSelection.bowser)
		{
			pTwoCharacterName = "BOWSER";
			pTwoPortrait = characterPortraits[7];
			pTwoStock = stockImages[7];
			characters[1] = CharacterSelection.bowser;
		}
		else if (pTwoSelection == CharacterSelection.link)
		{
			pTwoCharacterName = "LINK";
			pTwoPortrait = characterPortraits[8];
			pTwoStock = stockImages[8];
			characters[1] = CharacterSelection.link;
			colliderSizes[1] = new Vector3(1f, 2.5f, 1f);
		}
		else if (pTwoSelection == CharacterSelection.zeroSuitSamus)
		{
			pTwoCharacterName = "ZERO SUIT SAMUS";
			pTwoPortrait = characterPortraits[9];
			pTwoStock = stockImages[9];
			characters[1] = CharacterSelection.zeroSuitSamus;
			colliderSizes[1] = new Vector3(1f, 3.5f, 1f);
		}

		//Player Three
		if (pThreeSelection == CharacterSelection.mario)
		{
			pThreeCharacterName = "MARIO";
			pThreePortrait = characterPortraits[0];
			pThreeStock = stockImages[0];
			characters[2] = CharacterSelection.mario;
			colliderSizes[2] = new Vector3(1f, 2.5f, 1f);
		}
		else if (pThreeSelection == CharacterSelection.donkeyKong)
		{
			pThreeCharacterName = "DONKEY KONG";
			pThreePortrait = characterPortraits[1];
			pThreeStock = stockImages[1];
			characters[2] = CharacterSelection.donkeyKong;
		}
		else if (pThreeSelection == CharacterSelection.samus)
		{
			pThreeCharacterName = "SAMUS";
			pThreePortrait = characterPortraits[2];
			pThreeStock = stockImages[2];
			characters[2] = CharacterSelection.samus;
		}
		else if (pThreeSelection == CharacterSelection.kirby)
		{
			pThreeCharacterName = "KIRBY";
			pThreePortrait = characterPortraits[3];
			pThreeStock = stockImages[3];
			characters[2] = CharacterSelection.kirby;
			colliderSizes[2] = new Vector3(1f, 1f, 1f);
		}
		else if (pThreeSelection == CharacterSelection.luigi)
		{
			pThreeCharacterName = "LUIGI";
			pThreePortrait = characterPortraits[4];
			pThreeStock = stockImages[4];
			characters[2] = CharacterSelection.luigi;
		}
		else if (pThreeSelection == CharacterSelection.zelda)
		{
			pThreeCharacterName = "ZELDA";
			pThreePortrait = characterPortraits[5];
			pThreeStock = stockImages[5];
			characters[2] = CharacterSelection.zelda;
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
			characters[2] = CharacterSelection.bowser;
		}
		else if (pThreeSelection == CharacterSelection.link)
		{
			pThreeCharacterName = "LINK";
			pThreePortrait = characterPortraits[8];
			pThreeStock = stockImages[8];
			characters[2] = CharacterSelection.link;
			colliderSizes[2] = new Vector3(1f, 2.5f, 1f);
		}
		else if (pOneSelection == CharacterSelection.zeroSuitSamus)
		{
			pThreeCharacterName = "ZERO SUIT SAMUS";
			pThreePortrait = characterPortraits[9];
			pThreeStock = stockImages[9];
			characters[2] = CharacterSelection.zeroSuitSamus;
			colliderSizes[2] = new Vector3(1f, 3.5f, 1f);
		}

		//Player Four
		if (pFourSelection == CharacterSelection.mario)
		{
			pFourCharacterName = "MARIO";
			pFourPortrait = characterPortraits[0];
			pFourStock = stockImages[0];
			characters[3] = CharacterSelection.mario;
			colliderSizes[3] = new Vector3(1f, 2.5f, 1f);
		}
		else if (pFourSelection == CharacterSelection.donkeyKong)
		{
			pFourCharacterName = "DONKEY KONG";
			pFourPortrait = characterPortraits[1];
			pFourStock = stockImages[1];
			characters[3] = CharacterSelection.donkeyKong;
		}
		else if (pFourSelection == CharacterSelection.samus)
		{
			pFourCharacterName = "SAMUS";
			pFourPortrait = characterPortraits[2];
			pFourStock = stockImages[2];
			characters[3] = CharacterSelection.samus;
		}
		else if (pFourSelection == CharacterSelection.kirby)
		{
			pFourCharacterName = "KIRBY";
			pFourPortrait = characterPortraits[3];
			pFourStock = stockImages[3];
			characters[3] = CharacterSelection.kirby;
			colliderSizes[3] = new Vector3(1f, 1f, 1f);
		}
		else if (pFourSelection == CharacterSelection.luigi)
		{
			pFourCharacterName = "LUIGI";
			pFourPortrait = characterPortraits[4];
			pFourStock = stockImages[4];
			characters[3] = CharacterSelection.luigi;
		}
		else if (pFourSelection == CharacterSelection.zelda)
		{
			pFourCharacterName = "ZELDA";
			pFourPortrait = characterPortraits[5];
			pFourStock = stockImages[5];
			characters[3] = CharacterSelection.zelda;
		}
		else if (pFourSelection == CharacterSelection.yoshi)
		{
			pFourCharacterName = "YOSHI";
			pFourPortrait = characterPortraits[6];
			pFourStock = stockImages[6];
			characters[3] = CharacterSelection.yoshi;
		}
		else if (pFourSelection == CharacterSelection.bowser)
		{
			pFourCharacterName = "BOWSER";
			pFourPortrait = characterPortraits[7];
			pFourStock = stockImages[7];
			characters[3] = CharacterSelection.bowser;
		}
		else if (pFourSelection == CharacterSelection.link)
		{
			pFourCharacterName = "LINK";
			pFourPortrait = characterPortraits[8];
			pFourStock = stockImages[8];
			characters[3] = CharacterSelection.link;
			colliderSizes[3] = new Vector3(1f, 2.5f, 1f);
		}
		else if (pOneSelection == CharacterSelection.zeroSuitSamus)
		{
			pFourCharacterName = "ZERO SUIT SAMUS";
			pFourPortrait = characterPortraits[9];
			pFourStock = stockImages[9];
			characters[3] = CharacterSelection.zeroSuitSamus;
			colliderSizes[3] = new Vector3(1f, 3.5f, 1f);
		}
	}
}

















