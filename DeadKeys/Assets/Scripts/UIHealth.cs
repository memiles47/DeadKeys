using UnityEngine;

namespace Assets.Scripts
{
    public class UIHealth : MonoBehaviour
    {
        private Health _playerHealth;
        private RectTransform _thisTransform;

        public void Awake()
        {
            var go = GameObject.FindGameObjectWithTag("Player");
            _playerHealth = go.GetComponent<Health>();
            _thisTransform = GetComponent<RectTransform>();
        }

        // UpdateHealth is called when needed
        public void UpdateHealth()
        {
            // Update player health
            _thisTransform.sizeDelta = new Vector2(_playerHealth.Value, _thisTransform.sizeDelta.y);
        }
    }
}
