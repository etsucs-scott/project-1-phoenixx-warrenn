-- Phoenix Warren

-- CSCI 1260-002: Object-Oriented Programming

-- Spring 2026



This project is a simple, console-based adventure maze game built with Visual Studio's C# and .NET. The player navigates through a randomly generated maze while fighting monsters, collecting items, and attempting to reach the exit tile.

This follows a layered architecture where all game rules and domain logic live inside the Core library, while the Console project handles input and output only.



Enjoy :))







---------------------



***CONTROLS***:

W/Up Arrow = Up

A/Left Arrow = Left

S/Down Arrow = Down

D/Right Arrow = Right



***DISPLAY SYMBOLS***:

\# = Wall

. = Empty Space

@ = Player

M = Monster

W = Weapon

P = Potion

E = Exit



***GAME RULES:***

Player starts with 100 HP (Max HP = 150)



Base damage = 10



Monsters have random health between 30–50 HP



Potions heal +20 HP instantly



Weapons get stored in inventory \& the highest modifier adds to attack damage



***BATTLE SYSTEM***:



Battle is turn-based:



**Player** attacks first

Damage = Base Damage + Best Weapon Modifier

**Monster** counterattacks if alive

Battle continues until one reaches ***0 HP***

**Player** death ends the game

**No fleeing allowed!!!**

