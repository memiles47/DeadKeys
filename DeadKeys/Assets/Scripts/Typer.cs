using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class Typer : MonoBehaviour
    {
        // Reference to type word
        public string TypedWord = string.Empty;

        // Reference to all enemies in level
        private AIEnemy[] Enemies;

        // Text object for showing type
        private Text _typerText;

        // Reference to audio source component
        private AudioSource _thisAs;

        // Typing changed event
        public UnityEvent OnTypingChanged;

        // Time elapsed since last reset
        public static float ElapsedTime = 0.0f;

        // Record words per second
        public static float RecordLettersPerSecond = 2f;

        // Collection of combat sounds
        public AudioClip[] CombatSounds;

        // Use this for initialization
        void Awake()
        {
            // Get audio source
            _thisAs = GetComponent<AudioSource>();
            _thisAs.clip = CombatSounds[0];

            _typerText = GetComponentInChildren<Text>();
        }

        // This is called once per frame
        void Update()
        {
            // Update Time
            ElapsedTime += Time.deltaTime;

            // Update typed string
            if (Input.inputString.Length > 0)
            {
                TypedWord += Input.inputString.ToLower();
                UpdateTyping();
            }
        }

        // Update enemy type event
        private void UpdateTyping()
        {
            UpdateTyperText();

            // Update GUI Typer
            OnTypingChanged.Invoke();
            Reset();
        }

        // Reset typing and time
        public void Reset()
        {
            // Reset typing
            TypedWord = string.Empty;

            // Reset time
            ElapsedTime = 0.0f;
        }

        public void UpdateTyperText()
        {
            _typerText.text = Input.inputString.ToLower();
            _thisAs.clip = CombatSounds[Random.Range(0, CombatSounds.Length)];
        }
    }
}
