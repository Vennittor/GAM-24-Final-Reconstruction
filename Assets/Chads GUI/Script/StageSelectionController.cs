using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageSelectionController : MonoBehaviour 
{
	public float fadeSpeed;
	public float buttonSpeed;

	public bool fade;
	public bool buttonMove;

	public GameObject stageDataHolder;
	public GameObject stageButtons;
	public GameObject brawlBackButtons;

	public Sprite[] stages;

	public Image selectedStage;
	public Image background;

	// Use this for initialization
	void Start () 
	{
		stageDataHolder = GameObject.Find ("DataHolder");
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

	void LoadCharacterSelect ()
	{
		Application.LoadLevel (3);
	}

//	BUTTONS
	
	public void BackButton ()
	{
		fade = false;
		buttonMove = false;
		Invoke ("LoadCharacterSelect",0.75f);
	}

	public void BrawlButton ()
	{
		if (stageDataHolder.GetComponent<DataHolder> ().stageSelection != DataHolder.StageSelect.none) 
		{
			fade = false;
			buttonMove = false;
			Invoke ("LoadCombatScene",0.75f);
		}
	}
	
	//Stages
	public void FinalDestination ()
	{
		stageDataHolder.GetComponent<DataHolder>().stageSelection = DataHolder.StageSelect.finalDestination;
		selectedStage.sprite = stages[0];
		selectedStage.color = new Color (1,1,1,1);
	}

	public void PokemonStadium ()
	{
		stageDataHolder.GetComponent<DataHolder>().stageSelection = DataHolder.StageSelect.pokemonStadium;
		selectedStage.sprite = stages[1];
		selectedStage.color = new Color (1,1,1,1);
	}

	public void GreenyGreens ()
	{
		stageDataHolder.GetComponent<DataHolder> ().stageSelection = DataHolder.StageSelect.greenyGreens;
		selectedStage.sprite = stages [2];
		selectedStage.color = new Color (1,1,1,1);
	}

	public void Hyrule ()
	{
		stageDataHolder.GetComponent<DataHolder> ().stageSelection = DataHolder.StageSelect.hyrule;
		selectedStage.sprite = stages[3];
		selectedStage.color = new Color (1,1,1,1);
	}
}












