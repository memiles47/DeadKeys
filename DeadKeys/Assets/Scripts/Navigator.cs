using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    //Reference to singleton instance
    public static Navigator ThisInstance
    {
        get
        {
            //Get or create singleton instance
            if (mThisInstance == null)
            {
                GameObject GO = new GameObject("Navigator");
                mThisInstance = GO.AddComponent<Navigator>();
            }
            return mThisInstance;
        }
        set
        {
            //If not null then we already have instance
            if (mThisInstance != null)
            {
                //If different, then remove duplicate immediatly
                if (mThisInstance.GetInstanceID() != value.GetInstanceID())
                DestroyImmediate(value.gameObject);
                return;
            }
            //If new, then create new singleton instance
            mThisInstance = value;
        }
    }

    private static Navigator mThisInstance = null;
    private int AnimStateHash = Animator.StringToHash("NavState");

    void Awake()
    {
        ThisInstance = this;
        ThisAnimator = GetComponent<Animator>();
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
