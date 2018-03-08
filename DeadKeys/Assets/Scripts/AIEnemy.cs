using System.Collections;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public enum AiState
    {
        Idle = 0,
        Chase = 1,
        Attack = 2,
        Dead = 3
    };

    //Present to inspector
    [SerializeField] private AiState _mActivateState = AiState.Idle;

    // Events
    public UnityEvent OnStateChanged;
    public UnityEvent OnIdleEnter;
    public UnityEvent OnChaseEnter;
    public UnityEvent OnAttackEnter;
    public UnityEvent OnTypingChanged;
    public UnityEvent OnTypingMatched;

    // Component References
    private Animator _thisAnimator;
    private NavMeshAgent _thisAgent;
    private Transform _thisTransform;

    // Reference to player transform
    private Transform _playerTransform;

    // Points for Enemy
    public int ScorePoints = 10;

    // Reference to Score Text
    private UiScore _scoreText;

    // Reference to Player Health Component
    private Health _playerHealth;

    public float PlyrHealth;

    // Word Associated
    public string AssocWord = string.Empty;
    
    // Extent of word match with associated word
    public string MatchedWord = string.Empty;

    // Amount of damage to deal on attack
    public int AttackDamage = 10;

    // Text component
    private Text _nameTextComp;

    // Acitve enemy count (how many enemies wandering at one time)
    public int ActiveEnemies;

    // Sound to play on hit
    public AudioSource HitSound;

    // Display Remaining Distance
    public float RemainingDistance;

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
                case AiState.Idle:
                    StartCoroutine(StateIdle());
                    break;

                case AiState.Chase:
                    StartCoroutine(StateChase());
                    break;

                case AiState.Attack:
                    StartCoroutine(StateAttack());
                    break;

                case AiState.Dead:
                    StartCoroutine(StateDead());
                    break;
            }
            // Invoke state change event
            OnStateChanged.Invoke();
        }
    }

    public void Awake()
    {
        // Initialize components
        _thisAnimator = GetComponent<Animator>();
        _thisAgent = GetComponent<NavMeshAgent>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        // Find and get associated UI text
        _nameTextComp = GetComponentInChildren<Text>();
        _thisTransform = GetComponent<Transform>();
        HitSound = GetComponent<AudioSource>();
        _scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<UiScore>();

        // Hide Enemy UItext
        _nameTextComp.gameObject.SetActive(false);
    }

    public void Start()
    {
        // Set active state
        ActiveState = _mActivateState;

        // Get random word
        AssocWord = WordList.ThisInstance.GetRandomWord();

        UpdateText();
    }

    public void Update()
    {
        // Displays Distance remaing to enemy in inspector
        RemainingDistance = _thisAgent.remainingDistance;
    }

    // Events called on FSM changes
    public IEnumerator StateIdle()
    {
        // Run Idle animation
        _thisAnimator.SetInteger("AnimState", (int) ActiveState);

        // While in idle state
        while (ActiveState == AiState.Idle)
        {
            yield return null;
        }
    }

    public IEnumerator StateChase()
    {
        ++ActiveEnemies;

        // Run chase animation
        _thisAnimator.SetInteger("AnimState", (int) ActiveState);

        // Set destination
        _thisAgent.SetDestination(_playerTransform.position);

        // Wait until path is calculated
        while (!_thisAgent.hasPath)
        {
            yield return null;
        }

        // While in chase state
        while (ActiveState == AiState.Chase)
        {
            // Look at player
            Vector3 planarPosition = new Vector3(_playerTransform.position.x, _thisTransform.position.y,
                _playerTransform.position.z);
            _thisTransform.LookAt(planarPosition, _thisTransform.up);

            if (_thisAgent.remainingDistance <= _thisAgent.stoppingDistance)
            {
                _thisAgent.isStopped = true; // .Stop is obsolete, use .isStopped = true
                yield return null;
                ActiveState = AiState.Attack;
                yield break;
            }
            yield return null;
        }
    }

    public IEnumerator StateAttack()
    {
        // Run attack animation
        _thisAnimator.SetInteger("AnimState", (int) ActiveState);

        //While in attack state
        while (ActiveState == AiState.Attack)
        {
            // Look at player
            Vector3 planarPosition = new Vector3(_playerTransform.position.x, _thisTransform.position.y,
                _playerTransform.position.z);
            _thisTransform.LookAt(planarPosition, _thisTransform.up);

            // Get distance between enemy and player
            float distance = Vector3.Distance(_playerTransform.position, _thisTransform.position);

            if (distance > _thisAgent.stoppingDistance * 2f)
            {
                _thisAgent.isStopped = true;
                yield return null;
                ActiveState = AiState.Chase;
                yield break;
            }
            yield return null;
        }
    }

    public IEnumerator StateDead()
    {
        // Run dead animation
        _thisAnimator.SetInteger("AnimState", (int) ActiveState);

        //While in dead state
        while (ActiveState == AiState.Dead)
        {
            yield return null;
        }
    }

    public void UpdateTypedWord()
    {
        // If not chasing or attacking the ignore
        if (ActiveState != AiState.Chase && ActiveState != AiState.Attack)
        {
            return;
        }

        MatchedWord = WordList.CompareWords(Typer.TypedWord, AssocWord);

        // Check for typing match
        if (MatchedWord.Length != AssocWord.Length)
        {
            return;
        }

        if (MatchedWord.Equals(AssocWord))
        {
            OnTypingChanged.Invoke(); // Match found. Invoke matched event
        }
    }

    // Deal damage to player
    public void DealDamage()
    {
        _playerHealth.Value -= AttackDamage;
        HitSound.Play();
    }

    public void UpdateText()
    {
        // Build UI String
        _nameTextComp.text = "<color=red>" + MatchedWord + "</color>" + AssocWord.Substring(MatchedWord.Length, AssocWord.Length - 
            MatchedWord.Length);
    }

    public void Die()
    {
        GameManager.ThisInstance.Score += ScorePoints;
        _scoreText.OnScoreChange.Invoke();

        // Calculate Bonus, if achieved
        float lettersPerSecond = AssocWord.Length / Typer.ElapsedTime;

        // If we beat best times, then get bonus
        if (lettersPerSecond < Typer.RecordLettersPerSecond)
        {
            // Bonus achieved
            ++GameManager.ThisInstance.BonusLevel;
        }

        ActiveState = AiState.Dead;
        --ActiveEnemies;

        // Reset matched word
        MatchedWord = string.Empty;

        // Update Navigator
        Navigator.ThisInstance.EnemyDie.Invoke();
    }

    public void WakeUp()
    {
        _nameTextComp.gameObject.SetActive(true);
        ActiveState = AiState.Chase;
    }
}
