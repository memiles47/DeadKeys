using System.Collections;
using UnityEngine;

public class UIHealth : MonoBehaviour
{
    private Health PlayerHealth;
    private RectTransform ThisTransform;

    // Use this for initialization
    void Awake()
    {
        GameObject GO = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = GO.GetComponent<Health>();
        ThisTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void UpdateHealth()
    {
        // Update player health
        ThisTransform.sizeDelta = new Vector2(PlayerHealth.Value, ThisTransform.sizeDelta.y);
    }
}
