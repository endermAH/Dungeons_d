# Chest scripts
## OpenChest.cs
Chest management scripts

### Class `OpenChest`

| Method            | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| Start             | private       | -         | Unity base Start method   | -                 |
| Update            | private       | -         | Unity base Update method  | -                 |
| GetDistance       | private       |<ul><li>`x1` - first point x coordinate</li><li>`y1` - first point y coordinate</li><li>`x2` - second point x coordinate</li><li>`y2` - second point y coordinate</li></ul> | Gets two points and calculates distance  | `double`: distance between two points |                 |
| GetDistanceToChest| private       | -         | Calculates distance from player to chest | `double`: distance from player to chest |
| GenerateChestContains | private   | `maxThings` - maximum tings count in this chest | Generates chests contents | `string[]`: Chests contents | 
| CheckOpen         | private       | -         | Checks distance to Player and pressed key to open chest | - |
| HighlightChest    | private       | -         | Highlight chest if Player is near | - |