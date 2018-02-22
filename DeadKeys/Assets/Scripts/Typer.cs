using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class Typer : MonoBehaviour
    {
        // Reference to type word
        public static string TypedWord = string.Empty;

        // Reference to all enemies in level
        private AIEnemy[] Enemies;

        // Text object for showing type
        public Text _typerText;

        // Reference to audio source component
        public AudioSource _thisAs;

        // Typing changed event
        public UnityEvent OnTypingChanged;

        // Time elapsed since last reset
        public static float ElapsedTime = 0.0f;

        // Record words per second
        public static float RecordLettersPerSecond = 2f;

        // Collection of combat sounds
        public AudioClip[] CombatSounds;

        public void Awake()
        {
            // Get audio source
            _thisAs = GetComponent<AudioSource>();
            _thisAs.clip = CombatSounds[0];

            _typerText = GetComponentInChildren<Text>();
        }

        public void Update()
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
