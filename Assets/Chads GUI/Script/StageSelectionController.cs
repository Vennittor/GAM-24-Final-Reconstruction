using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageSelectionController : MonoBehaviour 
{
	public float fadeSpeed;
	public float buttonSpeed;

	public bool fade;
	public bool buttonMove;

	public GameObject playerDataHolder;
	public GameObject stageButtons;
	public GameObject brawlBackButtons;

	public Sprite[] stages;

	public Image selectedStage;
	public Image background;

	// Use this for initialization
	void Start () 
	{
		playerDataHolder = GameObject.Find ("DataHolder");
		fade = true;
		buttonMove = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Fade ();
		ButtonMovement ();
	}

	void Fade ()
	{
		if (fade == true)
		{
			background.color = Color.Lerp (background.color,new Color(1,1,1),fadeSpeed * Time.deltaTime);
		}
		else
		{
			background.color = Color.Lerp (background.color,new Color(0,0,0),fadeSpeed * Time.deltaTime);
		}
	}

	void ButtonMovement ()
	{
		Vector3 buttonPositions = new Vector3 (0,0,0);
		if (buttonMove == true)
		{
			stageButtons.transform.localPosition = Vector3.Lerp (stageButtons.transform.localPosition,buttonPositions,buttonSpeed);
			brawlBackButtons.transform.localPosition = Vector3.Lerp (brawlBackButtons.transform.localPosition,buttonPositions,buttonSpeed);
		}
		else
		{
			stageButtons.transform.localPosition = Vector3.Lerp (stageButtons.transform.localPosition,new Vector3 (0,500,0),buttonSpeed);
			brawlBackButtons.transform.localPosition = Vector3.Lerp (brawlBackButtons.transform.localPosition,new Vector3 (0,-500,0),buttonSpeed);
		}
	}

	void LoadCombatScene ()
	{
		Application.LoadLevel (5);
	}

//	BUTTONS


	public void BackButton ()
	{
		Application.LoadLevel (3);
	}

	public void BrawlButton ()
	{
		if (playerDataHolder.GetComponent<DataHolder> ().stageSelection != DataHolder.StageSelect.none) 
		{
			fade = false;
			buttonMove = false;
			Invoke ("LoadCombatScene",0.75f);
		}
	}
	
	//Stages
	public void FinalDestination ()
	{
		playerDataHolder.GetComponent<DataHolder>().stageSelection = DataHolder.StageSelect.finalDestination;
		selectedStage.sprite = stages[0];
		selectedStage.color = new Color (1,1,1,1);
	}

	public void PokemonStadium ()
	{
		playerDataHolder.GetComponent<DataHolder>().stageSelection = DataHolder.StageSelect.pokemonStadium;
		selectedStage.sprite = stages[1];
		selectedStage.color = new Color (1,1,1,1);
	}

	public void GreenyGreens ()
	{
		playerDataHolder.GetComponent<DataHolder> ().stageSelection = DataHolder.StageSelect.greenyGreens;
		selectedStage.sprite = stages [2];
		selectedStage.color = new Color (1,1,1,1);
	}

	public void Hyrule ()
	{
		playerDataHolder.GetComponent<DataHolder> ().stageSelection = DataHolder.StageSelect.hyrule;
		selectedStage.sprite = stages[3];
		selectedStage.color = new Color (1,1,1,1);
	}

	public void YoshiIsland ()
	{
		playerDataHolder.GetComponent<DataHolder> ().stageSelection = DataHolder.StageSelect.yoshiIsland;
		selectedStage.sprite = stages[4];
		selectedStage.color = new Color (1,1,1,1);
	}

	public void FrigateOrpheon ()
	{
		playerDataHolder.GetComponent<DataHolder> ().stageSelection = DataHolder.StageSelect.frigateOrpheon;
		selectedStage.sprite = stages [5];
		selectedStage.color = new Color (1, 1, 1, 1);
	}
}












