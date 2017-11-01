using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList : MonoBehaviour
{
    // Text asset featuring word list assignments
    public TextAsset FileWordList = null;
    public string[] Words;

    // Members for Singleton
    public static WordList ThisInstance
    {
        get
        {
            // Get or create singleton instance
            if (m_WL == null)
            {
                GameObject GO = new GameObject("WordList");
                ThisInstance = GO.AddComponent<WordList>();
            }
            return m_WL;
        }

        set
        {
            // If not null then we already have instance
            if (m_WL != null)
            {
                // If different, then remove duplicate immediately
                if (m_WL.GetInstanceID() != value.GetInstanceID())
                    DestroyImmediate(value.gameObject);

                return;
            }

            // If new, then create new singleton instance
            m_WL = value;
            DontDestroyOnLoad(m_WL.gameObject);
        }
    }

    private static WordList m_WL = null;

    // Use this for initialization
    void Awake()
    {
        // Set singleton instance
        ThisInstance = this;

        // Now load word list, if available
        if (FileWordList == null)
        {
            FileWordList = (TextAsset) Resources.Load("WordList");
            Words = FileWordList.text.Split(new[] {"\r\n"}, System.StringSplitOptions.None);
        }
    }

    // Returns a random word from the word list
    public string GetRandomWord()
    {
        return Words[Random.Range(0, Words.Length)].ToLower();
    }

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
