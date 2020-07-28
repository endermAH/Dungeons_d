﻿# Menu scripts
## MenuController.cs
Main menu controller script

### Class `MenuController`

| Method            | Availability  | Params    | Description               | Return value      |
| :---              | :---          | :---      | :---                      | :---              | 
| Start             | private       | -         | Main menu screen          | -                 |
| StartGame         | public        | -         | Initializes the start of the game | -                 | 
| StartMovement     | private       | -         | Starts the camera movement to player                  | -                 |                 
| MoveFromTo        | private       | <ul><li>`startPoint` - first point vector coordinate</li><li>`endPoint` - end point vector coordinate</li><li>`duration` - duration</li></ul> | Makes camera movement more gradually | -                 |
| OnMovementEnd     | private       | -         | Ends the camera movement             | -                 |
