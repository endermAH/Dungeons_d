# Enemy scripts
## Enemy.cs
Parent class for enemies

### Struct `EnemyStats`
Fields: int Damage, int MaxHealth

| Constructor       | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| EnemyStats        | public        | <ui><li>int `Damage`</li><li>int `MaxHeahth`</li></ui>| Initialized enemy's damage and max health | -    |


### Abstract class `Enemy`

| Method            | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| OnTriggerEnter2D  | private       | Collider2D other - Collider of the object that was collided with | Calls 'get damage event' if enemy model collides with weapon   | -    |
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