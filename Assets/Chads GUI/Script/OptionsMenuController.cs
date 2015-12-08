using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour 
{
	public int livesCount;

	public float itemSpawnDelay;

	public GameObject optionsDataHolder;

	public AudioSource buttonPushAudio;

	public Text dropRateText;
	public Text livesCountText;

	//Item Text
	public Text hammerText;

	//Item Rarity
	public enum ItemRarity {common,uncommon,rare,veryRare}

	public ItemRarity hammerRarity;

	// Use this for initialization
	void Start () 
	{
		optionsDataHolder = GameObject.Find ("DataHolder");
		optionsDataHolder.GetComponent<DataHolder> ().itemSpawnDelay = itemSpawnDelay;
		optionsDataHolder.GetComponent<DataHolder> ().livesCount = livesCount;
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

	public void HammerRarityIncrease ()
	{
		if (hammerRarity == ItemRarity.common) 
		{
			hammerRarity = ItemRarity.uncommon;
			hammerText.text = "";
		}
	}

	public void DecreaseIndividualItems ()
	{

	}
}








