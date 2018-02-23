using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager mGM;
    public int Score = 0;
    public int BonusLevel = 0;

    public static GameManager ThisInstance
    {
        get
        {
            //Get or create singleton instance
            if (mGM == null)
            {
                GameObject GO = new GameObject("GameManager");
                mGM = GO.AddComponent<GameManager>();
            }

            return mGM;
        }

        set
        {
            //If not null then we already have instance
            if (mGM != null)
            {
                //If different, then remove duplicate immediately
                if (mGM.GetInstanceID() != value.GetInstanceID())
                    DestroyImmediate(value.gameObject);

                return;
            }

            //If new, then create new sinleton instance
            mGM = value;
            DontDestroyOnLoad(mGM.gameObject);
        }
    }

    // Use this to initialize
    public void Awake()
    {
        ThisInstance = this;
    }
}
