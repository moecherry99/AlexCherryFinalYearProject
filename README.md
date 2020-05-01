
# Entropy
A First-Person Open World RPG developed in Unity.

## Authors : 
[Alex Cherry](https://github.com/moecherry99)

## Project Supervisor : 
[Dr. Dominic Carr](https://github.com/dominiccarr)

### Requirements : 
Windows/Mac/Linux OS, Unity 2018.4.9f1, Visual Studio 2019+.

### Downloading and Running the Application
1. Clone the repository at https://github.com/moecherry99/AlexCherryFinalYearProject into a new folder on your Desktop.
2. Move to the Executables folder and select the .exe file.
3. If you wish to edit, open in Unity v2018.4.9f1, any version of Visual Studio will work for editing code. 

### Table of Contents

* [Introduction](#introduction)
* [Singleplayer](#singleplayer)
* [Multiplayer](#multiplayer)
* [Movement and Looking](#movement-and-looking)
* [Menus and User Interface](#menus-and-user-interface)
* [Combat System](#combat-system)
* [Level and Stat System](#level-and-stat-system)
* [Potion and Chest System](#potion-and-chest-system)
* [Skill System](#skill-system)
* [Mini-Map System](#mini-map-system)
* [Quest System](#quest-system)
* [References](#references)

### Introduction
Entropy is a First-Person Shooter (FPS) that is designed and developed in Unity. The purpose of the game is to design a game with smooth mechanics and implement these mechanics into a full sized game. The game is currently a beta version, as designing a full sized game in a small time frame with one person is almost impossible. Therefore, laying down all 
of the "ground work" and applying all the mechanics to the game means that the game can easily be further developed, such as making new maps for quests and adding new enemies in with new stats. These items proved easy compared to making the actual mechanics of the game, so a large sense of fulfilment was acquired with the development of the project.

### File Strucure 
![alt file](readmescreenshots/FileStructure.PNG)  

![alt scripts](readmescreenshots/ScriptsStructure.PNG)  

Include repo contents (folders seen on github)

### Map Inspiration for Mission
All credits go to [Bethesda](#references) for Map Design and Inspiration.  
![alt test](readmescreenshots/PaintedWorld.jpg)

The purpose of creating a map without massive graphical quality is that it does not require a lot of artistic skills, as this can take a lot of effort to design. This map inspiration is driven by the fact it still looks very aesthetically appealing even though it is not of high graphic quality.

### Singleplayer
The single player aspect of the game is divided into an Open World RPG style map and a mission that the player has to take on to save an NPC that is located in the mission area. The first area holds a few enemies that can be killed before entering the mission area so that they can get a feel for the games mechanics.

### Multiplayer 
A server is created with Unity using [Photon 2](#references). The players character gets duplicated and the second player can play with the main camera focused on their character. (This function is not working due to the deadline being during the COVID-19 pandemic of 2020. Access to another machine was prohibited and it was not able to be tested from a singular machine and proved difficult).

#### Photon 2 Engine
In order for Photon 
All credits go to [Photon](#references) for this image.  
![alt photon](readmescreenshots/ServerClientModel.png)  

### Movement and Looking

#### Movement
A basic movement system is implemented into the game for the player. The W, A, S and D keys are used to move the player according to the direction on the keyboard. Arrow keys can also be used, as implemented by Unitys basic input tools. The player can jump using the space key, and gravity is applied to the jumping mechanic for a realistic feel.

#### Looking
A "**Mouse Lock**" system is implemented into the game as well. Once the game is loaded up, the mouse will lock to the middle of the screen. This gives the camera free access to the players mouse control, therefore making the character look wherever the player moves the mouse. This is quite a smooth system and works very well.

```
void Start()
{
  // get camera component
  cam = GetComponent<Camera>();

  // Locks Cursor to middle of screen
  Cursor.lockState = CursorLockMode.Locked;
}
```

Whenever the mouse must be unlocked, for example in the pause menu when the player presses the escape key, the "**.Locked**" variable must be changed to "**.None**". Controlling the mouse this way gives the game a smooth experience.

### Menus and User Interface
Update this section

### Combat System
The enemies around the map will attack the player when they are in close proximity. They deal damage over time, and all have different values depending on the types of enemies. There are two main types : 

1. **Zombies**
2. **Skeletons**

**Skeletons** have 4 different types to them : **Small**, **Medium**, **Large** and **Boss**. These increase in size to differentiate them from eachother. They also have different health values and damage values for difficulty variance. 

**Zombies** have 2 different types to them : **Small** and **Medium**. These work the same as the Skeleton enemies. They are slightly tougher in comparison to the Skeletons however, as they are considered "mini-bosses". 

All of these files can be found at the [Controllers](https://github.com/moecherry99/AlexCherryFinalYearProject/tree/master/FinalYearProjectEntropy/Assets/Scripts/Controllers) directory, showing the variations between enemy stats.

If the player happens to die to an enemy or enemies, all of the remaining enemies will have their health restored to full health. This creates a certain difficulty to the bosses in the game, and prevents the player from just respawning and killing their enemy. It creates an emphasis on "grinding", which means to kill enemies repeatedly in this case, and gain more experience to level up. More details on leveling up is described in the [Level and Stat System](#level-and-stat-system) section.

### Level and Stat System
A leveling system is designed in the game. The player has a certain experience value, and every time they defeat an enemy they will gain experience. Depending on the type of monster such as Skeletons, Zombies and their sizes, the player will gain less or more experience. There are 10 levels designed for the game, and the player has 3 stats to accompany this level : 
1. **Health** : A base value of 250 health is in the game, and this will increment by 30 every time the player gains a level. This is useful for survivability.

2. **Damage** : The player has a base damage value, which will let the player deal a certain amount of damage to enemies. The higher the players damage, the more damage they deal with attacks. The Drain Attack is also affected by this variable, and is enhanced even more than the basic attacks if the player decides to level up. This Attack is described below in the "Skill System" section of this file.

3. **Defense** : The player has a base defense value, which will reduce the damage an enemy does to them. This works by dividing the damage variable of the enemy by the defense stat of the player. This gives the player a great incentive to level up before taking on harder enemies.

Here is a quick code snippet on what actually happens when the player levels up : 

```
    public void LevelUp()
    {
        // get variables to increase stats
        PlayerHealthScript.maxHealth += 30;
        PlayerHealthScript.currentHealth += 30;
        PlayerHealthScript.damage += 8;
        PlayerHealthScript.defense += 2;

        // set max health properly
        HealthBarScr.maxHp += PlayerHealthScript.maxHealth;
    }
```

It is relatively easy to understand what is happening here. Each of the variables in the [PlayerHealthScript](https://github.com/moecherry99/AlexCherryFinalYearProject/tree/master/FinalYearProjectEntropy/Assets/Scripts/CombatScripts/PlayerHealthScript.cs) get increased accordingly. 

It is necessary for the player to level up to complete the game due to the way the defense variable works. As it is divided by the enemies damage, it creates great advantages for the player, but if the player is too low of a level they will die too quickly in certain sections.

### Potion and Chest System
Potions can be used by the player to increase their current health. In order for potions to be used, the player must have some in their inventory first. Potions are obtained by either killing monsters, leveling up, completing [Quests](#quest-system) or by hitting chests. Chests are scattered around the two areas and can be attacked to give the player 5 potions. Players can use potions by pressing the '**E**' key.

``` 
if (Input.GetKeyDown(KeyCode.E))
{
    // if more than 1 potion, call UsePotion
    if (potionCount > 0)
    {
        UsePotion();
        SoundManagerScript.PlaySound("Potion");
    }

    // if 0 potions or max health, call DontUsePotion and do nothing
    if (potionCount == 0)
    {
        DontUsePotion();
    }

}
```

In this code snippet we can see that when the "**potionCount**" variable is above 0, a potion can be used. If it is 0, a function returning null is called and there will be no effect. It will also play the sound effect for the potion noise. The **UsePotion()** function is called, which is shown below.

```
// call this function if potion count is over 1
    public void UsePotion()
    {
        if (potionCount >= 1)
        {           
            currentHealth += 20 + (PlayerExperience.level * 2);
            healthBar.SetHealth(currentHealth);
            potionCount--;
        }

        if (potionCount <= 0)
        {
            potionCount = 0;
        }
        
        // set health
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
```

The health of the player is restored by 20 plus the level of the player multiplied by 2. **For example** : The players level is 4, if they use a potion at this level they will heal 20 + (4 x 2) health, equaling 28 health. This is so that potions will not lose their effectiveness the higher the level of the player. This is an important game balance issue that was addressed as bug testers had no incentive to keep leveling due to this. Calling this function will deduct 1 potion from the potion count.

### Skill System
The weapon in the game has a skill that can be activated with the keyboard shortcut '**R**'. This has a cooldown of 3 seconds when used, and will drain the health of an enemy and deal more damage to it, giving the player 25 health every time it is used. This is done by simply adding the health to the players stat and updating the health bar slider variable. The cooldown works in the way that every time it is activated, the key can't be pressed again until the timer of 3 seconds bypasses. There is a text object in the games UI that symbolizes this as well, so it will notify the player when the "**Drain Skill**" is ready to be used. 

```
if (Input.GetKeyDown(KeyCode.R))
{
      currentHealth += 25;
      healthBar.SetHealth(currentHealth);
      nextAttackTime = Time.time + 12f / attackRatePower;
      cdTimer.GetComponent<UnityEngine.UI.Text>().text = "Skill : Not Ready";
      if (currentHealth >= maxHealth)
      {
          currentHealth = maxHealth;
          nextAttackTime = Time.time + 12f / attackRatePower;
      }
}
```

We can see in the code snippet that you can only press the R key when the time has elapsed for the cooldown. Once this occurs, the **PowerAttack()** function plays in another script, which will absorb the health and deal extra damage. The **currentHealth** variable raises by 25, showing this health increase for the player.

### Mini Map System
A basic mini map function is designed for the player. It is done by creating a seperate camera, which will hover over the player and change direction as well depending on where the player is facing. This is handy for pinpointing enemies, and due to the way the lighting system works in the game, it can become even more accurate for the player. The code snippet for this is featured below : 

```
void LateUpdate() 
{
    Vector3 newPosition = player.position;
    newPosition.y = transform.position.y;
    transform.position = newPosition;

    // for camera to rotate with player
    transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
}
```

The **LateUpdate()** function is used as it must be called after the **Update()** function has been called. The reason this must be done is because the player moves and the main camera updates, but we can't simultaneously update another camera to match it perfectly. It is about 1 frame behind, meaning it has time to adjust to the sudden movements the player might do. It must be updated after the player moves as it is following those movements. This helps reduce the lag in the game as well, and allows for better frame rate.

### Quest System
In the game there is a single quest that the player can activate. The objective of the game is to "Find NPC(Non-Playable-Character) Toland". Once the player has found the NPC, they can proceed with the quest. They are teleported into the mission area, and are given the task to eliminate all of the enemies and save the other NPC. Once the quest is finished, the player can return to Toland and receive experience and potions. This is to aid the player in future quests that may be implemented into the game. 

The quest system also makes use of the User Interface elements frequently. Every time an action is done in the game involving the NPCs, the current objective must be updated for the player so that they know what they are doing or what they need to do next. 

```
 if (active == true)
{
    if(Input.GetKeyDown(KeyCode.KeypadEnter))
    {
        text.GetComponent<UnityEngine.UI.Text>().text = "Current Objective : Rescue the hostage! (Enter to return after death)";
        areaText.GetComponent<UnityEngine.UI.Text>().text = "Area : Skeleton's Labyrinth";
        Move2();
        active = false;
    }
}
```

This code basically says if the player hits the '**Enter**' key on their keyboard, they will move with the **Move2()** function which will transport the player. The main thing to note here though is that the **text.GetComponent<UnityEngine.UI.Text>().text** element is being changed in this if statement. This changes two text elements : The objective text and the area text. This is a perfect example of how the UI elements are manipulated by key presses for the quest system.

### Conclusion

### References
[1] [Map Inspiration](https://elderscrolls.bethesda.net/en/oblivion) - For inspiration on the designed map  
[2] [Photon Engine](https://www.photonengine.com/) - Photon Engine for Multiplayer design  
[3] [Photon Diagram](https://doc.photonengine.com/zh-tw/bolt/current/in-depth/server-client-model) - A diagram for the Photon Engine layout and how clients connect to eachother.
[Back to top.](#entropy)


