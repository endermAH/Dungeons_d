# Menu scripts
## MenuController.cs
Main menu controller script

### Class `MenuController`

| Method            | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| Start             | private       | -         | Main menu screen          | -                 |
| StartGame         | public        | -         | Initializes the start of the game | -                 | 
| StartMovement     | private       | -         | Starts the main screen swap to game screen           | -                 |                 
| MoveFromTo        | private       | <ul><li>`startPoint` - first point vector coordinate</li><li>`endPoint` - end point vector coordinate</li><li>`duration` - duration</li></ul> | Makes screens swap more gradually | -                 |
| OnMovementEnd     | private       | -         | Ends the main screen swap to game screen             | -                 |
