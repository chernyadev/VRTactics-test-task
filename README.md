# VRTactics Test Project

[![Auto Tests](https://github.com/chernyadev/VRTactics-test-task/actions/workflows/auto-tests.yml/badge.svg?branch=develop)](https://github.com/chernyadev/VRTactics-test-task/actions/workflows/auto-tests.yml)

VRTactics test task.

Based on the template: https://github.com/VRTactics/test-task.

## Project Description

The player is spawned in the scene with several enemies. The player has to accomplish several goals:
- Reach destination "B" point, starting at the "A" point
- Find all enemies
- Survive, i.e. avoid attacks of the enemies.

When the game is finished the user can inspect his/her results. The overall `victory`/`defeat` status is shown. It is followed by detailed information about enemies' detection status.

## Gameplay Configuration

Some gameplay parameters could be easily configured in the Unity editor.
- #### Behaviour of enemies
  Adjust serialized properties of behavioral states located at `Assets/VRTactics/ScriptableObjects/FSM/`.
  
  ![image](https://user-images.githubusercontent.com/25583587/134886850-0445f9e9-8773-4c38-856b-fcdfc757b4bb.png)
  
- #### Game goals
  See `GameManager` and configure stated game goals via references to scriptable objects.
  
  ![image](https://user-images.githubusercontent.com/25583587/134887250-dc8e5952-a622-4536-a5ef-c91440efdefd.png)

- #### Amount of enemies
  See `GameManager` object and adjust the slider to change the amount of spawned enemies.
  
  ![image](https://user-images.githubusercontent.com/25583587/134885973-7cfbc96f-5270-4b03-aa47-57d957f27f57.png)
