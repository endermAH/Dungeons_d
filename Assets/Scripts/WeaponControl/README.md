﻿# Weapon scripts
## Weapon.cs
Weapon stats and description 

### Struct `WeaponStats`
Fields: Name - name of weapon; Damage - damage parameter; AttackCooldown - weapon's cooldown parameter

| Constructor       | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| WeaponStats       | public        | <ui><li>float `attackCooldown`</li><li>float `damage`</li><li>string `name`</li></ui>| Gets weapon name, damage and cooldown | -              |

### Struct `Weapon`
Fields: WeaponStats - name, damage and cooldown; Vector3 HandPosition - weapon's size in hand; Weapon[] All - array of weapon

| Constructor       | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| Weapon            | private       | <ui><li>HandPosition `handPosition`</li><li>WeaponStats `stats`</li></ui>| Gets weapon stats and size in hands | -              |

## WeaponAnimationController.cs
Animation controller script

### Class `WeaponAnimationController`

| Method            | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| Start             | private       | -         | Initialize weapon params  | -                 | 
| Update            | private       | -         | Unity base Update method  | -                 | 
| KeepPosition      | private       | -         | Attaches the weapon model to the player's model  | -                 | 
| OnAttack          | public        | -         | Plays attack animation when the player attacks   | -                 | 

## WeaponAttackController.cs
Attack controller script

### Class `WeaponAttackController`

| Method            | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| Update            | private       | -         | Attack button controller  | -                 | 
| StartAttack       | public        | -         | Do attack                 | -                 | 
| Attack            | private       | -         | Attack cooldown           | -                 |