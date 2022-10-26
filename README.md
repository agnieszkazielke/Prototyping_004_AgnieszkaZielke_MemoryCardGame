# Prototyping_004_AgnieszkaZielke_MemoryCardGame
Memory Card Game Prototype - XR Bootcamp

## Idea

Learning, particularly memorising can be tedious as it requires long concentration spans in a world which is usually full of distractions. Bringing learning experiences into VR:

- removes all distractions
- engages more senses through visual, audio and haptic stimulation
- gamifies the experience, increasing user engagement

I would like to provide a customisable experience in a form of a memory card game. My key priority is to provide a comfortable and fun UI that encourages the user to keep coming back to the experience. I would also like to set up the prototype so that it is easily extendable and the contents can be varied to suit. 

## Features

**Core features:** 

These are the features that your prototype really needs to function or to prove your point.

- Cards / objects arranged around the player.
- The card / object content is ‘applied’ to each gameobject at the start of the game based on a list of elements saved in the GameManager
- Tapping / controller selection reveals the contents of the card / object.
- UI interface for tracking game progress

**Stretch goals:** 

These are features that are nice to have, and that you might implement if you have extra time, or in the future.

- 3 difficulty levels, determining the number of taps allowed:
    - easy: unlimited taps
    - medium: number of cards * 4 taps (TBC)
    - hard: number of cards * 3 taps (TBC)
- The number of cards / objects can be easily adjusted with the objects automatically re-ordering around the player.
- The cards could reveal to be 3D objects instead, morphing to shape upon interaction

## Tech Stack

- Unity 2021.3.11f1
- VR prototype
- Oculus Integration SDK; hand tracking and controller
