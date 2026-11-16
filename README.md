# 2D Platformer

A 2D side-scrolling platformer game prototype developed in Unity. The core gameplay loop involves controlling a player character through tilemap levels, performing jumps and double jumps, stomping on patrolling enemies, avoiding hazard spikes and death zones, gathering collectible gems and cherries, activating checkpoints to save respawn points, and managing health via a heart-based HUD with pause and menu navigation. This project is a personal prototype/demo project, not a maintained product, with the last substantial work committed in 2022.

## Gameplay

- **Player Movement & Physics**: Horizontal running, single and double jumping, damage knockback recoil, and dynamic parenting to moving platforms in `Assets/Scripts/PlayerController.cs`.
- **Health & Invulnerability**: Three-heart (6 HP) health management system with damage intake, temporary post-damage invulnerability sprite flashing, and healing functions in `Assets/Scripts/PlayerHealthController.cs`.
- **Patrolling Enemies**: Ground enemies moving between configurable boundary patrol points with randomized movement duration and pause intervals in `Assets/Scripts/EnemyController.cs`.
- **Stomp Attack & Enemy Drops**: Jumping onto enemy colliders bounces the player, plays explosion VFX, destroys the enemy, and rolls a random chance to spawn a cherry or gem drop in `Assets/Scripts/StompBox.cs`.
- **Hazards & Instant Death**: Contact damage triggered on player collision with hazard triggers in `Assets/Scripts/DamagePlayer.cs`, and out-of-bounds fall death zones triggering respawns in `Assets/Scripts/KillZone.cs`.
- **Checkpoints & Respawning**: Checkpoint flagpoles that register player spawn positions and update visual state upon contact in `Assets/Scripts/Checkpoint.cs` and `Assets/Scripts/CheckPointController.cs`, with delayed respawn sequencing handled in `Assets/Scripts/LevelManager.cs`.
- **Collectibles**: Collectible gems that increment the level score counter and cherries that restore player health in `Assets/Scripts/Pickup.cs`.
- **Moving Platforms**: Platforms cycling through an array of positional waypoints at configurable speeds in `Assets/Scripts/MovingPlatform.cs`.
- **Parallax Camera**: 2D camera following the player target with clamped vertical bounds and two-layer background parallax tracking in `Assets/Scripts/CameraController.cs`.
- **Audio System**: Audio playback manager providing single-instance SFX dispatching with randomized pitch variations for player actions, hits, pickups, and enemy explosions in `Assets/Scripts/AudioManager.cs`.
- **User Interface & Pause Menu**: Canvas HUD tracking health hearts and gem counts, pause toggle on the `Escape` key, resume button, and scene transition back to the main menu in `Assets/Scripts/UIController.cs`.
- **Main Menu**: Simple start game and application exit controls in `Assets/Scripts/MainMenu.cs`.
- **Performance Settings**: Target frame rate locked to 60 FPS upon startup in `Assets/Scripts/MyOptions.cs`.

## Tech Stack

- **Game Engine**: Unity `2020.3.36f1` (declared in `ProjectSettings/ProjectVersion.txt`)
- **Scripting Runtime**: C# (.NET / Mono)
- **Key Dependencies & Packages** (declared in `Packages/manifest.json`):
  - `com.unity.2d.pixel-perfect` (`4.0.1`): Pixel-perfect 2D rendering and camera alignment
  - `com.unity.2d.tilemap` (`1.0.0`): 2D tilemap system for level design
  - `com.unity.2d.animation` (`5.2.2`): 2D skeletal and sprite animation tools
  - `com.unity.2d.spriteshape` (`5.3.0`): 2D sprite shaping
  - `com.unity.ugui` (`1.0.0`): Unity UI system for menus and HUD
  - `com.unity.textmeshpro` (`3.0.6`): TextMesh Pro text formatting
  - `com.unity.cinemachine` (`2.6.3`): Cinemachine camera suite
  - `com.unity.postprocessing` (`3.0.3`): Post-processing stack
  - `com.unity.timeline` (`1.4.8`): Timeline sequencing

## Project Structure

| Path | Contents | Classification |
| --- | --- | --- |
| `Assets/Scripts/` | C# scripts for player movement, health, enemies, stomp attack, pickups, checkpoints, level flow, camera, and UI | Own code |
| `Assets/Scenes/` | Unity scene files: `MainMenu.unity`, `SampleScene.unity`, `Testing.unity`, `Testing2.unity` | Own code / scene data |
| `Assets/Prefabs/` | Prefabs for player, enemies, collectibles, checkpoints, UI canvas, and game audio managers | Own code / data |
| `Assets/Animations/` | Animation controllers and clips for player actions, enemy movement, collectibles, and checkpoints | Own code / assets |
| `Assets/Tiles/` | Generated tile assets (`sunnyland_tiles_relaid_Padded_*.asset`) for tilemap painting | Third-party / data |
| `Assets/2D Platformer Assets/` | "Sunny Land" asset pack containing audio clips, fonts, and sprite sheets for player, enemies, collectibles, and levels | Third-party assets |
| `Assets/Prototype Hero - Pixel Art/` | "Prototype Hero" character asset pack containing sprites, animations, audio, and demo scripts (`PrototypeHero.cs`, `Sensor_Prototype.cs`, etc.) | Third-party assets & demo code |
| `Assets/TextMesh Pro/` | TextMesh Pro default resources, shaders, fonts, and sprite assets | Third-party / Unity package resources |
| `Assets/Fonts/` | Additional font assets for UI text rendering | Third-party / asset data |
| `Assets/Gizmos/` | Custom editor gizmo icons for scene view visualization | Asset data |
| `Assets/Physics/` | 2D physics materials defining friction and bounciness | Project data |
| `Packages/` | Unity package manifest (`Packages/manifest.json`) declaring package dependencies | Configuration |
| `ProjectSettings/` | Project settings files (`ProjectVersion.txt`, `EditorBuildSettings.asset`, `TagManager.asset`, etc.) | Engine configuration |

## Running / Building

### Requirements
- Unity Hub
- Unity Editor version `2020.3.36f1` (or compatible Unity 2020.3 LTS release)

### Steps
1. Clone the repository locally:
   ```sh
   git clone https://github.com/bahattinercan/2d-platformer.git
   ```
2. Open **Unity Hub**, click **Add**, and select the cloned repository folder (`2d-platformer`).
3. Select Unity version `2020.3.36f1` to open the project. Allow Unity to resolve package dependencies and import assets.
4. **Entry Scene**:
   - To start from the main menu: Open `Assets/Scenes/MainMenu.unity`. Clicking the **Start** button in this scene loads the main level `Testing2` via `MainMenu.cs`.
   - To test platforming gameplay directly: Open `Assets/Scenes/Testing2.unity`, which contains the fully populated test level with player spawn, terrain, enemies, collectibles, checkpoints, and UI canvas.
   - *Note on Build Settings*: `ProjectSettings/EditorBuildSettings.asset` contains references to legacy/missing 2D Gamekit template scenes (`Assets/2DGamekit/...`); the working scenes present in this repository are located under `Assets/Scenes/`.
5. Press the **Play** button in the Unity Editor toolbar to run the scene.

> *Note on verification*: This project was inspected statically from repository source files and configuration; it has not been compiled, built, or executed in the Unity Editor in this environment.

## Repository Notes

- This repository represents a personal learning prototype created to experiment with Unity 2D mechanics, tilemaps, and character physics.
- **Tests**: None implemented. Although `Packages/manifest.json` includes `com.unity.test-framework`, there are no test assemblies or test scripts in the repository.
- **CI / CD**: No continuous integration or deployment pipelines are configured (no `.github/workflows` present).
- **Commit History**: Minimal history consisting of 2 commits: the initial commit and an update commit made on September 22, 2022.

## Third-Party Assets

- `Assets/2D Platformer Assets/`: "Sunny Land" 2D pixel art graphics pack by Ansimuz (including level tiles, props, mechanics, backgrounds, enemies, collectibles, and player sprites). Documented in `Assets/2D Platformer Assets/Graphics/Credits.txt` citing [https://ansimuz.itch.io/sunny-land-pixel-game-art](https://ansimuz.itch.io/sunny-land-pixel-game-art). No separate license file is present in this directory.
- `Assets/Prototype Hero - Pixel Art/`: "Prototype Hero" character asset pack containing sprites, animations, audio, and demo scripts. No license file is present in this directory.
- `Assets/TextMesh Pro/`: TextMesh Pro default package resources and sprite assets. Includes license file at `Assets/TextMesh Pro/Sprites/EmojiOne_License.txt` for the EmojiOne / JoyPixels asset.
