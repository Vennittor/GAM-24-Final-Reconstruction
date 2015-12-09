using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour 
{
	public int livesCount;

	public float itemSpawnDelay;

	public GameObject optionsDataHolder;

	public AudioSource buttonPushAudio;

	public Text dropRateText;
	public Text livesCountText;

	public List <ItemSelector.itemName> veryRare;
	public List <ItemSelector.itemName> rare;
	public List <ItemSelector.itemName> uncommon;
	public List <ItemSelector.itemName> common;

	//Item Text
	public Text hammerText;
	public Text smashBallText;
	public Text homeRunBatText;
	public Text mushroomText;
	public Text fanText;
	public Text laserGunText;
	public Text beamSwordText;
	public Text pokeBallText;
	public Text bo_ombText;
	public Text iceText;
	public Text metalText;
	public Text starText;
	public Text bunnyEarsText;
	public Text pillText;
	public Text shellText;
	public Text tomatoText;
	public Text fireFlowerText;
	public Text tripMineText;
	public Text bananaPeelText;
	public Text bumperText;

	//Item Rarity
	public enum ItemRarity {common,uncommon,rare,veryRare}

	public ItemRarity hammerRarity;
	public ItemRarity smashBallRarity;
	public ItemRarity homeRunBatRarity;
	public ItemRarity mushroomRarity;
	public ItemRarity fanRarity;
	public ItemRarity laserGunRarity;
	public ItemRarity beamSwordRarity;
	public ItemRarity pokeBallRarity;
	public ItemRarity bo_ombRarity;
	public ItemRarity iceRarity;
	public ItemRarity metalRarity;
	public ItemRarity starRarity;
	public ItemRarity bunnyEarsRarity;
	public ItemRarity pillRarity;
	public ItemRarity shellRarity;
	public ItemRarity tomatoRarity;
	public ItemRarity fireFolwerRarity;
	public ItemRarity tripMineRarity;
	public ItemRarity bananaPeelRarity;
	public ItemRarity bumperRarity;


	// Use this for initialization
	void Start () 
	{
		optionsDataHolder = GameObject.Find ("DataHolder");
		optionsDataHolder.GetComponent<DataHolder> ().itemSpawnDelay = itemSpawnDelay;
		optionsDataHolder.GetComponent<DataHolder> ().livesCount = livesCount;

		SetItemRarity ();
		SetDataHolderRarity ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void Back ()
	{
		if (optionsDataHolder.GetComponent<DataHolder>().characterMenuLoad == false)
		{
			Application.LoadLevel (1);
		}
		else
		{
			optionsDataHolder.GetComponent<DataHolder>().characterMenuLoad = false;
			Application.LoadLevel (3);
		}
	}

	//Number of Lives
	public void IncreseLives ()
	{
		if (livesCount < 3) 
		{
			livesCount ++;
			optionsDataHolder.GetComponent<DataHolder> ().livesCount = livesCount;
		}
		if (livesCount == 1)
		{
			livesCountText.text = "1";
		}
		else if (livesCount == 2)
		{
			livesCountText.text = "2";
		}
		else if (livesCount == 3)
		{
			livesCountText.text = "3";
		}
	}

	public void DecreaseLives ()
	{
		if (livesCount > 1) 
		{
			livesCount --;
			optionsDataHolder.GetComponent<DataHolder> ().livesCount = livesCount;
		}
		if (livesCount == 1)
		{
			livesCountText.text = "1";
		}
		else if (livesCount == 2)
		{
			livesCountText.text = "2";
		}
		else if (livesCount == 3)
		{
			livesCountText.text = "3";
		}
	}

	//Item Spawn
	public void DecreaseSpawnRate ()
	{
		if (itemSpawnDelay == 0.5f)
		{
			itemSpawnDelay = 1.5f;
			dropRateText.text = "HIGH";
		}
		else if (itemSpawnDelay == 1.5f)
		{
			itemSpawnDelay = 3;
			dropRateText.text = "MEDIUM";
		}
		else if (itemSpawnDelay == 3f)
		{
			itemSpawnDelay = 4.5f;
			dropRateText.text = "LOW";
		}
		else if (itemSpawnDelay == 4.5f)
		{
			itemSpawnDelay = 5;
			dropRateText.text = "VERY LOW";
		}

		optionsDataHolder.GetComponent<DataHolder> ().itemSpawnDelay = itemSpawnDelay;
	}

	public void IncreaseSpawnRate ()
	{
		if (itemSpawnDelay == 5)
		{
			itemSpawnDelay = 4.5f;
			dropRateText.text = "LOW";
		}
		else if (itemSpawnDelay == 4.5)
		{
			itemSpawnDelay = 3;
			dropRateText.text = "MEDIUM";
		}
		else if (itemSpawnDelay == 3f)
		{
			itemSpawnDelay = 1.5f;
			dropRateText.text = "HIGH";
		}
		else if (itemSpawnDelay == 1.5)
		{
			itemSpawnDelay = 0.5f;
			dropRateText.text = "VERY HIGH";
		}
		
		optionsDataHolder.GetComponent<DataHolder> ().itemSpawnDelay = itemSpawnDelay;
	}

	//Individual Item Rarity
	void SetDataHolderRarity ()
	{
		optionsDataHolder.GetComponent<DataHolder> ().veryRare = veryRare;
		optionsDataHolder.GetComponent<DataHolder> ().rare = rare;
		optionsDataHolder.GetComponent<DataHolder> ().uncommon = uncommon;
		optionsDataHolder.GetComponent<DataHolder> ().common = common;
	}

	void SetItemRarity ()
	{
		//Very Rare
		hammerRarity = ItemRarity.veryRare;
		smashBallRarity = ItemRarity.veryRare;
		//Rare
		homeRunBatRarity = ItemRarity.rare;
		mushroomRarity = ItemRarity.rare;
		fanRarity = ItemRarity.rare;
		laserGunRarity = ItemRarity.rare;
		beamSwordRarity = ItemRarity.rare;
		//Uncommon
		pokeBallRarity = ItemRarity.uncommon;
		bo_ombRarity = ItemRarity.uncommon;
		iceRarity = ItemRarity.uncommon;
		metalRarity = ItemRarity.uncommon;
		starRarity = ItemRarity.uncommon;
		bunnyEarsRarity = ItemRarity.uncommon;
		//Common
		pillRarity = ItemRarity.common;
		shellRarity = ItemRarity.common;
		tomatoRarity = ItemRarity.common;
		fireFolwerRarity = ItemRarity.common;
		tripMineRarity = ItemRarity.common;
		bananaPeelRarity = ItemRarity.common;
		bumperRarity = ItemRarity.common;
	}

	//Hammer
	public void HammerRarityIncrease ()
	{
		if (hammerRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.HAMMER);
			uncommon.Remove (ItemSelector.itemName.HAMMER);
			rare.Remove (ItemSelector.itemName.HAMMER);
			veryRare.Remove (ItemSelector.itemName.HAMMER);
			uncommon.Add (ItemSelector.itemName.HAMMER);
			hammerRarity = ItemRarity.uncommon;
			hammerText.text = "HIGH";
		}
		else if (hammerRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.HAMMER);
			uncommon.Remove (ItemSelector.itemName.HAMMER);
			rare.Remove (ItemSelector.itemName.HAMMER);
			veryRare.Remove (ItemSelector.itemName.HAMMER);
			rare.Add (ItemSelector.itemName.HAMMER);
			hammerRarity = ItemRarity.rare;
			hammerText.text = "MEDIUM";
		}
		else if (hammerRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.HAMMER);
			uncommon.Remove (ItemSelector.itemName.HAMMER);
			rare.Remove (ItemSelector.itemName.HAMMER);
			veryRare.Remove (ItemSelector.itemName.HAMMER);
			veryRare.Add (ItemSelector.itemName.HAMMER);
			hammerRarity = ItemRarity.veryRare;
			hammerText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void HammerRarityDecrease ()
	{
		if (hammerRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.HAMMER);
			uncommon.Remove (ItemSelector.itemName.HAMMER);
			rare.Remove (ItemSelector.itemName.HAMMER);
			veryRare.Remove (ItemSelector.itemName.HAMMER);
			common.Add (ItemSelector.itemName.HAMMER);
			hammerRarity = ItemRarity.common;
			hammerText.text = "VERY HIGH";
		}
		else if (hammerRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.HAMMER);
			uncommon.Remove (ItemSelector.itemName.HAMMER);
			rare.Remove (ItemSelector.itemName.HAMMER);
			veryRare.Remove (ItemSelector.itemName.HAMMER);
			uncommon.Add (ItemSelector.itemName.HAMMER);
			hammerRarity = ItemRarity.uncommon;
			hammerText.text = "HIGH";
		}
		else if (hammerRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.HAMMER);
			uncommon.Remove (ItemSelector.itemName.HAMMER);
			rare.Remove (ItemSelector.itemName.HAMMER);
			veryRare.Remove (ItemSelector.itemName.HAMMER);
			rare.Add (ItemSelector.itemName.HAMMER);
			hammerRarity = ItemRarity.rare;
			hammerText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Smash Ball
	public void SmashBallRarityIncrease ()
	{
		if (smashBallRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.SMASHBALL);
			uncommon.Remove (ItemSelector.itemName.SMASHBALL);
			rare.Remove (ItemSelector.itemName.SMASHBALL);
			veryRare.Remove (ItemSelector.itemName.SMASHBALL);
			uncommon.Add (ItemSelector.itemName.SMASHBALL);
			smashBallRarity = ItemRarity.uncommon;
			smashBallText.text = "HIGH";
		}
		else if (smashBallRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.SMASHBALL);
			uncommon.Remove (ItemSelector.itemName.SMASHBALL);
			rare.Remove (ItemSelector.itemName.SMASHBALL);
			veryRare.Remove (ItemSelector.itemName.SMASHBALL);
			rare.Add (ItemSelector.itemName.SMASHBALL);
			smashBallRarity = ItemRarity.rare;
			smashBallText.text = "MEDIUM";
		}
		else if (smashBallRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.SMASHBALL);
			uncommon.Remove (ItemSelector.itemName.SMASHBALL);
			rare.Remove (ItemSelector.itemName.SMASHBALL);
			veryRare.Remove (ItemSelector.itemName.SMASHBALL);
			veryRare.Add (ItemSelector.itemName.SMASHBALL);
			smashBallRarity = ItemRarity.veryRare;
			smashBallText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void SmashBallRarityDecrease ()
	{
		if (smashBallRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.SMASHBALL);
			uncommon.Remove (ItemSelector.itemName.SMASHBALL);
			rare.Remove (ItemSelector.itemName.SMASHBALL);
			veryRare.Remove (ItemSelector.itemName.SMASHBALL);
			common.Add (ItemSelector.itemName.SMASHBALL);
			smashBallRarity = ItemRarity.common;
			smashBallText.text = "VERY HIGH";
		}
		else if (smashBallRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.SMASHBALL);
			uncommon.Remove (ItemSelector.itemName.SMASHBALL);
			rare.Remove (ItemSelector.itemName.SMASHBALL);
			veryRare.Remove (ItemSelector.itemName.SMASHBALL);
			uncommon.Add (ItemSelector.itemName.SMASHBALL);
			smashBallRarity = ItemRarity.uncommon;
			smashBallText.text = "HIGH";
		}
		else if (smashBallRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.SMASHBALL);
			uncommon.Remove (ItemSelector.itemName.SMASHBALL);
			rare.Remove (ItemSelector.itemName.SMASHBALL);
			veryRare.Remove (ItemSelector.itemName.SMASHBALL);
			rare.Add (ItemSelector.itemName.SMASHBALL);
			smashBallRarity = ItemRarity.rare;
			smashBallText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Home Run Bat
	public void HomeRunBatRarityIncrease ()
	{
		if (homeRunBatRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.HOMERUNBAT);
			uncommon.Remove (ItemSelector.itemName.HOMERUNBAT);
			rare.Remove (ItemSelector.itemName.HOMERUNBAT);
			veryRare.Remove (ItemSelector.itemName.HOMERUNBAT);
			uncommon.Add (ItemSelector.itemName.HOMERUNBAT);
			homeRunBatRarity = ItemRarity.uncommon;
			homeRunBatText.text = "HIGH";
		}
		else if (homeRunBatRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.HOMERUNBAT);
			uncommon.Remove (ItemSelector.itemName.HOMERUNBAT);
			rare.Remove (ItemSelector.itemName.HOMERUNBAT);
			veryRare.Remove (ItemSelector.itemName.HOMERUNBAT);
			rare.Add (ItemSelector.itemName.HOMERUNBAT);
			homeRunBatRarity = ItemRarity.rare;
			homeRunBatText.text = "MEDIUM";
		}
		else if (homeRunBatRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.HOMERUNBAT);
			uncommon.Remove (ItemSelector.itemName.HOMERUNBAT);
			rare.Remove (ItemSelector.itemName.HOMERUNBAT);
			veryRare.Remove (ItemSelector.itemName.HOMERUNBAT);
			veryRare.Add (ItemSelector.itemName.HOMERUNBAT);
			homeRunBatRarity = ItemRarity.veryRare;
			homeRunBatText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void HomeRunBatRarityDecrease ()
	{
		if (homeRunBatRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.HOMERUNBAT);
			uncommon.Remove (ItemSelector.itemName.HOMERUNBAT);
			rare.Remove (ItemSelector.itemName.HOMERUNBAT);
			veryRare.Remove (ItemSelector.itemName.HOMERUNBAT);
			common.Add (ItemSelector.itemName.HOMERUNBAT);
			homeRunBatRarity = ItemRarity.common;
			homeRunBatText.text = "VERY HIGH";
		}
		else if (homeRunBatRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.HOMERUNBAT);
			uncommon.Remove (ItemSelector.itemName.HOMERUNBAT);
			rare.Remove (ItemSelector.itemName.HOMERUNBAT);
			veryRare.Remove (ItemSelector.itemName.HOMERUNBAT);
			uncommon.Add (ItemSelector.itemName.HOMERUNBAT);
			homeRunBatRarity = ItemRarity.uncommon;
			homeRunBatText.text = "HIGH";
		}
		else if (smashBallRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.HOMERUNBAT);
			uncommon.Remove (ItemSelector.itemName.HOMERUNBAT);
			rare.Remove (ItemSelector.itemName.HOMERUNBAT);
			veryRare.Remove (ItemSelector.itemName.HOMERUNBAT);
			rare.Add (ItemSelector.itemName.HOMERUNBAT);
			homeRunBatRarity = ItemRarity.rare;
			homeRunBatText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Mushroom
	public void MushroomRarityIncrease ()
	{
		if (mushroomRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.MUSHROOM);
			uncommon.Remove (ItemSelector.itemName.MUSHROOM);
			rare.Remove (ItemSelector.itemName.MUSHROOM);
			veryRare.Remove (ItemSelector.itemName.MUSHROOM);
			uncommon.Add (ItemSelector.itemName.MUSHROOM);
			mushroomRarity = ItemRarity.uncommon;
			mushroomText.text = "HIGH";
		}
		else if (mushroomRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.MUSHROOM);
			uncommon.Remove (ItemSelector.itemName.MUSHROOM);
			rare.Remove (ItemSelector.itemName.MUSHROOM);
			veryRare.Remove (ItemSelector.itemName.MUSHROOM);
			rare.Add (ItemSelector.itemName.MUSHROOM);
			mushroomRarity = ItemRarity.rare;
			mushroomText.text = "MEDIUM";
		}
		else if (mushroomRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.MUSHROOM);
			uncommon.Remove (ItemSelector.itemName.MUSHROOM);
			rare.Remove (ItemSelector.itemName.MUSHROOM);
			veryRare.Remove (ItemSelector.itemName.MUSHROOM);
			veryRare.Add (ItemSelector.itemName.MUSHROOM);
			mushroomRarity = ItemRarity.veryRare;
			mushroomText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void MushroomRarityDecrease ()
	{
		if (mushroomRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.MUSHROOM);
			uncommon.Remove (ItemSelector.itemName.MUSHROOM);
			rare.Remove (ItemSelector.itemName.MUSHROOM);
			veryRare.Remove (ItemSelector.itemName.MUSHROOM);
			common.Add (ItemSelector.itemName.MUSHROOM);
			mushroomRarity = ItemRarity.common;
			mushroomText.text = "VERY HIGH";
		}
		else if (mushroomRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.MUSHROOM);
			uncommon.Remove (ItemSelector.itemName.MUSHROOM);
			rare.Remove (ItemSelector.itemName.MUSHROOM);
			veryRare.Remove (ItemSelector.itemName.MUSHROOM);
			uncommon.Add (ItemSelector.itemName.MUSHROOM);
			mushroomRarity = ItemRarity.uncommon;
			mushroomText.text = "HIGH";
		}
		else if (mushroomRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.MUSHROOM);
			uncommon.Remove (ItemSelector.itemName.MUSHROOM);
			rare.Remove (ItemSelector.itemName.MUSHROOM);
			veryRare.Remove (ItemSelector.itemName.MUSHROOM);
			rare.Add (ItemSelector.itemName.MUSHROOM);
			mushroomRarity = ItemRarity.rare;
			mushroomText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Fan
	public void FanRarityIncrease ()
	{
		if (fanRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.FAN);
			uncommon.Remove (ItemSelector.itemName.FAN);
			rare.Remove (ItemSelector.itemName.FAN);
			veryRare.Remove (ItemSelector.itemName.FAN);
			uncommon.Add (ItemSelector.itemName.FAN);
			fanRarity = ItemRarity.uncommon;
			fanText.text = "HIGH";
		}
		else if (fanRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.FAN);
			uncommon.Remove (ItemSelector.itemName.FAN);
			rare.Remove (ItemSelector.itemName.FAN);
			veryRare.Remove (ItemSelector.itemName.FAN);
			rare.Add (ItemSelector.itemName.FAN);
			fanRarity = ItemRarity.rare;
			fanText.text = "MEDIUM";
		}
		else if (fanRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.FAN);
			uncommon.Remove (ItemSelector.itemName.FAN);
			rare.Remove (ItemSelector.itemName.FAN);
			veryRare.Remove (ItemSelector.itemName.FAN);
			veryRare.Add (ItemSelector.itemName.FAN);
			fanRarity = ItemRarity.veryRare;
			fanText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void FanRarityDecrease ()
	{
		if (fanRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.FAN);
			uncommon.Remove (ItemSelector.itemName.FAN);
			rare.Remove (ItemSelector.itemName.FAN);
			veryRare.Remove (ItemSelector.itemName.FAN);
			common.Add (ItemSelector.itemName.FAN);
			fanRarity = ItemRarity.common;
			fanText.text = "VERY HIGH";
		}
		else if (fanRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.FAN);
			uncommon.Remove (ItemSelector.itemName.FAN);
			rare.Remove (ItemSelector.itemName.FAN);
			veryRare.Remove (ItemSelector.itemName.FAN);
			uncommon.Add (ItemSelector.itemName.FAN);
			fanRarity = ItemRarity.uncommon;
			fanText.text = "HIGH";
		}
		else if (fanRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.FAN);
			uncommon.Remove (ItemSelector.itemName.FAN);
			rare.Remove (ItemSelector.itemName.FAN);
			veryRare.Remove (ItemSelector.itemName.FAN);
			rare.Add (ItemSelector.itemName.FAN);
			fanRarity = ItemRarity.rare;
			fanText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Laser Gun
	public void LaserGunRarityIncrease ()
	{
		if (laserGunRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.LASERGUN);
			uncommon.Remove (ItemSelector.itemName.LASERGUN);
			rare.Remove (ItemSelector.itemName.LASERGUN);
			veryRare.Remove (ItemSelector.itemName.LASERGUN);
			uncommon.Add (ItemSelector.itemName.LASERGUN);
			laserGunRarity = ItemRarity.uncommon;
			laserGunText.text = "HIGH";
		}
		else if (laserGunRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.LASERGUN);
			uncommon.Remove (ItemSelector.itemName.LASERGUN);
			rare.Remove (ItemSelector.itemName.LASERGUN);
			veryRare.Remove (ItemSelector.itemName.LASERGUN);
			rare.Add (ItemSelector.itemName.LASERGUN);
			laserGunRarity = ItemRarity.rare;
			laserGunText.text = "MEDIUM";
		}
		else if (laserGunRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.LASERGUN);
			uncommon.Remove (ItemSelector.itemName.LASERGUN);
			rare.Remove (ItemSelector.itemName.LASERGUN);
			veryRare.Remove (ItemSelector.itemName.LASERGUN);
			veryRare.Add (ItemSelector.itemName.LASERGUN);
			laserGunRarity = ItemRarity.veryRare;
			laserGunText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void LaserGunRarityDecrease ()
	{
		if (laserGunRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.LASERGUN);
			uncommon.Remove (ItemSelector.itemName.LASERGUN);
			rare.Remove (ItemSelector.itemName.LASERGUN);
			veryRare.Remove (ItemSelector.itemName.LASERGUN);
			common.Add (ItemSelector.itemName.LASERGUN);
			laserGunRarity = ItemRarity.common;
			laserGunText.text = "VERY HIGH";
		}
		else if (laserGunRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.LASERGUN);
			uncommon.Remove (ItemSelector.itemName.LASERGUN);
			rare.Remove (ItemSelector.itemName.LASERGUN);
			veryRare.Remove (ItemSelector.itemName.LASERGUN);
			uncommon.Add (ItemSelector.itemName.LASERGUN);
			laserGunRarity = ItemRarity.uncommon;
			laserGunText.text = "HIGH";
		}
		else if (laserGunRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.LASERGUN);
			uncommon.Remove (ItemSelector.itemName.LASERGUN);
			rare.Remove (ItemSelector.itemName.LASERGUN);
			veryRare.Remove (ItemSelector.itemName.LASERGUN);
			rare.Add (ItemSelector.itemName.LASERGUN);
			laserGunRarity = ItemRarity.rare;
			laserGunText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Beam Sword
	public void BeamSwordRarityIncrease ()
	{
		if (beamSwordRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.BEAMSWORD);
			uncommon.Remove (ItemSelector.itemName.BEAMSWORD);
			rare.Remove (ItemSelector.itemName.BEAMSWORD);
			veryRare.Remove (ItemSelector.itemName.BEAMSWORD);
			uncommon.Add (ItemSelector.itemName.BEAMSWORD);
			beamSwordRarity = ItemRarity.uncommon;
			beamSwordText.text = "HIGH";
		}
		else if (beamSwordRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.BEAMSWORD);
			uncommon.Remove (ItemSelector.itemName.BEAMSWORD);
			rare.Remove (ItemSelector.itemName.BEAMSWORD);
			veryRare.Remove (ItemSelector.itemName.BEAMSWORD);
			rare.Add (ItemSelector.itemName.BEAMSWORD);
			beamSwordRarity = ItemRarity.rare;
			beamSwordText.text = "MEDIUM";
		}
		else if (beamSwordRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.BEAMSWORD);
			uncommon.Remove (ItemSelector.itemName.BEAMSWORD);
			rare.Remove (ItemSelector.itemName.BEAMSWORD);
			veryRare.Remove (ItemSelector.itemName.BEAMSWORD);
			veryRare.Add (ItemSelector.itemName.BEAMSWORD);
			beamSwordRarity = ItemRarity.veryRare;
			beamSwordText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void BeamSwordRarityDecrease ()
	{
		if (beamSwordRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.BEAMSWORD);
			uncommon.Remove (ItemSelector.itemName.BEAMSWORD);
			rare.Remove (ItemSelector.itemName.BEAMSWORD);
			veryRare.Remove (ItemSelector.itemName.BEAMSWORD);
			common.Add (ItemSelector.itemName.BEAMSWORD);
			beamSwordRarity = ItemRarity.common;
			beamSwordText.text = "VERY HIGH";
		}
		else if (beamSwordRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.BEAMSWORD);
			uncommon.Remove (ItemSelector.itemName.BEAMSWORD);
			rare.Remove (ItemSelector.itemName.BEAMSWORD);
			veryRare.Remove (ItemSelector.itemName.BEAMSWORD);
			uncommon.Add (ItemSelector.itemName.BEAMSWORD);
			beamSwordRarity = ItemRarity.uncommon;
			beamSwordText.text = "HIGH";
		}
		else if (beamSwordRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.BEAMSWORD);
			uncommon.Remove (ItemSelector.itemName.BEAMSWORD);
			rare.Remove (ItemSelector.itemName.BEAMSWORD);
			veryRare.Remove (ItemSelector.itemName.BEAMSWORD);
			rare.Add (ItemSelector.itemName.BEAMSWORD);
			beamSwordRarity = ItemRarity.rare;
			beamSwordText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Poke Ball
	public void PokeBallRarityIncrease ()
	{
		if (pokeBallRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.POKEBALL);
			uncommon.Remove (ItemSelector.itemName.POKEBALL);
			rare.Remove (ItemSelector.itemName.POKEBALL);
			veryRare.Remove (ItemSelector.itemName.POKEBALL);
			uncommon.Add (ItemSelector.itemName.POKEBALL);
			pokeBallRarity = ItemRarity.uncommon;
			pokeBallText.text = "HIGH";
		}
		else if (pokeBallRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.POKEBALL);
			uncommon.Remove (ItemSelector.itemName.POKEBALL);
			rare.Remove (ItemSelector.itemName.POKEBALL);
			veryRare.Remove (ItemSelector.itemName.POKEBALL);
			rare.Add (ItemSelector.itemName.POKEBALL);
			pokeBallRarity = ItemRarity.rare;
			pokeBallText.text = "MEDIUM";
		}
		else if (pokeBallRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.POKEBALL);
			uncommon.Remove (ItemSelector.itemName.POKEBALL);
			rare.Remove (ItemSelector.itemName.POKEBALL);
			veryRare.Remove (ItemSelector.itemName.POKEBALL);
			veryRare.Add (ItemSelector.itemName.POKEBALL);
			pokeBallRarity = ItemRarity.veryRare;
			pokeBallText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void PokeBallRarityDecrease ()
	{
		if (pokeBallRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.POKEBALL);
			uncommon.Remove (ItemSelector.itemName.POKEBALL);
			rare.Remove (ItemSelector.itemName.POKEBALL);
			veryRare.Remove (ItemSelector.itemName.POKEBALL);
			common.Add (ItemSelector.itemName.POKEBALL);
			pokeBallRarity = ItemRarity.common;
			pokeBallText.text = "VERY HIGH";
		}
		else if (pokeBallRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.POKEBALL);
			uncommon.Remove (ItemSelector.itemName.POKEBALL);
			rare.Remove (ItemSelector.itemName.POKEBALL);
			veryRare.Remove (ItemSelector.itemName.POKEBALL);
			uncommon.Add (ItemSelector.itemName.POKEBALL);
			pokeBallRarity = ItemRarity.uncommon;
			pokeBallText.text = "HIGH";
		}
		else if (pokeBallRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.POKEBALL);
			uncommon.Remove (ItemSelector.itemName.POKEBALL);
			rare.Remove (ItemSelector.itemName.POKEBALL);
			veryRare.Remove (ItemSelector.itemName.POKEBALL);
			rare.Add (ItemSelector.itemName.POKEBALL);
			pokeBallRarity = ItemRarity.rare;
			pokeBallText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Bo_omb
	public void BombRarityIncrease ()
	{
		if (bo_ombRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.BO_OMB);
			uncommon.Remove (ItemSelector.itemName.BO_OMB);
			rare.Remove (ItemSelector.itemName.BO_OMB);
			veryRare.Remove (ItemSelector.itemName.BO_OMB);
			uncommon.Add (ItemSelector.itemName.BO_OMB);
			bo_ombRarity = ItemRarity.uncommon;
			bo_ombText.text = "HIGH";
		}
		else if (bo_ombRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.BO_OMB);
			uncommon.Remove (ItemSelector.itemName.BO_OMB);
			rare.Remove (ItemSelector.itemName.BO_OMB);
			veryRare.Remove (ItemSelector.itemName.BO_OMB);
			rare.Add (ItemSelector.itemName.BO_OMB);
			bo_ombRarity = ItemRarity.rare;
			bo_ombText.text = "MEDIUM";
		}
		else if (bo_ombRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.BO_OMB);
			uncommon.Remove (ItemSelector.itemName.BO_OMB);
			rare.Remove (ItemSelector.itemName.BO_OMB);
			veryRare.Remove (ItemSelector.itemName.BO_OMB);
			veryRare.Add (ItemSelector.itemName.BO_OMB);
			bo_ombRarity = ItemRarity.veryRare;
			bo_ombText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void BombRarityDecrease ()
	{
		if (bo_ombRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.BO_OMB);
			uncommon.Remove (ItemSelector.itemName.BO_OMB);
			rare.Remove (ItemSelector.itemName.BO_OMB);
			veryRare.Remove (ItemSelector.itemName.BO_OMB);
			common.Add (ItemSelector.itemName.BO_OMB);
			bo_ombRarity = ItemRarity.common;
			bo_ombText.text = "VERY HIGH";
		}
		else if (bo_ombRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.BO_OMB);
			uncommon.Remove (ItemSelector.itemName.BO_OMB);
			rare.Remove (ItemSelector.itemName.BO_OMB);
			veryRare.Remove (ItemSelector.itemName.BO_OMB);
			uncommon.Add (ItemSelector.itemName.BO_OMB);
			bo_ombRarity = ItemRarity.uncommon;
			bo_ombText.text = "HIGH";
		}
		else if (bo_ombRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.BO_OMB);
			uncommon.Remove (ItemSelector.itemName.BO_OMB);
			rare.Remove (ItemSelector.itemName.BO_OMB);
			veryRare.Remove (ItemSelector.itemName.BO_OMB);
			rare.Add (ItemSelector.itemName.BO_OMB);
			bo_ombRarity = ItemRarity.rare;
			bo_ombText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Freezie
	public void FreezieRarityIncrease ()
	{
		if (iceRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.ICE);
			uncommon.Remove (ItemSelector.itemName.ICE);
			rare.Remove (ItemSelector.itemName.ICE);
			veryRare.Remove (ItemSelector.itemName.ICE);
			uncommon.Add (ItemSelector.itemName.ICE);
			iceRarity = ItemRarity.uncommon;
			iceText.text = "HIGH";
		}
		else if (iceRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.ICE);
			uncommon.Remove (ItemSelector.itemName.ICE);
			rare.Remove (ItemSelector.itemName.ICE);
			veryRare.Remove (ItemSelector.itemName.ICE);
			rare.Add (ItemSelector.itemName.ICE);
			iceRarity = ItemRarity.rare;
			iceText.text = "MEDIUM";
		}
		else if (iceRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.ICE);
			uncommon.Remove (ItemSelector.itemName.ICE);
			rare.Remove (ItemSelector.itemName.ICE);
			veryRare.Remove (ItemSelector.itemName.ICE);
			veryRare.Add (ItemSelector.itemName.ICE);
			iceRarity = ItemRarity.veryRare;
			iceText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void FreezieRarityDecrease ()
	{
		if (iceRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.ICE);
			uncommon.Remove (ItemSelector.itemName.ICE);
			rare.Remove (ItemSelector.itemName.ICE);
			veryRare.Remove (ItemSelector.itemName.ICE);
			common.Add (ItemSelector.itemName.ICE);
			iceRarity = ItemRarity.common;
			iceText.text = "VERY HIGH";
		}
		else if (iceRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.ICE);
			uncommon.Remove (ItemSelector.itemName.ICE);
			rare.Remove (ItemSelector.itemName.ICE);
			veryRare.Remove (ItemSelector.itemName.ICE);
			uncommon.Add (ItemSelector.itemName.ICE);
			iceRarity = ItemRarity.uncommon;
			iceText.text = "HIGH";
		}
		else if (iceRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.ICE);
			uncommon.Remove (ItemSelector.itemName.ICE);
			rare.Remove (ItemSelector.itemName.ICE);
			veryRare.Remove (ItemSelector.itemName.ICE);
			rare.Add (ItemSelector.itemName.ICE);
			iceRarity = ItemRarity.rare;
			iceText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//MetalBox
	public void MetalBoxRarityIncrease ()
	{
		if (metalRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.METAL);
			uncommon.Remove (ItemSelector.itemName.METAL);
			rare.Remove (ItemSelector.itemName.METAL);
			veryRare.Remove (ItemSelector.itemName.METAL);
			uncommon.Add (ItemSelector.itemName.METAL);
			metalRarity = ItemRarity.uncommon;
			metalText.text = "HIGH";
		}
		else if (metalRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.METAL);
			uncommon.Remove (ItemSelector.itemName.METAL);
			rare.Remove (ItemSelector.itemName.METAL);
			veryRare.Remove (ItemSelector.itemName.METAL);
			rare.Add (ItemSelector.itemName.METAL);
			metalRarity = ItemRarity.rare;
			metalText.text = "MEDIUM";
		}
		else if (metalRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.METAL);
			uncommon.Remove (ItemSelector.itemName.METAL);
			rare.Remove (ItemSelector.itemName.METAL);
			veryRare.Remove (ItemSelector.itemName.METAL);
			veryRare.Add (ItemSelector.itemName.METAL);
			metalRarity = ItemRarity.veryRare;
			metalText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void MetalBoxRarityDecrease ()
	{
		if (metalRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.METAL);
			uncommon.Remove (ItemSelector.itemName.METAL);
			rare.Remove (ItemSelector.itemName.METAL);
			veryRare.Remove (ItemSelector.itemName.METAL);
			common.Add (ItemSelector.itemName.METAL);
			metalRarity = ItemRarity.common;
			metalText.text = "VERY HIGH";
		}
		else if (metalRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.METAL);
			uncommon.Remove (ItemSelector.itemName.METAL);
			rare.Remove (ItemSelector.itemName.METAL);
			veryRare.Remove (ItemSelector.itemName.METAL);
			uncommon.Add (ItemSelector.itemName.METAL);
			metalRarity = ItemRarity.uncommon;
			metalText.text = "HIGH";
		}
		else if (metalRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.METAL);
			uncommon.Remove (ItemSelector.itemName.METAL);
			rare.Remove (ItemSelector.itemName.METAL);
			veryRare.Remove (ItemSelector.itemName.METAL);
			rare.Add (ItemSelector.itemName.METAL);
			metalRarity = ItemRarity.rare;
			metalText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Star
	public void StarRarityIncrease ()
	{
		if (starRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.STAR);
			uncommon.Remove (ItemSelector.itemName.STAR);
			rare.Remove (ItemSelector.itemName.STAR);
			veryRare.Remove (ItemSelector.itemName.STAR);
			uncommon.Add (ItemSelector.itemName.STAR);
			starRarity = ItemRarity.uncommon;
			starText.text = "HIGH";
		}
		else if (starRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.STAR);
			uncommon.Remove (ItemSelector.itemName.STAR);
			rare.Remove (ItemSelector.itemName.STAR);
			veryRare.Remove (ItemSelector.itemName.STAR);
			rare.Add (ItemSelector.itemName.STAR);
			starRarity = ItemRarity.rare;
			starText.text = "MEDIUM";
		}
		else if (starRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.STAR);
			uncommon.Remove (ItemSelector.itemName.STAR);
			rare.Remove (ItemSelector.itemName.STAR);
			veryRare.Remove (ItemSelector.itemName.STAR);
			veryRare.Add (ItemSelector.itemName.STAR);
			starRarity = ItemRarity.veryRare;
			starText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void StarRarityDecrease ()
	{
		if (starRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.STAR);
			uncommon.Remove (ItemSelector.itemName.STAR);
			rare.Remove (ItemSelector.itemName.STAR);
			veryRare.Remove (ItemSelector.itemName.STAR);
			common.Add (ItemSelector.itemName.STAR);
			starRarity = ItemRarity.common;
			starText.text = "VERY HIGH";
		}
		else if (starRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.STAR);
			uncommon.Remove (ItemSelector.itemName.STAR);
			rare.Remove (ItemSelector.itemName.STAR);
			veryRare.Remove (ItemSelector.itemName.STAR);
			uncommon.Add (ItemSelector.itemName.STAR);
			starRarity = ItemRarity.uncommon;
			starText.text = "HIGH";
		}
		else if (starRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.STAR);
			uncommon.Remove (ItemSelector.itemName.STAR);
			rare.Remove (ItemSelector.itemName.STAR);
			veryRare.Remove (ItemSelector.itemName.STAR);
			rare.Add (ItemSelector.itemName.STAR);
			starRarity = ItemRarity.rare;
			starText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//BunnyEars
	public void BunnyEarsRarityIncrease ()
	{
		if (bunnyEarsRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.BUNNYEARS);
			uncommon.Remove (ItemSelector.itemName.BUNNYEARS);
			rare.Remove (ItemSelector.itemName.BUNNYEARS);
			veryRare.Remove (ItemSelector.itemName.BUNNYEARS);
			uncommon.Add (ItemSelector.itemName.BUNNYEARS);
			bunnyEarsRarity = ItemRarity.uncommon;
			bunnyEarsText.text = "HIGH";
		}
		else if (bunnyEarsRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.BUNNYEARS);
			uncommon.Remove (ItemSelector.itemName.BUNNYEARS);
			rare.Remove (ItemSelector.itemName.BUNNYEARS);
			veryRare.Remove (ItemSelector.itemName.BUNNYEARS);
			rare.Add (ItemSelector.itemName.BUNNYEARS);
			bunnyEarsRarity = ItemRarity.rare;
			bunnyEarsText.text = "MEDIUM";
		}
		else if (bunnyEarsRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.BUNNYEARS);
			uncommon.Remove (ItemSelector.itemName.BUNNYEARS);
			rare.Remove (ItemSelector.itemName.BUNNYEARS);
			veryRare.Remove (ItemSelector.itemName.BUNNYEARS);
			veryRare.Add (ItemSelector.itemName.BUNNYEARS);
			bunnyEarsRarity = ItemRarity.veryRare;
			bunnyEarsText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void BunnyEarsRarityDecrease ()
	{
		if (bunnyEarsRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.BUNNYEARS);
			uncommon.Remove (ItemSelector.itemName.BUNNYEARS);
			rare.Remove (ItemSelector.itemName.BUNNYEARS);
			veryRare.Remove (ItemSelector.itemName.BUNNYEARS);
			common.Add (ItemSelector.itemName.BUNNYEARS);
			bunnyEarsRarity = ItemRarity.common;
			bunnyEarsText.text = "VERY HIGH";
		}
		else if (bunnyEarsRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.BUNNYEARS);
			uncommon.Remove (ItemSelector.itemName.BUNNYEARS);
			rare.Remove (ItemSelector.itemName.BUNNYEARS);
			veryRare.Remove (ItemSelector.itemName.BUNNYEARS);
			uncommon.Add (ItemSelector.itemName.BUNNYEARS);
			bunnyEarsRarity = ItemRarity.uncommon;
			bunnyEarsText.text = "HIGH";
		}
		else if (bunnyEarsRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.BUNNYEARS);
			uncommon.Remove (ItemSelector.itemName.BUNNYEARS);
			rare.Remove (ItemSelector.itemName.BUNNYEARS);
			veryRare.Remove (ItemSelector.itemName.BUNNYEARS);
			rare.Add (ItemSelector.itemName.BUNNYEARS);
			bunnyEarsRarity = ItemRarity.rare;
			bunnyEarsText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Pill
	public void PillRarityIncrease ()
	{
		if (pillRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.PILL);
			uncommon.Remove (ItemSelector.itemName.PILL);
			rare.Remove (ItemSelector.itemName.PILL);
			veryRare.Remove (ItemSelector.itemName.PILL);
			uncommon.Add (ItemSelector.itemName.PILL);
			pillRarity = ItemRarity.uncommon;
			pillText.text = "HIGH";
		}
		else if (pillRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.PILL);
			uncommon.Remove (ItemSelector.itemName.PILL);
			rare.Remove (ItemSelector.itemName.PILL);
			veryRare.Remove (ItemSelector.itemName.PILL);
			rare.Add (ItemSelector.itemName.PILL);
			pillRarity = ItemRarity.rare;
			pillText.text = "MEDIUM";
		}
		else if (pillRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.PILL);
			uncommon.Remove (ItemSelector.itemName.PILL);
			rare.Remove (ItemSelector.itemName.PILL);
			veryRare.Remove (ItemSelector.itemName.PILL);
			veryRare.Add (ItemSelector.itemName.PILL);
			pillRarity = ItemRarity.veryRare;
			pillText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void PillRarityDecrease ()
	{
		if (pillRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.PILL);
			uncommon.Remove (ItemSelector.itemName.PILL);
			rare.Remove (ItemSelector.itemName.PILL);
			veryRare.Remove (ItemSelector.itemName.PILL);
			common.Add (ItemSelector.itemName.PILL);
			pillRarity = ItemRarity.common;
			pillText.text = "VERY HIGH";
		}
		else if (pillRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.PILL);
			uncommon.Remove (ItemSelector.itemName.PILL);
			rare.Remove (ItemSelector.itemName.PILL);
			veryRare.Remove (ItemSelector.itemName.PILL);
			uncommon.Add (ItemSelector.itemName.PILL);
			pillRarity = ItemRarity.uncommon;
			pillText.text = "HIGH";
		}
		else if (pillRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.PILL);
			uncommon.Remove (ItemSelector.itemName.PILL);
			rare.Remove (ItemSelector.itemName.PILL);
			veryRare.Remove (ItemSelector.itemName.PILL);
			rare.Add (ItemSelector.itemName.PILL);
			pillRarity = ItemRarity.rare;
			pillText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Shell
	public void ShellRarityIncrease ()
	{
		if (shellRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.SHELL);
			uncommon.Remove (ItemSelector.itemName.SHELL);
			rare.Remove (ItemSelector.itemName.SHELL);
			veryRare.Remove (ItemSelector.itemName.SHELL);
			uncommon.Add (ItemSelector.itemName.SHELL);
			shellRarity = ItemRarity.uncommon;
			shellText.text = "HIGH";
		}
		else if (shellRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.SHELL);
			uncommon.Remove (ItemSelector.itemName.SHELL);
			rare.Remove (ItemSelector.itemName.SHELL);
			veryRare.Remove (ItemSelector.itemName.SHELL);
			rare.Add (ItemSelector.itemName.SHELL);
			shellRarity = ItemRarity.rare;
			shellText.text = "MEDIUM";
		}
		else if (shellRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.SHELL);
			uncommon.Remove (ItemSelector.itemName.SHELL);
			rare.Remove (ItemSelector.itemName.SHELL);
			veryRare.Remove (ItemSelector.itemName.SHELL);
			veryRare.Add (ItemSelector.itemName.SHELL);
			shellRarity = ItemRarity.veryRare;
			shellText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void ShellRarityDecrease ()
	{
		if (shellRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.SHELL);
			uncommon.Remove (ItemSelector.itemName.SHELL);
			rare.Remove (ItemSelector.itemName.SHELL);
			veryRare.Remove (ItemSelector.itemName.SHELL);
			common.Add (ItemSelector.itemName.SHELL);
			shellRarity = ItemRarity.common;
			shellText.text = "VERY HIGH";
		}
		else if (shellRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.SHELL);
			uncommon.Remove (ItemSelector.itemName.SHELL);
			rare.Remove (ItemSelector.itemName.SHELL);
			veryRare.Remove (ItemSelector.itemName.SHELL);
			uncommon.Add (ItemSelector.itemName.SHELL);
			shellRarity = ItemRarity.uncommon;
			shellText.text = "HIGH";
		}
		else if (shellRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.SHELL);
			uncommon.Remove (ItemSelector.itemName.SHELL);
			rare.Remove (ItemSelector.itemName.SHELL);
			veryRare.Remove (ItemSelector.itemName.SHELL);
			rare.Add (ItemSelector.itemName.SHELL);
			shellRarity = ItemRarity.rare;
			shellText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Tomato
	public void TomatoRarityIncrease ()
	{
		if (tomatoRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.TOMATO);
			uncommon.Remove (ItemSelector.itemName.TOMATO);
			rare.Remove (ItemSelector.itemName.TOMATO);
			veryRare.Remove (ItemSelector.itemName.TOMATO);
			uncommon.Add (ItemSelector.itemName.TOMATO);
			tomatoRarity = ItemRarity.uncommon;
			tomatoText.text = "HIGH";
		}
		else if (tomatoRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.TOMATO);
			uncommon.Remove (ItemSelector.itemName.TOMATO);
			rare.Remove (ItemSelector.itemName.TOMATO);
			veryRare.Remove (ItemSelector.itemName.TOMATO);
			rare.Add (ItemSelector.itemName.TOMATO);
			tomatoRarity = ItemRarity.rare;
			tomatoText.text = "MEDIUM";
		}
		else if (tomatoRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.TOMATO);
			uncommon.Remove (ItemSelector.itemName.TOMATO);
			rare.Remove (ItemSelector.itemName.TOMATO);
			veryRare.Remove (ItemSelector.itemName.TOMATO);
			veryRare.Add (ItemSelector.itemName.TOMATO);
			tomatoRarity = ItemRarity.veryRare;
			tomatoText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void TomatoRarityDecrease ()
	{
		if (tomatoRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.TOMATO);
			uncommon.Remove (ItemSelector.itemName.TOMATO);
			rare.Remove (ItemSelector.itemName.TOMATO);
			veryRare.Remove (ItemSelector.itemName.TOMATO);
			common.Add (ItemSelector.itemName.TOMATO);
			tomatoRarity = ItemRarity.common;
			tomatoText.text = "VERY HIGH";
		}
		else if (tomatoRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.TOMATO);
			uncommon.Remove (ItemSelector.itemName.TOMATO);
			rare.Remove (ItemSelector.itemName.TOMATO);
			veryRare.Remove (ItemSelector.itemName.TOMATO);
			uncommon.Add (ItemSelector.itemName.TOMATO);
			tomatoRarity = ItemRarity.uncommon;
			tomatoText.text = "HIGH";
		}
		else if (tomatoRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.TOMATO);
			uncommon.Remove (ItemSelector.itemName.TOMATO);
			rare.Remove (ItemSelector.itemName.TOMATO);
			veryRare.Remove (ItemSelector.itemName.TOMATO);
			rare.Add (ItemSelector.itemName.TOMATO);
			tomatoRarity = ItemRarity.rare;
			tomatoText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//FireFlower
	public void FireFlowerRarityIncrease ()
	{
		if (fireFolwerRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.FIREFLOWER);
			uncommon.Remove (ItemSelector.itemName.FIREFLOWER);
			rare.Remove (ItemSelector.itemName.FIREFLOWER);
			veryRare.Remove (ItemSelector.itemName.FIREFLOWER);
			uncommon.Add (ItemSelector.itemName.FIREFLOWER);
			fireFolwerRarity = ItemRarity.uncommon;
			fireFlowerText.text = "HIGH";
		}
		else if (fireFolwerRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.FIREFLOWER);
			uncommon.Remove (ItemSelector.itemName.FIREFLOWER);
			rare.Remove (ItemSelector.itemName.FIREFLOWER);
			veryRare.Remove (ItemSelector.itemName.FIREFLOWER);
			rare.Add (ItemSelector.itemName.FIREFLOWER);
			fireFolwerRarity = ItemRarity.rare;
			fireFlowerText.text = "MEDIUM";
		}
		else if (fireFolwerRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.FIREFLOWER);
			uncommon.Remove (ItemSelector.itemName.FIREFLOWER);
			rare.Remove (ItemSelector.itemName.FIREFLOWER);
			veryRare.Remove (ItemSelector.itemName.FIREFLOWER);
			veryRare.Add (ItemSelector.itemName.FIREFLOWER);
			fireFolwerRarity = ItemRarity.veryRare;
			fireFlowerText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void FireFlowerRarityDecrease ()
	{
		if (fireFolwerRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.FIREFLOWER);
			uncommon.Remove (ItemSelector.itemName.FIREFLOWER);
			rare.Remove (ItemSelector.itemName.FIREFLOWER);
			veryRare.Remove (ItemSelector.itemName.FIREFLOWER);
			common.Add (ItemSelector.itemName.FIREFLOWER);
			fireFolwerRarity = ItemRarity.common;
			fireFlowerText.text = "VERY HIGH";
		}
		else if (fireFolwerRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.FIREFLOWER);
			uncommon.Remove (ItemSelector.itemName.FIREFLOWER);
			rare.Remove (ItemSelector.itemName.FIREFLOWER);
			veryRare.Remove (ItemSelector.itemName.FIREFLOWER);
			uncommon.Add (ItemSelector.itemName.FIREFLOWER);
			fireFolwerRarity = ItemRarity.uncommon;
			fireFlowerText.text = "HIGH";
		}
		else if (fireFolwerRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.FIREFLOWER);
			uncommon.Remove (ItemSelector.itemName.FIREFLOWER);
			rare.Remove (ItemSelector.itemName.FIREFLOWER);
			veryRare.Remove (ItemSelector.itemName.FIREFLOWER);
			rare.Add (ItemSelector.itemName.FIREFLOWER);
			fireFolwerRarity = ItemRarity.rare;
			fireFlowerText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//SmartBomb
	public void SmartBombRarityIncrease ()
	{
		if (tripMineRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.TRIPMINE);
			uncommon.Remove (ItemSelector.itemName.TRIPMINE);
			rare.Remove (ItemSelector.itemName.TRIPMINE);
			veryRare.Remove (ItemSelector.itemName.TRIPMINE);
			uncommon.Add (ItemSelector.itemName.TRIPMINE);
			tripMineRarity = ItemRarity.uncommon;
			tripMineText.text = "HIGH";
		}
		else if (tripMineRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.TRIPMINE);
			uncommon.Remove (ItemSelector.itemName.TRIPMINE);
			rare.Remove (ItemSelector.itemName.TRIPMINE);
			veryRare.Remove (ItemSelector.itemName.TRIPMINE);
			rare.Add (ItemSelector.itemName.TRIPMINE);
			tripMineRarity = ItemRarity.rare;
			tripMineText.text = "MEDIUM";
		}
		else if (tripMineRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.TRIPMINE);
			uncommon.Remove (ItemSelector.itemName.TRIPMINE);
			rare.Remove (ItemSelector.itemName.TRIPMINE);
			veryRare.Remove (ItemSelector.itemName.TRIPMINE);
			veryRare.Add (ItemSelector.itemName.TRIPMINE);
			tripMineRarity = ItemRarity.veryRare;
			tripMineText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void SmartBombRarityDecrease ()
	{
		if (tripMineRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.TRIPMINE);
			uncommon.Remove (ItemSelector.itemName.TRIPMINE);
			rare.Remove (ItemSelector.itemName.TRIPMINE);
			veryRare.Remove (ItemSelector.itemName.TRIPMINE);
			common.Add (ItemSelector.itemName.TRIPMINE);
			tripMineRarity = ItemRarity.common;
			tripMineText.text = "VERY HIGH";
		}
		else if (tripMineRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.TRIPMINE);
			uncommon.Remove (ItemSelector.itemName.TRIPMINE);
			rare.Remove (ItemSelector.itemName.TRIPMINE);
			veryRare.Remove (ItemSelector.itemName.TRIPMINE);
			uncommon.Add (ItemSelector.itemName.TRIPMINE);
			tripMineRarity = ItemRarity.uncommon;
			tripMineText.text = "HIGH";
		}
		else if (tripMineRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.TRIPMINE);
			uncommon.Remove (ItemSelector.itemName.TRIPMINE);
			rare.Remove (ItemSelector.itemName.TRIPMINE);
			veryRare.Remove (ItemSelector.itemName.TRIPMINE);
			rare.Add (ItemSelector.itemName.TRIPMINE);
			tripMineRarity = ItemRarity.rare;
			tripMineText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//BananaPeel
	public void BananaPeelRarityIncrease ()
	{
		if (bananaPeelRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.BANANAPEEL);
			uncommon.Remove (ItemSelector.itemName.BANANAPEEL);
			rare.Remove (ItemSelector.itemName.BANANAPEEL);
			veryRare.Remove (ItemSelector.itemName.BANANAPEEL);
			uncommon.Add (ItemSelector.itemName.BANANAPEEL);
			bananaPeelRarity = ItemRarity.uncommon;
			bananaPeelText.text = "HIGH";
		}
		else if (bananaPeelRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.BANANAPEEL);
			uncommon.Remove (ItemSelector.itemName.BANANAPEEL);
			rare.Remove (ItemSelector.itemName.BANANAPEEL);
			veryRare.Remove (ItemSelector.itemName.BANANAPEEL);
			rare.Add (ItemSelector.itemName.BANANAPEEL);
			bananaPeelRarity = ItemRarity.rare;
			bananaPeelText.text = "MEDIUM";
		}
		else if (bananaPeelRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.BANANAPEEL);
			uncommon.Remove (ItemSelector.itemName.BANANAPEEL);
			rare.Remove (ItemSelector.itemName.BANANAPEEL);
			veryRare.Remove (ItemSelector.itemName.BANANAPEEL);
			veryRare.Add (ItemSelector.itemName.BANANAPEEL);
			bananaPeelRarity = ItemRarity.veryRare;
			bananaPeelText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void BananaPeelRarityDecrease ()
	{
		if (bananaPeelRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.BANANAPEEL);
			uncommon.Remove (ItemSelector.itemName.BANANAPEEL);
			rare.Remove (ItemSelector.itemName.BANANAPEEL);
			veryRare.Remove (ItemSelector.itemName.BANANAPEEL);
			common.Add (ItemSelector.itemName.BANANAPEEL);
			bananaPeelRarity = ItemRarity.common;
			bananaPeelText.text = "VERY HIGH";
		}
		else if (bananaPeelRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.BANANAPEEL);
			uncommon.Remove (ItemSelector.itemName.BANANAPEEL);
			rare.Remove (ItemSelector.itemName.BANANAPEEL);
			veryRare.Remove (ItemSelector.itemName.BANANAPEEL);
			uncommon.Add (ItemSelector.itemName.BANANAPEEL);
			bananaPeelRarity = ItemRarity.uncommon;
			bananaPeelText.text = "HIGH";
		}
		else if (bananaPeelRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.BANANAPEEL);
			uncommon.Remove (ItemSelector.itemName.BANANAPEEL);
			rare.Remove (ItemSelector.itemName.BANANAPEEL);
			veryRare.Remove (ItemSelector.itemName.BANANAPEEL);
			rare.Add (ItemSelector.itemName.BANANAPEEL);
			bananaPeelRarity = ItemRarity.rare;
			bananaPeelText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}

	//Bumper
	public void BumperRarityIncrease ()
	{
		if (bumperRarity == ItemRarity.common) 
		{
			common.Remove (ItemSelector.itemName.BUMPER);
			uncommon.Remove (ItemSelector.itemName.BUMPER);
			rare.Remove (ItemSelector.itemName.BUMPER);
			veryRare.Remove (ItemSelector.itemName.BUMPER);
			uncommon.Add (ItemSelector.itemName.BUMPER);
			bumperRarity = ItemRarity.uncommon;
			bumperText.text = "HIGH";
		}
		else if (bumperRarity == ItemRarity.uncommon)
		{
			common.Remove (ItemSelector.itemName.BUMPER);
			uncommon.Remove (ItemSelector.itemName.BUMPER);
			rare.Remove (ItemSelector.itemName.BUMPER);
			veryRare.Remove (ItemSelector.itemName.BUMPER);
			rare.Add (ItemSelector.itemName.BUMPER);
			bumperRarity = ItemRarity.rare;
			bumperText.text = "MEDIUM";
		}
		else if (bumperRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.BUMPER);
			uncommon.Remove (ItemSelector.itemName.BUMPER);
			rare.Remove (ItemSelector.itemName.BUMPER);
			veryRare.Remove (ItemSelector.itemName.BUMPER);
			veryRare.Add (ItemSelector.itemName.BUMPER);
			bumperRarity = ItemRarity.veryRare;
			bumperText.text = "LOW";
		}
		SetDataHolderRarity ();
	}
	public void BumperRarityDecrease ()
	{
		if (bumperRarity == ItemRarity.uncommon) 
		{
			common.Remove (ItemSelector.itemName.BUMPER);
			uncommon.Remove (ItemSelector.itemName.BUMPER);
			rare.Remove (ItemSelector.itemName.BUMPER);
			veryRare.Remove (ItemSelector.itemName.BUMPER);
			common.Add (ItemSelector.itemName.BUMPER);
			bumperRarity = ItemRarity.common;
			bumperText.text = "VERY HIGH";
		}
		else if (bumperRarity == ItemRarity.rare)
		{
			common.Remove (ItemSelector.itemName.BUMPER);
			uncommon.Remove (ItemSelector.itemName.BUMPER);
			rare.Remove (ItemSelector.itemName.BUMPER);
			veryRare.Remove (ItemSelector.itemName.BUMPER);
			uncommon.Add (ItemSelector.itemName.BUMPER);
			bumperRarity = ItemRarity.uncommon;
			bumperText.text = "HIGH";
		}
		else if (bumperRarity == ItemRarity.veryRare)
		{
			common.Remove (ItemSelector.itemName.BUMPER);
			uncommon.Remove (ItemSelector.itemName.BUMPER);
			rare.Remove (ItemSelector.itemName.BUMPER);
			veryRare.Remove (ItemSelector.itemName.BUMPER);
			rare.Add (ItemSelector.itemName.BUMPER);
			bumperRarity = ItemRarity.rare;
			bumperText.text = "MEDIUM";
		}
		SetDataHolderRarity ();
	}
}








