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

    public override void FunctionAlpha(Vector3 throwDirection = default(Vector3))
    {
        Released(throwDirection);
        base.FunctionAlpha();
    }
    public override void FunctionBeta()
    {
        GameObject a = Instantiate(SpawnPokemon(Roll()), gameObject.transform.position + Vector3.up, Quaternion.identity) as GameObject;
        if (a.GetComponent<Metagross>())
            a.transform.rotation = Quaternion.Euler(new Vector3(-90, -90, 0));
        else if (a.GetComponent<ChikoritaScript>())
            a.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        else if (a.GetComponent<Snorlax>())
            a.transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
        else if (a.GetComponent<MoltresScript>())
            a.transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));

        base.FunctionBeta();
    }
    void OnCollisionEnter(Collision other)
    {
        if (thrown)
        {
            FunctionBeta();
            durability = 0;
        }
        
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
