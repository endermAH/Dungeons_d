using UnityEngine;

namespace Enemy
{
    public class MiniElf : Enemy
    {
        private void Start()
        {
            Stats = new EnemyStats(
                damage: 10, 
                maxHealth: 100,
                speedFactor: 33
                );
            currentHealth = Stats.MaxHealth;
            UpdateHealthSlider();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
