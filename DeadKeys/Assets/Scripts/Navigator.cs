using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Navigator : MonoBehaviour
{
    // Reference to current camera position
    public int CurrentNode = 0;
    private Animator ThisAnimator = null;
    private int AnimStateHash = Animator.StringToHash("NavState");

    // Reference to navigator button
    private Button NavigatorButton = null;

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

    void Awake()
    {
        ThisInstance = this;
        ThisAnimator = GetComponent<Animator>();
        NavigatorButton = GameObject.FindGameObjectWithTag("NavigatorButton").GetComponent<Button>();
    }

    public void Next()
    {
        ++CurrentNode;
        ThisAnimator.SetInteger(AnimStateHash, CurrentNode);

    }

    public void Prev()
    {
        --CurrentNode;
        ThisAnimator.SetInteger(AnimStateHash, CurrentNode);
    }

    // Show buttton if there are not remaining enemies
    public void ShowMoveButton()
    {
        // To be defined
        NavigatorButton.gameObject.SetActive(true);
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
