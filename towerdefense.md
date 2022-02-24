#   TOWER DEFENSE

##  TODO - OverView
+   Moodboard
+   Grid Spawing
+   Path generation
    +   Path maker
    +   Path loader
+   Camera Control
+   Building placing
    +   Placing in grid
    +   Preview placement
-   Enemy spawing
    +   Movement
    -   animation
+   Turret Attack
    +   hit enemy
    +   visualize attack
-   Level Details
    -   Inner bound
    -   Outer bound
+   UI
    +   Buttons
    +   Weapon CD
-   Tower/Base
    +   Take damage
    -   Gameover

##  Fixes
-   Update levelSO to hold
    -   Number of waves
    -   Time between waves
    -   Number of enemies per wave
    -   Distribution of enemies
-   Create ammo system for shooting
-   Display health over enemies
-   Display health over turrets
+   Stop preview when hovering over objects
+   Display Tower health
+   Show currently selected turret for placement
+   Fix ray cast so it isn't based on mouse position

##  Enemy types
+   Basic boi
    +   Hp = 10
    +   Atk = 1
+   Tanky boi
    +   Hp = 20
    +   Atk = 0
+   Spiky boi
    +   Hp = 5
    +   Atk = 5

##  Turret types
+   Round boi
    +   Hp = 10
    +   Atk 2
+   Linear boi
    +   Hp = 10
    +   Atk = 5