using UnityEngine;

namespace Assets.Scripts
{
    public class UIHealth : MonoBehaviour
    {
        private Health _playerHealth;
        private RectTransform _thisTransform;

        // Use this for initialization
        void Awake()
        {
            var go = GameObject.FindGameObjectWithTag("Player");
            _playerHealth = go.GetComponent<Health>();
            _thisTransform = GetComponent<RectTransform>();
        }

        // Update is called once per frame
        void UpdateHealth()
        {
            // Update player health
            _thisTransform.sizeDelta = new Vector2(_playerHealth.Value, _thisTransform.sizeDelta.y);
        }
    }
}
