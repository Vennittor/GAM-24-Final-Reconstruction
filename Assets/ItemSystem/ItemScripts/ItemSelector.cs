using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ItemSelector : MonoBehaviour
{
	public enum itemName {FAN, BEAMSWORD, HOMERUNBAT, POKEBALL, BO_OMB,
						ICE, METAL,MUSHROOM,LASERGUN,STAR,SMASHBALL,BUNNYEARS,
						HAMMER,PILL,SHELL,TOMATO,FIREFLOWER,TRIPMINE,BANANAPEEL,
						BUMPER};

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
		Debug.Log (item);
		if (item == itemName.BANANAPEEL) 
		{
			return itemPrefabs[0];
		}
		else if (item == itemName.BEAMSWORD) 
		{
			return itemPrefabs[1];
		}
		
		else if (item == itemName.BO_OMB)
		{
			return itemPrefabs[2];
		}
		else if (item == itemName.BUMPER) 
		{
			return itemPrefabs[3];
		}
		else if (item == itemName.BUNNYEARS) 
		{
			return itemPrefabs[4];
		}
		else if (item == itemName.FAN) 
		{
			return itemPrefabs[5];
		}
		else if (item == itemName.FIREFLOWER) 
		{
			return itemPrefabs[6];
		}
		else if (item == itemName.HAMMER) 
		{
			return itemPrefabs[7];
		}
		else if (item == itemName.HOMERUNBAT) 
		{
			return itemPrefabs[8];
		}
		else if (item == itemName.ICE) 
		{
			return itemPrefabs[9];
		}
		else if (item == itemName.LASERGUN) {
			return itemPrefabs[10];
		}
		else if (item == itemName.METAL) 
		{
			return itemPrefabs[11];
		}
		else if (item == itemName.MUSHROOM) 
		{
			return itemPrefabs[12];
		}
		else if (item == itemName.PILL) 
		{
			return itemPrefabs[13];
		}
		else if (item == itemName.POKEBALL) 
		{
			return itemPrefabs[14];
		}
		else if (item == itemName.SHELL) {
			return itemPrefabs[15];
		}
		else if (item == itemName.SMASHBALL) 
		{
			return itemPrefabs[16];
		}
		else if (item == itemName.STAR) 
		{
			return itemPrefabs[17];
		}
		else if (item == itemName.TOMATO) 
		{
			return itemPrefabs[18];
		}
		else if (item == itemName.TRIPMINE) 
		{
			return itemPrefabs[19];
		}
		else
				return null;
	}

}
