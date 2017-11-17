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

	public Aistate ActiveState
	{
		get { return _mActivateState; }
		set
		{
			// Stops any running coroutinges, if there are any
			StopAllCoroutines();
			_mActivateState = value;

			// Run coroutine associated with active state
			switch (_mActivateState)
			{
				case Aistate.IDLE:
					StartCoroutine(StateIdle());
					break;

				case Aistate.CHASE:
					StartCoroutine(StateChase());
					break;

				case Aistate.ATTACK:
					StartCoroutine(StateDead());
					break;

				case Aistate.DEAD:
					StartCoroutine(StateIdle());
					break;
			}
			// Invoke state change event
			OnStateChanged.Invoke();
		}
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
