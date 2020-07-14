using UnityEngine;

namespace Enemy
{
    public class BigRedMonster : Enemy
    {
        private void Start()
        {
            Stats = new EnemyStats(10,1000);
            currentHealth = Stats.MaxHealth;
            UpdateHealthSlider();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
