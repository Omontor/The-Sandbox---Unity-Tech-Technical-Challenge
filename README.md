# The-Sandbox---Unity-Technical-Challenge
by Oliver Montor from iLLOGIKA

# What is this project?
This is a unity project to demonstrate my knowledge using ECS/DOTS.
Shooting game inspired by 1979's hit game "Asteroids" all in 3D. 
# How to play
Clone this repo and open it with Unity 2020.2.7.
You can play directly in editor by clicking Ctrl + P
If you want a standalone player you have to click on WindowsClassicBuildConfiguration (Project> Assets> BuildSettings) and then on Build and Run (top right of the inspector once selected)
This will build the game for you.
## Objective
Destroy all the asteroids before they collide with you, they'll come from every direction so be aware of your sorrouindings
## Controls
Hold right click and drag the mouse to orbit your ship.
Press spacebar to shoot
If a collision is inminent press W to go into hyperspace mode, this will trhust you forward for a second giving you a living chance!
Also you can press S to hyperspace backwards
**Use Hyperspace at your own risk

# How does it work?
## This project uses the following packages:

### Hybrid Renderer Version 0.11.0-preview.44 - May 28, 2021
### Entities Version 0.17.0-preview.42 - May 28, 2021
### Unity Physics Version 0.6.0-preview.3 - January 22, 2021

Let's see how is this is structured:

# Entities
## Asteroids
## Player
## Shot
# Components

## Asteroid Component
## Bullet Age Component
## Player

# Systems
## For Asteroids
### Asteroid Spawn System
### Asteroid Destruction System
### Asteroid Out Of Bounds System
### Movement System
## For Shooting
### Bullet Age System
### Change Material and Destroy System
## For Player
### Input Spawn System
### Input Movement System
### Player Destruction System
### Game Settings System

