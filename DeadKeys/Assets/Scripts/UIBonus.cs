using System.Collections;
using UnityEngine;

public class UIBonus : MonoBehaviour
{
	public GameObject[] BonusObjects;

	public void Awake ()
	{
		BonusObjects = GameObject.FindGameObjectsWithTag("BonusObject");
	}
	
	public void Update ()
	{
		// Set bonus level
		// Hide/Show all bonus objects
		for (int i = 0; i < BonusObjects.Length; i++)
		{
		    BonusObjects[i].SetActive(i < GameManager.ThisInstance.BonusLevel);
		}
	}
}
