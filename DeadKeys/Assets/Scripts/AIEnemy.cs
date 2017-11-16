using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class AIEnemy : MonoBehaviour
{
	public enum Aistate
	{
		IDLE = 0,
		CHASE = 1,
		ATTACK = 2,
		DEAD = 3
	};

	[SerializeField] private Aistate _mActivateState = Aistate.IDLE;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
