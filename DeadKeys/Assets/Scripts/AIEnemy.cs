using System.Collections;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class AIEnemy : MonoBehaviour
{
	public enum AiState
	{
		IDLE = 0,
		CHASE = 1,
		ATTACK = 2,
		DEAD = 3
	};

	[SerializeField] private AiState _mActivateState = AiState.IDLE;

	// Events
	public UnityEvent OnStateChanged;
	public UnityEvent OnIdleEnter;
	public UnityEvent OnChaseEnter;
	public UnityEvent OnAttackEnter;
	public UnityEvent OnTypingChanged;
	public UnityEvent OnTypingMatched;

	// Component References
	private Animator _thisAnimator;
	private UnityEngine.AI.NavMeshAgent ThisAgent;
	private Transform ThisTransform;

	// Reference to player transform
	private Transform PlayerTransform;

	// Points for Enemy
	public int ScorePoints = 10;

	// Reference to Score Text
	private UIScore ScoreText;

	// Player Health Component
	private Health PlayerHealth;

	// Word Associated
	public string AssocWord;
	
	// Extent of word match with associated word
	public string MachedWord;


	public AiState ActiveState
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
				case AiState.IDLE:
					StartCoroutine(StateIdle());
					break;

				case AiState.CHASE:
					StartCoroutine(StateChase());
					break;

				case AiState.ATTACK:
					StartCoroutine(StateAttack());
					break;

				case AiState.DEAD:
					StartCoroutine(StateDead());
					break;
			}
			// Invoke state change event
			OnStateChanged.Invoke();
		}
	}

	// Events called on FSM changes
	public IEnumerator StateIdle()
	{
		// Add Body Here
		yield break;
	}

	public IEnumerator StateChase()
	{
		// Add Body Here
		yield break;
	}

	public IEnumerator StateAttack()
	{
		// Add Body Here
		yield break;
	}

	public IEnumerator StateDead()
	{
		// Add Body Here
		yield break;
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
