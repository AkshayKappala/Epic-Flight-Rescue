# 🪂 Epic Flight Rescue

[![Unity](https://img.shields.io/badge/Unity-5.6.1f1-black.svg?style=flat&logo=unity)](https://unity.com/)
[![Platform](https://img.shields.io/badge/Platform-Android-green.svg)](https://www.android.com/)
[![C#](https://img.shields.io/badge/Language-C%23-blue.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

> A fast-paced mobile arcade game where quick reflexes meet strategic thinking.  Rescue falling characters by tapping parachutes before they hit the ground!

## 🎮 What is Epic Flight Rescue?

Epic Flight Rescue is an addictive mobile game built with Unity that challenges players to save falling characters by opening their parachutes at the right moment. As the game progresses, the speed increases, testing your reaction time and concentration.  With multiple themes, a coin economy system, and Google Play Services integration, this game offers a complete mobile gaming experience.

## ✨ Key Features

- **🎯 Intuitive Tap Controls** - Simple one-tap mechanics for parachute deployment
- **⚡ Progressive Difficulty** - Speed increases with score for endless challenge
- **🎨 Multiple Themes** - Three distinct visual themes to unlock and play
- **💰 Coin System** - Collect coins and unlock rewards
- **🏆 Google Play Leaderboards** - Compete globally with integrated GPGS
- **🔊 Audio Feedback** - Immersive sound effects with toggle option
- **📱 Social Sharing** - Share your achievements on Android and iOS
- **🎓 Tutorial System** - Built-in tutorial for first-time players

## 🛠️ Tech Stack

- **Game Engine:** Unity 5.6.1f1
- **Language:** C#
- **Integrations:**
  - Google Play Game Services
  - Unity IAP (In-App Purchases)
  - Android Notifications
  - Reporter (Debug Console)

## 🚀 Quick Start

### Prerequisites

- Unity 5.6.1f1 or compatible version
- Android SDK for mobile builds
- Git

### Installation

```bash
# Clone the repository
git clone https://github.com/AkshayKappala/Epic-Flight-Rescue.git

# Navigate to project directory
cd Epic-Flight-Rescue/NewPianoTiles
```

### Opening in Unity

1. Launch Unity Hub
2. Click **Add** and select the `NewPianoTiles` folder
3. Open the project with Unity 5.6.1f1
4. Navigate to `Assets/Scenes` and open the main scene

### Building for Android

1. Go to **File → Build Settings**
2. Select **Android** platform
3. Click **Switch Platform**
4. Configure Player Settings (Package Name, Icons, etc.)
5. Click **Build** or **Build and Run**

## 📁 Project Structure

```
NewPianoTiles/
├── Assets/
│   ├── Scripts/
│   │   ├── GameController.cs        # Main game flow & UI management
│   │   ├── BasicTileScript.cs       # Core tile/character mechanics
│   │   ├── GamePlayController.cs    # Gameplay initialization & theme
│   │   ├── UIManager.cs             # UI state management
│   │   ├── GroundScript.cs          # Collision detection
│   │   ├── Economy.cs               # Coin system
│   │   └── GiftMovement.cs          # Bonus collectibles
│   ├── Plugins/
│   │   ├── UnityPurchasing/         # IAP integration
│   │   └── UnityChannel/            # Platform integrations
│   ├── Reporter/                    # In-game debug console
│   └── SimpleAndroidNotifications/  # Notification system
├── ProjectSettings/
└── README.md
```

## 🎯 Game Mechanics

### Core Gameplay Loop

The game spawns falling characters with parachutes. Players must tap on GREEN or BLUE characters to save them before they reach the ground: 

```csharp
private void OnMouseDown()
{
    AudioSource.PlayOneShot(clip);
    if (! IsPointerOverUIObject())
    {
        if (Tiletype == TileType.Red)
        {
            Instantiate(Resources.Load("PoofBlack"), this.transform.position, Quaternion.identity);
            UIManager.Instance.ShowGameOverMenu();
        }
        else if (Tiletype == TileType.Green)
        {
            greenfunction();
        }
        else if (Tiletype == TileType.Blue)
        {
            bluefunction2();
        }
    }
}
```

### Speed Progression

The falling speed increases dynamically based on player score:

```csharp
if(UIManager.Instance.score <= 600)
{
    StartVelocity = startvelocityref + startvelocityref * 0.002f * UIManager.Instance.score;
    transform.Translate(Vector3.down * Time.deltaTime * StartVelocity);
}
else
{
    StartVelocity = 13. 2f;
    transform.Translate(Vector3.down * Time.deltaTime * 13.2f);
}
```

### Collision Detection

Ground collision triggers game over for missed characters:

```csharp
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("GreenTag")||other.CompareTag("BlueTag"))
    {
        UIManager.Instance.ShowGameOverMenu();
    }
    else
    {
        UIManager.Instance.score++;
    }
}
```

## 🎨 Customization Guide

### Adding New Themes

1. Update theme selection in `GameController.cs`:
```csharp
public void Theme1() { /* Configure Theme 1 */ }
public void Theme2() { /* Configure Theme 2 */ }
public void Theme3() { /* Configure Theme 3 */ }
```

2. Add theme sprites and prefabs to Resources folder
3. Update `GamePlayController.cs` theme initialization

### Modifying Difficulty

Edit speed parameters in `BasicTileScript.cs`:

```csharp
StartVelocity = 6;  // Initial speed
// Adjust multiplier:  0.002f for progression rate
StartVelocity = startvelocityref + startvelocityref * 0.002f * score;
```

### Audio Configuration

Toggle sound in `GameController.cs`:

```csharp
mute = PlayerPrefs.GetInt("Soundpref");
MainCamera.GetComponent<AudioSource>().volume = mute;
```

## 🔧 Configuration

### Google Play Services Setup

Update your GPGS credentials in `GPGSIds.cs`:

```csharp
public static class GPGSIds
{
    public const string leaderboard_high_socre = "YOUR_LEADERBOARD_ID";
}
```

### PlayerPrefs Keys

The game uses these PlayerPrefs keys:
- `"HighScore"` - Player's best score
- `"Theme"` - Selected theme (1-3)
- `"Soundpref"` - Audio on/off state
- `"Coins"` - Player's coin balance
- `"isUnlocked"` - Theme unlock status

## 🐛 Troubleshooting

### Game Not Starting
- Ensure all scenes are added to Build Settings
- Check that Resources folder contains required prefabs
- Verify Unity version compatibility (5.6.1f1)

### Audio Not Playing
- Check audio source components are attached
- Verify sound files exist in Resources folder
- Ensure device volume is not muted

### Touch Input Issues
- Confirm EventSystem exists in scene
- Check Canvas raycaster settings
- Verify colliders are properly configured

### Build Errors
- Clean and rebuild the project
- Reimport all assets
- Check Android SDK path in Unity preferences

## 📫 Contact

**Developer:** AkshayKappala

**GitHub:** [@AkshayKappala](https://github.com/AkshayKappala)

**Repository:** [Epic-Flight-Rescue](https://github.com/AkshayKappala/Epic-Flight-Rescue)

---

⭐ **If you found this project interesting, please consider giving it a star! **
