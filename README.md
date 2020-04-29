
# Entropy - A 1st person Open World RPG developed in Unity.

## Authors : 
**Alex Cherry**

### Requirements : 
Windows/Mac/Linux OS, Unity 2018.4.9f1, Visual Studio 2019+.

### Downloading and Running the Application
1. Clone the repository at https://github.com/moecherry99/AlexCherryFinalYearProject into a new folder on your Desktop.
2. Move to the Executables folder and select the .exe file.
3. If you wish to edit, open in Unity v2018.4.9f1, any version of Visual Studio will work for editting code. 

### Table of Contents

* [Singleplayer](#singleplayer)
* [Multiplayer](#multiplayer)

### Introduction
Explain entropys purpose and architecture, explain the directory here as well for informative use (like TOA proj).

### Map Inspiration for Mission
All credits go to https://elderscrolls.bethesda.net/en/oblivion for map design and https://elderscrolls.fandom.com/wiki/Brush_of_Truepaint for image source
![alt test](readmescreenshots/PaintedWorld.jpg)

The purpose of creating a map without massive graphical quality is that it does not require a lot of artistic skills, as this can take a lot of effort to design. This map inspiration is driven by the fact it still looks very aesthetically appealing even though it is not of high graphic quality.

### Singleplayer
The single player aspect of the game is divided into an RPG style map and a mission that the player has to take on to save an NPC that is located there. 

### Multiplayer 
A server is created with Unity using Photon 2 (One laptop will host). The players character gets duplicated and the second player can play with the main camera focused on their character. (This function is not working due to the deadline being during the COVID-19 pandemic of 2020. Access to another machine was prohibited and it was not able to be tested from a singular machine and proved difficult).

### Movement

### Combat System
The enemies around the map will attack the player when they are in close proximity. They deal damage over time, and all have different values depending on the types of enemies. There are two main types : 

1. Zombies
2. Skeletons

Skeletons have 4 different types to them : Small, Medium, Large and Boss. These increase in size to differentiate them from eachother. They also have different health values and damage values for difficulty variance. 

Zombies have 2 different types to them : Small and Medium. These work the same as the Skeleton enemies. They are slightly tougher in comparison to the Skeletons however, as they are considered "mini-bosses".

If the player happens to die to an enemy or enemies, all of the remaining enemies will have their health restored to full health. This creates a certain difficulty to the bosses in the game, and prevents the player from just respawning and killing their enemy. It creates an emphasis on "grinding", which means to kill enemies repeatedly in this case, and gain more experience to level up. More details on leveling up is described in the "Level and Stat System" section. <- create link for that


### Level and Stat System
A leveling system is designed in the game. The player has a certain experience value, and every time they defeat an enemy they will gain experience. Depending on the type of monster such as Skeletons, Zombies and their sizes, the player will gain less or more experience. There are 10 levels designed for the game, and the player has 3 stats to accompany this level : 
1. Health : A base value of 250 health is in the game, and this will increment by 30 every time the player gains a level. This is useful for survivability.

2. Damage : The player has a base damage value, which will let the player deal a certain amount of damage to enemies. The higher the players damage, the more damage they deal with attacks. The Drain Attack is also affected by this variable, and is enhanced even more than the basic attacks if the player decides to level up. This Attack is described below in the "Skill System" section of this file.

3. Defense : The player has a base defense value, which will reduce the damage an enemy does to them. This works by dividing the damage variable of the enemy by the defense stat of the player. This gives the player a great incentive to level up before taking on harder enemies.

It is necessary for the player to level up to complete the game due to the way the defense variable works. As it is divided by the enemies damage, it creates great advantages for the player, but if the player is too low of a level they will die too quickly in certain sections.

### Skill System
The weapon in the game has a skill that can be activated with the keyboard shortcut 'R'. This has a cooldown of 3 seconds when used, and will drain the health of an enemy and deal more damage to it, giving the player 25 health every time it is used. This is done by simply adding the health to the players stat and updating the health bar slider variable. The cooldown works in the way that every time it is activated, the key can't be pressed again until the timer of 3 seconds bypasses. There is a text object in the games UI that symbolizes this as well, so it will notify the player when the "Drain Skill" is ready to be used.

### Mini Map System
A basic mini map function is designed for the player. It is done by creating a seperate camera, which will hover over the player and change direction as well depending on where the player is facing. This is handy for pinpointing enemies, and due to the way the lighting system works in the game, it can become even more accurate for the player.
(definitely a picture of mini map here with light in it).

### Quest System

### Something else, maybe 2-3 more sections 
(this whole doc needs to be 10 pages ish)



### References at end





