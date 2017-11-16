using System.Collections;
using UnityEngine;

public class UIBonus : MonoBehaviour
{
	public GameObject[] BonusObjects;

	// Use this for initialization
	void Awake ()
	{
		BonusObjects = GameObject.FindGameObjectsWithTag("BonusObject");
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Set bonus level
		// Hide/Show all bonus objects
		for (int i = 0; i < BonusObjects.Length; i++)
		{
		    BonusObjects[i].SetActive(i < GameManager.ThisInstance.BonusLevel);
		}
	}
}
