# Alex Cherry Final Year Project
My 4th Year Project for Software Development in GMIT.

## Entropy
The idea of this game is to create a 3rd person Open World RPG in Unity 3D. The game is split into Singleplayer and Multiplayer. The player will load into the Singleplayer scene at first. While in the mission located in the game they can activate an extra player to help them.

### Map Inspiration for Mission
All credits go to https://elderscrolls.bethesda.net/en/oblivion for map design and https://elderscrolls.fandom.com/wiki/Brush_of_Truepaint for image source
![alt test](readmescreenshots/PaintedWorld.jpg)

The purpose of creating a map without massive graphical quality is that it does not require a lot of artistic skills, as this can take a lot of effort to design. This map inspiration is driven by the fact it still looks very aesthetically appealing even though it is not of high graphic quality.

### Singleplayer
The single player aspect of the game is divided into an RPG style map and a mission that the player has to take on to save an NPC that is located there. 

### Multiplayer 
A server is created with Unity using Photon 2 (One laptop will host). The player character gets duplicated and a seperate client opens for testing purposes. In reality this will be done using another computer.

### AI Partner System
A simple AI is developed to follow the player around and help kill the enemies the player is fighting.

### Combat System
When enemies are in close proximity, the player will take periodic damage. There is also health regeneration so that the player can take on more enemies easily.

### Weapon System
Two weapons are designed (sword and crossbow) that can be swapped whenever the player wants to.

### Skill System
Each weapon has a skill that can be activated which will deal extra damage and have an additional effect on enemies.

### Level and Stat System
A short level system with stats (Attack, Defense, Health) is designed (levels 1 to 5 are designed for Beta). Stats go up when the player levels by defeating enemies.

### Mini Map System
A mini map to track the player, their allies and the enemies is designed for pinpointing. The mini map is done by using a seperate camera that hovers over the player and uses an image and a texture to track the image in real time.



