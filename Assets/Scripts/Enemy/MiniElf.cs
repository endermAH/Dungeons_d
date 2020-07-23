using UnityEngine;

namespace Enemy
{
    public class MiniElf : Enemy
    {
        private void Start()
        {
            Stats = new EnemyStats(10,100);
            currentHealth = Stats.MaxHealth;
            UpdateHealthSlider();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
