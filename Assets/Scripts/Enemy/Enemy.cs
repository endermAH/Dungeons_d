using System;
using Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WeaponControl;

namespace Enemy
{
    [Serializable] public class GetDamageEvent : UnityEvent<GameObject> { } 
    public struct EnemyStats
    {
        public int Damage;
        public int MaxHealth;
        public int SpeedFactor;

        public EnemyStats(int damage, int maxHealth, int speedFactor)
        {
            Damage = damage;
            MaxHealth = maxHealth;
            SpeedFactor = speedFactor;
        }
    }
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] public GetDamageEvent getDamageEvent;
        public Slider healthSlider;
        public EnemyStats Stats;
        public int currentHealth;
            
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out WeaponAttackController weaponAttackController))
                getDamageEvent.Invoke(other.gameObject);
        }

        public void OnGetDamage(GameObject damageDealer)
        {
            damageDealer.TryGetComponent(out WeaponAttackController weaponAttackController);
            damageDealer.TryGetComponent(out WeaponAnimationController animationController);
            currentHealth -= Mathf.RoundToInt(weaponAttackController.currentWeapon.Stats.Damage);
            // print($"Enemy Damaged: \nCurrent Health: {currentHealth}\nDamage: {damage}");
            if (currentHealth <= 0) Death();
        }

        private void Death()
        {
            var players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                var playerStats = player.GetComponent<PlayerStats>();
                playerStats.AddExp(30);
            }
            Destroy(gameObject);
        }

        public void UpdateHealthSlider()
        {
            healthSlider.value = (float) currentHealth / Stats.MaxHealth;
        }
    }

}
