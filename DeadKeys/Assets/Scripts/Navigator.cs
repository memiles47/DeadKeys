using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Navigator : MonoBehaviour
    {
        // Reference to current camera position
        public int CurrentNode;
        private Animator _thisAnimator;
        private int AnimStateHash = Animator.StringToHash("NavState");

        // Reference to navigator button
        private Button _navigatorButton;

        private static Navigator _mThisInstance;


        //Reference to singleton instance
        public static Navigator ThisInstance
        {
            get
            {
                //Get or create singleton instance
                if (_mThisInstance == null)
                {
                    var go = new GameObject("Navigator");
                    _mThisInstance = go.AddComponent<Navigator>();
                }
                return _mThisInstance;
            }
            set
            {
                //If not null then we already have instance
                if (_mThisInstance != null)
                {
                    //If different, then remove duplicate immediatly
                    if (_mThisInstance.GetInstanceID() != value.GetInstanceID())
                        DestroyImmediate(value.gameObject);
                    return;
                }
                //If new, then create new singleton instance
                _mThisInstance = value;
            }
        }


        void Awake()
        {
            ThisInstance = this;
            _thisAnimator = GetComponent<Animator>();
            _navigatorButton = GameObject.FindGameObjectWithTag("NavigatorButton").GetComponent<Button>();
            _navigatorButton.gameObject.SetActive(false);
        }

        public void Next()
        {
            ++CurrentNode;
            _thisAnimator.SetInteger(AnimStateHash, CurrentNode);

        }

        public void Prev()
        {
            --CurrentNode;
            _thisAnimator.SetInteger(AnimStateHash, CurrentNode);
        }

        // Show buttton if there are no remaining enemies
        public void ShowMoveButton()
        {
            // To be defined
            _navigatorButton.gameObject.SetActive(true);
        }
    }
}
