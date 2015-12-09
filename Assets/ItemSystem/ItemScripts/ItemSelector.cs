using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ItemSelector : MonoBehaviour
{
	public enum itemName {BANANAPEEL,BEAMSWORD, BO_OMB, BUMPER, BUNNYEARS,
                          FAN, FIREFLOWER, HAMMER, HOMERUNBAT, ICE, LASERGUN,
                          METAL, MUSHROOM, PILL, POKEBALL, SHELL, SMASHBALL, STAR, TOMATO, TRIPMINE};

	public List<itemName> common;
	public List<itemName> unCommon;
	public List<itemName> rare;
	public List<itemName> veryRare;

	public List<GameObject>itemPrefabs;

	public itemName RandomDrop()
	{
		
			float spawnRoll = Random.Range (0f, 100f);
			if (spawnRoll < 40f) 
			{
				int choice = Random.Range (0, common.Count);
				return common[choice];
			} 
			else if (spawnRoll >= 40 && spawnRoll < 70) 
			{
				int choice = Random.Range (0, unCommon.Count);
				return unCommon[choice];
			} 
			else if (spawnRoll >= 70 && spawnRoll < 90) 
			{
				int choice = Random.Range (0, rare.Count);
				return rare[choice];
			} 
			else
			{
				int choice = Random.Range (0, veryRare.Count);
				return veryRare [choice];
			}
	}
    public GameObject SpawnItem(itemName item)
    {
        return itemPrefabs[(int)item];
    }

}
