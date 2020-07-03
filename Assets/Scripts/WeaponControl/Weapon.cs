using UnityEngine;

namespace WeaponControl
{
    public readonly struct WeaponStats
    {
        public readonly float AttackCooldown;
        public readonly float Damage;
        public readonly string Name;

        public WeaponStats(float attackCooldown, float damage, string name)
        {
            AttackCooldown = attackCooldown;
            Damage = damage;
            Name = name;
        }
    }
    public readonly struct Weapon
    {
        public Vector3 HandPosition { get; }
        public WeaponStats Stats { get; }

        public static Weapon RegularSword = new Weapon(
            new Vector3(0,4,-2), 
            new WeaponStats(0.5f, 100f, "Regular sword"));
        
        public static Weapon[] All = {RegularSword};

        private Weapon(Vector3 handPosition, WeaponStats stats)
        {
            HandPosition = handPosition;
            Stats = stats;
        }

    }
}
