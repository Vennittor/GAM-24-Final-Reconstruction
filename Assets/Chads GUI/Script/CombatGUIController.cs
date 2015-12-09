using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatGUIController : MonoBehaviour 
 {
	public int playerCount;

	public GameObject playerDataHolder;
	public GameObject gameManager;

	//player one
	public Image pOneCharacterPortrait;
	public Image pOneStockImageOne;
	public Image pOneStockImageTwo;

	public Text pOneName;
	public Text pOnePercentText;

	public float pOneCurrentPercent;

	public GameObject playerOne;
	public GameObject playerOneGUI;

	//player two
	public Image pTwoCharacterPortrait;
	public Image pTwoStockImageOne;
	public Image pTwoStockImageTwo;

	public Text pTwoName;
	public Text pTwoPercentText;

	public float pTwoCurrentPercent;

	public GameObject playerTwo;
	public GameObject playerTwoGUI;

	//player three
	public Image pThreeCharacterPortrait;
	public Image pThreeStockImageOne;
	public Image pThreeStockImageTwo;
	
	public Text pThreeName;
	public Text pThreePercentText;
	
	public float pThreeCurrentPercent;
	
	public GameObject playerThree;
	public GameObject playerThreeGUI;

	//player four
	public Image pFourCharacterPortrait;
	public Image pFourStockImageOne;
	public Image pFourStockImageTwo;
	
	public Text pFourName;
	public Text pFourPercentText;
	
	public float pFourCurrentPercent;
	
	public GameObject playerFour;
	public GameObject playerFourGUI;

	// Use this for initialization
	void Start () 
	{
		playerDataHolder = GameObject.Find ("PlayerDataHolder");
		playerCount = playerDataHolder.GetComponent<PlayerDataHolder>().playerCount;
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerOneGUI ();
		PlayerTwoGUI ();
		PlayerThreeGUI ();
		PlayerFourGUI ();
		GUIPositions ();
	}

	void PlayerOneGUI ()
	{
		playerOne = gameManager.GetComponent<GameManager> ().playerOne;
		pOneCurrentPercent = playerOne.GetComponent<TempPlayerController> ().health;
		pOneName.text = playerDataHolder.GetComponent<PlayerDataHolder>().pOneCharacterName;
		pOneCharacterPortrait.sprite = playerDataHolder.GetComponent<PlayerDataHolder> ().pOnePortrait;
		pOneStockImageOne.sprite = playerDataHolder.GetComponent<PlayerDataHolder> ().pOneStock;
		pOneStockImageTwo.sprite = playerDataHolder.GetComponent<PlayerDataHolder> ().pOneStock;
		pOnePercentText.text = "" + (int)pOneCurrentPercent + "%";

		//Stock Images
		if (playerOne.GetComponent<TempPlayerController> ().lives == 2) 
		{
			pOneStockImageOne.gameObject.SetActive (true);
			pOneStockImageTwo.gameObject.SetActive (true);
		} 
		else if (playerOne.GetComponent<TempPlayerController> ().lives == 1) 
		{
			pOneStockImageOne.gameObject.SetActive (true);
			pOneStockImageTwo.gameObject.SetActive (false);
		}
		else if (playerOne.GetComponent<TempPlayerController> ().lives == 0)
		{
			pOneStockImageOne.gameObject.SetActive (false);
			pOneStockImageTwo.gameObject.SetActive (false);
		}

		//Percent Color
		if (playerOne.GetComponent<TempPlayerController> ().health < 50)
		{
			pOnePercentText.color = new Color (1,1,1);
		}
		if (playerOne.GetComponent<TempPlayerController> ().health >= 50 && playerOne.GetComponent<TempPlayerController> ().health < 100)
		{
			pOnePercentText.color = new Color (1,0.35f,0);
		}
		if (playerOne.GetComponent<TempPlayerController> ().health >= 100 && playerOne.GetComponent<TempPlayerController> ().health < 150)
		{
			pOnePercentText.color = new Color (1,0,0);
		}
		if (playerOne.GetComponent<TempPlayerController> ().health >= 150)
		{
			pOnePercentText.color = new Color (0.7f,0,0);
		}
	}

	void PlayerTwoGUI ()
	{ 
		playerTwo = gameManager.GetComponent<GameManager> ().playerTwo;
		pTwoCurrentPercent = playerTwo.GetComponent<TempPlayerController> ().health;
		pTwoName.text = playerDataHolder.GetComponent<PlayerDataHolder>().pTwoCharacterName;
		pTwoCharacterPortrait.sprite = playerDataHolder.GetComponent<PlayerDataHolder> ().pTwoPortrait;
		pTwoStockImageOne.sprite = playerDataHolder.GetComponent<PlayerDataHolder> ().pTwoStock;
		pTwoStockImageTwo.sprite = playerDataHolder.GetComponent<PlayerDataHolder> ().pTwoStock;
		pTwoPercentText.text = "" + (int)pOneCurrentPercent + "%";

		//Stock Images
		if (playerTwo.GetComponent<TempPlayerController> ().lives == 2) 
		{
			pTwoStockImageOne.gameObject.SetActive (true);
			pTwoStockImageTwo.gameObject.SetActive (true);
		} 
		else if (playerOne.GetComponent<TempPlayerController> ().lives == 1) 
		{
			pTwoStockImageOne.gameObject.SetActive (true);
			pTwoStockImageTwo.gameObject.SetActive (false);
		}
		else if (playerOne.GetComponent<TempPlayerController> ().lives == 0)
		{
			pTwoStockImageOne.gameObject.SetActive (false);
			pTwoStockImageTwo.gameObject.SetActive (false);
		}

		//Percent color
		if (playerTwo.GetComponent<TempPlayerController> ().health < 50)
		{
			pTwoPercentText.color = new Color (1,1,1);
		}
		if (playerTwo.GetComponent<TempPlayerController> ().health >= 50 && playerOne.GetComponent<TempPlayerController> ().health < 100)
		{
			pTwoPercentText.color = new Color (1,0.2f,0.2f);
		}
		if (playerTwo.GetComponent<TempPlayerController> ().health >= 100 && playerOne.GetComponent<TempPlayerController> ().health < 150)
		{
			pTwoPercentText.color = new Color (1,0,0);
		}
		if (playerTwo.GetComponent<TempPlayerController> ().health >= 150)
		{
			pTwoPercentText.color = new Color (0.7f,0,0);
		}
	}

	void PlayerThreeGUI ()
	{
		if (playerCount > 2) 
		{	
			playerThree = gameManager.GetComponent<GameManager> ().playerThree;
			pThreeCurrentPercent = playerThree.GetComponent<TempPlayerController> ().health;
			pThreeName.text = playerDataHolder.GetComponent<PlayerDataHolder>().pThreeCharacterName;
			pThreeCharacterPortrait.sprite = playerDataHolder.GetComponent<PlayerDataHolder> ().pThreePortrait;
			pThreeStockImageOne.sprite = playerDataHolder.GetComponent<PlayerDataHolder> ().pThreeStock;
			pThreeStockImageTwo.sprite = playerDataHolder.GetComponent<PlayerDataHolder> ().pThreeStock;
			pThreePercentText.text = "" + (int)pThreeCurrentPercent + "%";

			//Stock Images
			if (playerThree.GetComponent<TempPlayerController> ().lives == 2) 
			{
				pThreeStockImageOne.gameObject.SetActive (true);
				pThreeStockImageTwo.gameObject.SetActive (true);
			} 
			else if (playerThree.GetComponent<TempPlayerController> ().lives == 1) 
			{
				pThreeStockImageOne.gameObject.SetActive (true);
				pThreeStockImageTwo.gameObject.SetActive (false);
			}
			else if (playerThree.GetComponent<TempPlayerController> ().lives == 0)
			{
				pThreeStockImageOne.gameObject.SetActive (false);
				pThreeStockImageTwo.gameObject.SetActive (false);
			}
			
			//Percent color
			if (playerThree.GetComponent<TempPlayerController> ().health < 50)
			{
				pThreePercentText.color = new Color (1,1,1);
			}
			if (playerThree.GetComponent<TempPlayerController> ().health >= 50 && playerOne.GetComponent<TempPlayerController> ().health < 100)
			{
				pThreePercentText.color = new Color (1,0.2f,0.2f);
			}
			if (playerThree.GetComponent<TempPlayerController> ().health >= 100 && playerOne.GetComponent<TempPlayerController> ().health < 150)
			{
				pThreePercentText.color = new Color (1,0,0);
			}
			if (playerThree.GetComponent<TempPlayerController> ().health >= 150)
			{
				pThreePercentText.color = new Color (0.7f,0,0);
			}
		}
	}
//
	void PlayerFourGUI ()
	{
		if (playerCount > 3) 
		{
			playerFour = gameManager.GetComponent<GameManager> ().playerFour;
			pFourCurrentPercent = playerFour.GetComponent<TempPlayerController> ().health;
			pFourName.text = playerDataHolder.GetComponent<PlayerDataHolder>().pFourCharacterName;
			pFourCharacterPortrait.sprite = playerDataHolder.GetComponent<PlayerDataHolder> ().pFourPortrait;
			pFourStockImageOne.sprite = playerDataHolder.GetComponent<PlayerDataHolder> ().pFourStock;
			pFourStockImageTwo.sprite = playerDataHolder.GetComponent<PlayerDataHolder> ().pFourStock;
			pFourPercentText.text = "" + (int)pFourCurrentPercent + "%";

			//Stock Images
			if (playerFour.GetComponent<TempPlayerController> ().lives == 2) 
			{
				pFourStockImageOne.gameObject.SetActive (true);
				pFourStockImageTwo.gameObject.SetActive (true);
			} 
			else if (playerFour.GetComponent<TempPlayerController> ().lives == 1) 
			{
				pFourStockImageOne.gameObject.SetActive (true);
				pFourStockImageTwo.gameObject.SetActive (false);
			}
			else if (playerFour.GetComponent<TempPlayerController> ().lives == 0)
			{
				pFourStockImageOne.gameObject.SetActive (false);
				pFourStockImageTwo.gameObject.SetActive (false);
			}
			
			//Percent color
			if (playerFour.GetComponent<TempPlayerController> ().health < 50)
			{
				pFourPercentText.color = new Color (1,1,1);
			}
			if (playerFour.GetComponent<TempPlayerController> ().health >= 50 && playerOne.GetComponent<TempPlayerController> ().health < 100)
			{
				pFourPercentText.color = new Color (1,0.2f,0.2f);
			}
			if (playerFour.GetComponent<TempPlayerController> ().health >= 100 && playerOne.GetComponent<TempPlayerController> ().health < 150)
			{
				pFourPercentText.color = new Color (1,0,0);
			}
			if (playerFour.GetComponent<TempPlayerController> ().health >= 150)
			{
				pFourPercentText.color = new Color (0.7f,0,0);
			}
		}
	}

	void GUIPositions ()
	{
		if (playerCount == 2)
		{
			playerOneGUI.transform.localPosition = new Vector3 (-100, -175, 0);
			playerTwoGUI.transform.localPosition = new Vector3 (100, -175, 0);
			playerThreeGUI.SetActive (false);
			playerFourGUI.SetActive (false);
		} 
		else if (playerCount == 3) 
		{
			playerOneGUI.transform.localPosition = new Vector3(-200,-175,0);
			playerTwoGUI.transform.localPosition = new Vector3(0,-175,0);
			playerThreeGUI.transform.localPosition = new Vector3(200,-175,0);
			playerThreeGUI.SetActive (true);
			playerFourGUI.SetActive (false);
		}
		else if (playerCount == 4)
		{
			playerOneGUI.transform.localPosition = new Vector3(-300,-175,0);
			playerTwoGUI.transform.localPosition = new Vector3(-100,-175,0);
			playerThreeGUI.transform.localPosition = new Vector3(100,-175,0);
			playerFourGUI.transform.localPosition = new Vector3(300,-175,0);
			playerThreeGUI.SetActive (true);
			playerFourGUI.SetActive (true);
		}
	}
}














