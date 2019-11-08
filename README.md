# Knight Errant
COMP30019 (Graphics and Interaction) project 2, summer 2019

## Demo
[![](https://i9.ytimg.com/vi/Axmp8RUed1I/hqdefault.jpg?time=1573190060401&sqp=CKjxk-4F&rs=AOn4CLBTuk4Ay7mY7DlcON6TZiB6qIGGgw)](https://youtu.be/Axmp8RUed1I)

## Spec

### Introduction

Knight Errant is a first person shooter game, which aims to reach the destination without losing player’s health value under zero.
There are two ways to lose health:
- Enemy’s attack will cause health lose.
- Fall into water will lose the game. 

And One way to increase your health: 
- Kill enemy

### How to play

- easily use WASD to go forward, backward, move left and right. 
- press space to jump
- press left mouse button to fire your weapon

### Components

- We import the models of weapons, npcs from the Unity Asset Store.
- We use terrain to generate our game map
- We use shader to implement water, and part of the exit gate.

### Graphics pipeline and camera motion:

- For the graphics pipeline, we just used the default Unity rendering pipeline.
- For camera motion, we used a walking metaphor to implement a first person camera motion. We make sure the camera mostly stays at a constant height, and the camera will tilt left and right repeatedly to model the walking effect. The camera can also rotate 360 degrees in the horizontal direction, and 180 degrees in the vertical direction.

### Custom shaders

- For the water shader, we have a basic water texture, and two other textures to add some randomness to the water. We also use time as a parameter to increase the randomness. Overall, we used the bump mapping approach to model the water surface.
- texture shader: put texture on each side of the object.

### Evaluation and feedback

We invited six people from our workshop as the participants. Two of them are domestic students and the others are international students. They are of similar ages to us.

We first let participants walk through the game intuitively. We used “cognitive walkthrough” to evaluate our designs and focused on the feedback that users provide as they play in a “think aloud” way (observational method). After they finished the game, we asked them to give some feedback to gather information on the game control, the user interface and so on. We also use a document to record the feedback and data from our participants.

| Participant                              | Feedback                                                                                                                                                                       |
|------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1                                        | The game map is quite large, and there is no clear indication on what the goal of this game is. If there could be some indications given to me, I will find it less confusing. |
| 2                                        | The game is too easy to win, I can easily dodge the attack from the enemies. Increasing the difficulty of this game can make it more playable.                                 |
| 3                                        | Your game tutorial is quite clear and interactive, and it let player know how to get start of the game right now.                                                              |
| 4 (after increase the number of enemies) | I can only lose my health and there is no way to increase my health, which makes me easily lose the game.                                                                      |
| 5                                        | Enemies are real, and there are different types of enemies, which gradually builds up the challenge, which is wonderful.                                                       |
| 6                                        | The way how you model the exit makes it not obvious that this is the exit of the game. I think you guys should give a clearer indication on the exit.                          |


### Improvements based on feedback

- Game map
Because the original map is too big and there isn’t a clear path designed where the player can follow, which is very confusing. After reimplementing the game map, there is a much clearer path where the player can follow to complete the game, and the difficulty along the path also increases as the player progresses.
- Add numbers and different category of enemies 
Increase the difficulty and variety of this game.
- Add another way of losing health
We made changes to the water, such that players will lose the game immediately if he falls into the water. We also put some bridges on the river to let players cross through the river, which can effectively limit player’s routes and also increase the difficulty of this game.
- Add ways to increase health value to increase the variety of the game.
- We also model the exit based on people’s general intuition on what an exit might look like, so that player will not get confused.

### Reference

- UI scenes: Lab 8
- Texture shader: Lab 3
- NPC movement: https://www.youtube.com/watch?v=RXB7wKSoupI
- SwarmManager: Lab 8
- Water shader: https://catlikecoding.com/unity/tutorials/flow/texture-distortion/
- Player Controller: https://www.youtube.com/watch?v=n-KX8AeGK7E

### Team

- Xiande Wen: contributes a lot on enemies behaviours
- Mingyu Su: contributes a lot on player controller, generating map.
- Yueru Cheng: contributes a lot on UI and shaders.

