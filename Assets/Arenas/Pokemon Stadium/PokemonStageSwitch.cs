using UnityEngine;
using System.Collections;

public class PokemonStageSwitch : MonoBehaviour {

    //Purpose: switch the arena stages
        //This probably isn't the best implementation of this but arrays and I don't really get along and this works...
   
    
    //Plug in the gameobject parents of the stages here
    public GameObject PokemonMainStage = null;
    public GameObject PokemonFireStage = null;
    public GameObject PokemonEarthStage = null;
    public GameObject PokemonWaterStage = null;
    public GameObject PokemonGrassStage = null;
    

    public bool pokemonMainStageActive = true;

    public float stageSwitchTimer = 0.0f;

    // Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
     
        //After a certain time, change the stage to or from the main one
        stageSwitchTimer += Time.deltaTime;

        //change this to something higher than five for non testing purposes
        if (stageSwitchTimer >= 5)
        {
            SwitchStage();

        }

	}

    //Call this when the timer says to switch stage
    void SwitchStage()
    {
        // Purpose:load a stage randomly or go back to the main

        //gimme a random number
        int randomNumber = Random.Range(1, 4);

        //go back to main if you are somewhere else
        if (pokemonMainStageActive == false)
        {
            stageSwitchTimer = 0;

            //activate main
            pokemonMainStageActive = true;
            PokemonMainStage.SetActive(true);
          
            //disable everything else
            PokemonFireStage.SetActive(false);
            PokemonEarthStage.SetActive(false);
            PokemonWaterStage.SetActive(false);
            PokemonGrassStage.SetActive(false);

            
        }
            //otherwise go to a random stage
        else if (pokemonMainStageActive == true)
        {
            pokemonMainStageActive = false;
            stageSwitchTimer = 0;

            if (randomNumber == 1)
            {
                PokemonFireStage.SetActive(true);
            }
            else if (randomNumber == 2)
            {
                PokemonEarthStage.SetActive(true);
            }
            else if (randomNumber == 3)
            {
                PokemonWaterStage.SetActive(true);
            }
            else if (randomNumber == 4)
            {
                PokemonGrassStage.SetActive(true);
            }

          //then disable the main one
            PokemonMainStage.SetActive(false);


          
        }
    }

   
}
