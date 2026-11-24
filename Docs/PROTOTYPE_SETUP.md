# Prototype Setup Guide

## Required editor
Install Unity 6 (6000.0.32f1) with Android Build Support and iOS Build Support modules as needed.

## Create the first test scene
1. Create a new scene named `PrototypeArena` and save it under `Assets/Scenes`.
2. Add a Plane for the floor and a Directional Light.
3. Create a Capsule named `Player`; add a CharacterController and the `ThirdPersonMotor` component.
4. Add a Camera and the `ThirdPersonCameraFollow` component. Assign the Player as its target.
5. Add the `Health` component to the Player.
6. For editor testing, connect a temporary input adapter to `RuntimeInputBridge.SetMove`. Mobile UI buttons can call `PressAttack` and `PressDodge`.

## Mobile controls
Create a Canvas with a virtual joystick and action buttons. The joystick should call `RuntimeInputBridge.SetMove(Vector2)`; the dodge button should call `RuntimeInputBridge.PressDodge()`. Call `RuntimeInputBridge.SetMove(Vector2.zero)` when the joystick is released.

## Current limitations
- The repository currently contains code foundations, not a fully assembled Unity scene.
- Attack input is only a bridge event; weapon hit detection and animation are not implemented yet.
- Configure the Active Input Handling setting for the Input System (or Both) in Project Settings.
- Test on actual iOS and Android devices before tuning performance.

## Next milestone
Add a basic attack controller, target dummy, damage feedback, and a small greybox arena before building advanced abilities or multiplayer.
