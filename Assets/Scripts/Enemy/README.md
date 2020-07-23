# Enemy scripts
## Enemy.cs
Parent class for enemies

### Abstract class `Enemy`

| Method            | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| OnTriggerEnter2D  | private       | Collider2D other - Collider of the object that was collided with      | Switches the enemy's attention to the player   | -    |
| OnGetDamage       | public        | GameObject damageDealer - Source of damage | Gets damage from some source  | -    |
| Death             | private       | -         | Destroy enemy's object                 | -    |                 
| UpdateHealthSlider| public        | -         | Refresh health bar                     | -    |

## BigRedMonster.cs
Red Monster's attributes and behavior

### Class `BigRedMonster`

| Method            | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| Start             | private       | -         | Unity base Start method   | -                 |
| Update            | public        | -         | Unity base Update method  | -                 |