using System;
using UnityEngine;

namespace Enemy
{
    public struct EnemyStats
    {
        public int Damage;
        public int MaxHealth;

        public EnemyStats(int damage, int maxHealth)
        {
            Damage = damage;
            MaxHealth = maxHealth;
        }
    }
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] public EnemyStats Stats;
        public int currentHealth;
        private void Start()
        {
            currentHealth = Stats.MaxHealth;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            print("Enemy Damaged");
        }
    }
    
}
