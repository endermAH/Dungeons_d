using UnityEngine;

namespace WeaponControl
{
    public readonly struct Weapon
    {
        public Vector3 HandPosition { get; }
        public float AttackCooldown { get; }

        public static Weapon RegularSword = new Weapon(0.5f, new Vector3(0,4,-2));
        public static Weapon[] All;

        private Weapon(float attackCooldown, Vector3 handPosition)
        {
            HandPosition = handPosition;
            AttackCooldown = attackCooldown;
        }

    }
}
