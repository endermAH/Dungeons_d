using UnityEngine;

namespace Enemy
{
    public class BigRedMonster : Enemy
    {
        private void Start()
        {
            Stats = new EnemyStats(
                damage: 10,
                maxHealth: 1000,
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
