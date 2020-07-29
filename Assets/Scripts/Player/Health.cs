using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Player
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
    
        private int _maxHealth;
        private float _currentHealth;

        public bool IsAlive => _currentHealth > 0;

        public void Heal(int count)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + count, 0, _maxHealth);
        }

        public void Damage(int count)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - count, 0, _maxHealth);
            UpdateHealthBar();
            if (_currentHealth <= 0)
            {
                this.Death();
            }
        }

        public void Death()
        {
            // Destroy(gameObject);
            print("Death");
            SceneManager.LoadScene("Scenes/level1", LoadSceneMode.Single);
        }

        private void Start()
        {
            _maxHealth = GetComponent<PlayerStats>().maxHealth;
            _currentHealth = _maxHealth;
            UpdateHealthBar();
            print("Health module initialized");
        }

        private void UpdateHealthBar()
        {
            healthBar.value = _currentHealth / _maxHealth;
        }
    }
}
