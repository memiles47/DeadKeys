using UnityEngine;
using UnityEngine.Events;

public class GameTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerEntered;

    void OnTriggerEnter(Collider Other)
    {
        // If not player then exit
        if (!Other.CompareTag("Player"))
        {
            return;
        }

        OnTriggerEntered.Invoke();
    }
}
