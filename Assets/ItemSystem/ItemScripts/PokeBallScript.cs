using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class PokeBallScript : ItemBaseScript
{
    public enum PokemonNames {CHIKORITA, MOLTRESS, METAGROSS, SNORLAX}

    public GameObject[] pokemon;

    public List<PokemonNames> common = new List<PokemonNames>();
    public List<PokemonNames> unCommon = new List<PokemonNames>();
    public List<PokemonNames> rare = new List<PokemonNames>();
    public List<PokemonNames> veryRare = new List<PokemonNames>();

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FunctionBeta();
        }
        base.Update();
    }

    public override void FunctionAlpha()
    {
        thrown = true;
        base.FunctionAlpha();
    }
    public override void FunctionBeta()
    {
        Instantiate(SpawnPokemon(Roll()), gameObject.transform.position + Vector3.up, Quaternion.identity);
        base.FunctionBeta();
    }
    void OnCollisionEnter(Collision other)
    {
        if (thrown)
        //apply thrown damage
        FunctionBeta();
    }
    PokemonNames Roll()
    {
        float spawnRoll = Random.Range(0f, 100f);
        if (spawnRoll < 40f)
        {
            int choice = Random.Range(0, common.Count);
            return common[choice];
        }
        else if (spawnRoll >= 40 && spawnRoll < 70)
        {
            int choice = Random.Range(0, unCommon.Count);
            return unCommon[choice];
        }
        else if (spawnRoll >= 70 && spawnRoll < 90)
        {
            int choice = Random.Range(0, rare.Count);
            return rare[choice];
        }
        else
        {
            int choice = Random.Range(0, veryRare.Count);
            return veryRare[choice];
        }
    }
    GameObject SpawnPokemon(PokemonNames name)
    {
        if (name == PokemonNames.CHIKORITA)
            return pokemon[0];
        if (name == PokemonNames.METAGROSS)
            return pokemon[1];
        if (name == PokemonNames.MOLTRESS)
            return pokemon[2];
        if (name == PokemonNames.SNORLAX)
            return pokemon[3];
        else
            return null;

    }
}
