using UnityEngine;

namespace Assets.Scripts
{
    public class WordList : MonoBehaviour
    {
        // Text asset featuring word list assignments
        public TextAsset FileWordList;
        public string[] Words;

        private static WordList _mWl;


        // Members for Singleton
        public static WordList ThisInstance
        {
            get
            {
                // Get or create singleton instance
                if (_mWl == null)
                {
                    var go = new GameObject("WordList");
                    ThisInstance = go.AddComponent<WordList>();
                }
                return _mWl;
            }

            set
            {
                // If not null then we already have instance
                if (_mWl != null)
                {
                    // If different, then remove duplicate immediately
                    if (_mWl.GetInstanceID() != value.GetInstanceID())
                        DestroyImmediate(value.gameObject);

                    return;
                }

                // If new, then create new singleton instance
                _mWl = value;
                DontDestroyOnLoad(_mWl.gameObject);
            }
        }


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

        // Compare two strings and returns the extent of a match
        // EG: s1 = "hello" and s2 = "helicopter" the result = "hel"
        public static string CompareWords(string s1, string s2)
        {
            // Build resulting string
            var result = string.Empty;

            // Get shortest length
            var shortestLength = Mathf.Min(s1.Length, s2.Length);

            // Check for string match
            for (var i = 0; i < shortestLength; i++)
            {
                if (s1[i] != s2[i])
                {
                    return result;
                }
                result += s1[i];
            }

            // Output result
            return result;
        }
    }
}
