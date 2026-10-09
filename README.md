I'm not going to lie, I'm not sure how to feel about this exam.

Resources will be at the end.
----------------------------------------------

For Object Oriented programming I was able to incorperate:
- Encapsulation: using setters and getters for player and enemy classes.
- Inheritance: I planned on using this for multiple enemies, but scrapped it for the bubble spawner as it inherits from the Base_Factory class.
- Polymorphism: Polymorphism is used to override the abstract SpawnBubble() class inside of Base_Factory and spawn a bubble.

----------------------------------------------

For Singleton I utilized a system I had previously designed to unlock trophies over time. This is displayed in the console (Ran out of time trying to incorporate base games)

Basically, The manager captures the game start time, close time, and run time. if the run time is longer than the required time to unlock the trophies. They unlock.

** As a side note, I didn't have time to change the script name, so this functionality will be saved under "GameManager" though you could consider it a Trophy Manager instead

----------------------------------------------

For Factory design, I chose to use the spawning system in order to spawn the bubble. The idea was to allow different bubble types while abstracting the bubble prefabs.

The bubble will currently not move as I didn't put a rigid body on it. And it will not delete from the scene as I didn't get a chance to write the code for it. 

A future idea was to implement an object pooling system into the game in order to improve performance, by changing Instantiate to relocating an inactive bubble, Unity no longer has to destroy and reinstantiate new bubbles. This was out of scope.

----------------------------------------------

RESOURCES USED:
Previous Projects;
- Utilized player movement code, 
- MOST input system code with some changes to the input manager discussed below, 
- trophy manager, 
- factory and singleton frameworks from previous projects.

    - For the enemy script, I planned on having the enemies move between two patrol points and deal damage on contact. this isn't working because I only have two cases in which if the enemy is at one patrol point it changes to the next one.  and it doesn't start at the patrol points. 

        - To fix this, I would add a transform and call it _target so that when the enemy reaches its target, it will set _target to the next patrol point and continue from there.

    - For the player script, I changed the way movement works from full WASD movement to AD movement and Space to jump. This also required adding an Input Action for jumping.

    - For the singleton, I planned on adding new trophies for enemy kills, deaths, and maybe even highscore. I quickly realized this was out of scope for the midterm.

    - For the factory, I planned on using particle spawners for bubble effects, and a blood splatter for killing enemies. I again, realized this was way out of scope for the project and canned it for spawning the bubble 
        - (I previously planned to use it as an enemyspawner to get that 80% but realized that spawning projectiles might get me a higher mark than an enemy spawner).

    - The frameworks for factory and singleton are taken from the ASYNC lectures