using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        [Range(0f, 100f)]
        private float _fValue = 100f;

        //Events called on health change
        public UnityEvent OnHealthExpired;
        public UnityEvent OnHealthChanged;


        public float Value
        {
            get { return _fValue; }
            set
            {
                _fValue = value;
                OnHealthChanged.Invoke();
                if (_fValue <= 0f)
                {
                    OnHealthExpired.Invoke();
                }
            }
        }
    }
}
