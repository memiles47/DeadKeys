using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Typer : MonoBehaviour
{
    // Reference to type word
    public static string TypedWord;

    // Text object for showing type
    private Text TyperText;

    // Reference to audio source component
    private AudioSource ThisAS;

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
        ThisAS = GetComponent<AudioSource>();
        ThisAS.clip = CombatSounds[0];

        TyperText = GetComponentInChildren<Text>();
    }

    // This is called once per frame
    void Update()
    {
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
        TyperText.text = Input.inputString;
        ThisAS.clip = CombatSounds[Random.Range(0, CombatSounds.Length)];
    }
}
