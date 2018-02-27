using UnityEngine;
using UnityEngine.Events;

public class GameTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerEntered;

    public void OnTriggerEnter(Collider other)
    {
        // If not player then exit
        if (!other.CompareTag("Player"))
        {
            return;
        }

        OnTriggerEntered.Invoke();
    }
}
