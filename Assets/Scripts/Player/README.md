# Player scripts
## Health.cs
Player's health controller script

### Class `Health`

| Method            | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| Heal              | public        | int count - count of heal   | Add health to player    | -    |
| Damage            | public        | int count - count of damage | Reduce player's health  | -    |
| Death             | public        | -         | Stops the game                            | -    |                 
| Start             | private       | -         | Initialize player's health                | -    |                 
| UpdateHealthBar   | private       | -         | Makes health bar smaller or bigger        | -    |

## Movement.cs
Move controller script

### Class `Movement`

| Method              | Availability  | Params    | Description               | Return value      |
| :---                | :---          | :---      | :---                      | :---              | 
| Start               | private       | -         | Unity base Start method   | -                 |
| Update              | private       | -         | Horizontal or vertical movement controller    | -                 |
| FixedUpdate         | private       | -         | Calculate diagonal movement vector            | -                 |
| AnimationUpdate     | private       | -         | Animate horizontal or vertical movement       | -                 |
| AnimationFixedUpdate| private       | -         | Animate diagonal movement | -                 |

## PlayerStats.cs
Player's stats controller script

### Class `PlayerStats`
| Method              | Availability  | Params    | Description               | Return value      |
| :---                | :---          | :---      | :---                      | :---              | 
| Start               | private       | -         | Unity base Start method   | -                 |
| Update              | private       | -         | Unity base Update method  | -                 |
| LevelUp             | public        | -         | Add one level             | -                 |
| AddExp              | public        | int `count` - count of exp points| Add exp points         | -                 |
| ExpDistributionFunction| private    | int `calcLevel` - current level  | Calculate exp for next level   | int `exp` - exp for next level|
| UpdateExpToNextLevel| private       | -         | Update required amount of exp  | -            |
| UpdateExpDisplay    | private       | -         | Clear exp bar             | -                 |
