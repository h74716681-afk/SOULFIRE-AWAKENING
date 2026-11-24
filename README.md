# SOULFIRE: AWAKENING

A cross-platform action game targeting **iOS and Android**, developed with **Unity 6** and the Universal Render Pipeline (URP).

## Game vision
An original anime-inspired supernatural action experience built around soul energy, sword combat, ranged weapons, combos, dodging, ultimate abilities, story exploration, and boss encounters. Competitive arenas and squad-based multiplayer are planned for later milestones.

## Development principles
1. Build a small, playable prototype before expanding the world.
2. Keep controls and performance suitable for touch devices.
3. Add systems in testable milestones and keep the project buildable.
4. Treat online multiplayer as a later phase, after core movement and combat are stable.

## Prototype milestone 1
- Unity 6 project foundation with URP
- Third-person player movement and camera
- Mobile touch-input bridge
- Health and damage foundation
- Test arena and basic combat loop

## Target platforms
- iOS
- Android

## Engine baseline
- Unity 6 (6000.0.32f1)
- Universal Render Pipeline 17
- Input System 1.11

## Current status
Early foundation stage. This repository is the source of truth for the game's code and development notes. The first goal is a reliable, playable third-person prototype; larger features will be added incrementally.


## Browser prototype (iPad/iPhone testing)
A lightweight touch-controlled 3D browser prototype is available at `index.html`. It is a development preview to test the arena, movement, dodge, and attack loop on mobile Safari. It is separate from the Unity project foundation and is not a native iOS/Android app.

### Publish the browser preview
In GitHub, open **Settings → Pages**. Under **Build and deployment**, choose **Deploy from a branch**, select **main** and **/(root)**, then Save. After GitHub Pages finishes publishing, open the site URL shown on that Pages screen on your iPad or iPhone. GitHub Pages sites are public.
