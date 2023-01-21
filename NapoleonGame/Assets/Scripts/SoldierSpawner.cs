using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
	private void Awake()
	{
		instante = this;
	}

	IEnumerator Start()
	{
		while(true)
		{
			yield return new WaitForSeconds(SpawnTime);
			GameObject go = Instantiate(soldier, transform.position, Quaternion.identity);
			movement = go.GetComponent<SoldierMovement>();
			listSoldiers.Add(go);
			for (int i = 0; i < go.transform.childCount; i++)
			{
				Transform child = go.transform.GetChild(i);
				child.gameObject.SetActive(false);
			}
			movement.tag = "GeorgeSoldier";
			movement.flippedRight = true;
			movement.Flip();
			Destroy(go, DestroyTime);
		}
	}


	public void DestroyAll()
	{
		foreach (GameObject soldier in listSoldiers)
		{
			Destroy(soldier);
		}
		listSoldiers.Clear();
	}

	public void DisableSpawn()
	{ 
		enabled = false;
	}

	public int SpawnTime = 3;
	public int DestroyTime = 32;
	public static SoldierSpawner instante;
	public GameObject soldier;
	public List<GameObject> listSoldiers = new List<GameObject>();
	SoldierMovement movement;
}
