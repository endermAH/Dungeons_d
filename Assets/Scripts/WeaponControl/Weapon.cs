using UnityEngine;
using Lang = Languages.Languages;
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
            new Vector3(-4,6,-2), 
            new WeaponStats(0.5f, 100f, Lang.RegularSword.Name.ToString()));
        
        public static Weapon[] All = {RegularSword};

        private Weapon(Vector3 handPosition, WeaponStats stats)
        {
            HandPosition = handPosition;
            Stats = stats;
        }

    }
}
