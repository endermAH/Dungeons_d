﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponControl
{
    public class WeaponAttackController : MonoBehaviour
    {
        public UnityEvent attackEvent;
        public bool onCooldown;

        public Weapon currentWeapon = Weapon.RegularSword;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!onCooldown) attackEvent.Invoke();//StartCoroutine(AnimateWeapon());
            }
        }

        public void StartAttack()
        {
            StartCoroutine(Attack());
        }
    
        private IEnumerator Attack()
        {
            
            onCooldown = true;
            
            yield return new WaitForSeconds(0.2f); //Wait few seconds to animation completes
            yield return new WaitForSeconds(currentWeapon.Stats.AttackCooldown);

            onCooldown = false;
        
        }
    
    }
}
