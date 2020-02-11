# Alex Cherry Final Year Project
My 4th Year Project for Software Development in GMIT.

## Entropy
The idea of this game is to create a 3rd person Open World RPG in Unity 3D. The game is split into Singleplayer and Multiplayer. The player will load into the Singleplayer scene at first. They can pause the game and choose a mission from here which is done in Multiplayer.

### Map Inspiration 
All credits go to https://elderscrolls.bethesda.net/en/oblivion for map design and https://elderscrolls.fandom.com/wiki/Brush_of_Truepaint for image source
![alt test](readmescreenshots/PaintedWorld.jpg)

The purpose of creating a map without massive graphical quality is that it does not require a lot of artistic skills, as this can take a lot of effort to design. This map inspiration is driven by the fact it still looks very aesthetically appealing even though it is not of high graphic quality.

### Singleplayer
The singleplayer will be pretty straight forward. Just npcs that give quests, kill monsters, kill count goes up, collect reward, level up (max level 5 for easy testing purposes) with stat page.

### Multiplayer 
Will create a server with Unity using Photon 2 (One laptop will host). Testing purposes will be done on same computer with two Unity clients at first, and secondly will be done with a second laptop. The Multiplayer testing can be done with two characters on the same client, with each operating with different Keys (WASD for player 1 and IJKL for player 2).

### AI Partner System
A simple AI is developed to follow the player around and help kill the enemies the player is fighting.

### Class System
Two different classes will be designed, one with ranged attacks and one with melee attacks. You can choose between them (Warrior and Archer) at the beginning scene of the game. Your player will be either red or green depending on which one you choose.

### Skill System
Each of the two classes have their own attack styles and can use different skills which are better against certain AI.

### Level and Stat System
A short level system with stats (Attack, Defense, Health) is designed (levels 1 to 5 are designed for Beta). Stats go up when the player levels by defeating enemies.

### Mini Map and Compass System
A mini map to track the player, their allies and the enemies is designed for pinpointing. A compass on the top of the screen is also designed and serves the same purpose except it has accurate measurements for precise communication between players. The mini map is done by using a seperate camera that hovers over the player and uses an image and a texture to track the image in real time.



