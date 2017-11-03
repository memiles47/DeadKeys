using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 100f)]
    private float fValue = 100f;

    //Events called on health change
    public UnityEvent OnHealthExpired;
    public UnityEvent OnHealthChanged;


    public float Value
    {
        get { return fValue; }
        set
        {
            fValue = value;
            OnHealthChanged.Invoke();
            if (fValue <= 0f)
            {
                OnHealthExpired.Invoke();
            }
        }
    }
}
