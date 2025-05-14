# Lucky Slots v1

A fully-featured, production-ready slot machine game built with Unity and C#. This project implements a complete slot machine experience, including symbol management, paylines, payout calculation, animations, and a robust state machine for game flow.

---

## Core Technologies
- **Unity Engine** (2021+ recommended)
- **C#**
- **DOTween** (for smooth animations)
- **TextMeshPro** (for UI text rendering)

---

## Getting Started

### Prerequisites
- Unity Editor (2021 or newer)
- DOTween Unity package
- TextMeshPro package (included by default in recent Unity versions)

### Installation
1. Clone this repository:
   ```powershell
   git clone <your-repo-url>
   ```
2. Open the project in Unity.
3. Ensure DOTween is installed (via Unity Package Manager or [Demigiant's website](http://dotween.demigiant.com/)).
4. Open the main scene and press Play to start the game.

---

## Components Overview

### ActiveGameSymbols.cs
Manages the 2D arrays of active and fake symbols currently displayed on the slot reels. Tracks whether the grid is populated and provides accessors for other systems.

### AnimateWinnings.cs
State machine behaviour that triggers the animation of winning paylines and symbols, and visualizes payouts when the game enters the appropriate state.

### AwaitInput.cs
State machine behaviour that listens for player input (e.g., pressing Enter) to advance the game state.

### BetHandler.cs
Handles the player's bet logic, ensuring bets are only placed if the player has sufficient balance, and updates the game state accordingly.

### CalculatePayout.cs
State machine behaviour that triggers payout calculation after a spin.

### CleanSymbols.cs
State machine behaviour that coordinates the cleaning (removal) of symbols from the reels, resets paylines, and clears payout visualizations between spins.

### GameStateManager.cs
Central controller for the game's state machine. Manages state transitions, triggers, and state assertions.

### GameSymbol.cs
Represents a single symbol on the reels. Stores its type (Wild, Ten, Jack, etc.) and provides access to this information.

### GameSymbolPool.cs
Implements object pooling for all symbol types (including fake symbols for animation). Efficiently recycles symbols to minimize instantiation overhead.

### GameSymbolSpawner.cs
Instantiates and pools all possible game symbols at startup, ensuring the pool is always ready for gameplay.

### GenerateRoll.cs
State machine behaviour that generates a new set of rolled symbols for the next spin and signals the state machine to proceed.

### HandleBet.cs
State machine behaviour that triggers the bet handling logic at the appropriate point in the game flow.

### InputManager.cs
Handles player input for spinning the reels, forwarding input events to the state machine.

### Payline.cs
Represents a single payline, including its path, winner status, and rendering logic. Handles both standard and special paylines.

### PaylineSpawner.cs
Manages the instantiation and pooling of all paylines and special paylines. Provides access to all paylines for payout calculation and animation.

### PayoutCalculator.cs
Calculates all winning paylines, clusters, and special combinations. Tallies payouts and coordinates with the winnings animator.

### PayoutVisualizer.cs
Animates and visualizes payouts for each symbol type using DOTween. Handles resetting of payout animations between spins.

### PayoutVisualizerSymbol.cs
Stores the original position of payout visualization symbols for smooth animation resets.

### Player.cs
Tracks the player's bet and balance, handles awarding winnings and placing bets, and updates the UI accordingly.

### RolledSymbolDatum.cs
Represents a single roll of the slot machine, generating a random grid of symbols and providing access to the result.

### RolledSymbolGenerator.cs
Manages the creation of new `RolledSymbolDatum` instances for each spin.

### RollSymbols.cs
State machine behaviour that generates a new roll and stores it for the next spin.

### SlotsAnchors.cs
Manages the anchor points for all symbol positions on the reels, ensuring symbols are placed and animated correctly.

### SlotsAttributes.cs
Defines all static attributes for the slot machine (number of reels, rows, symbol types, and offsets).

### SymbolCleaner.cs
Handles the removal and pooling of symbols from the reels after each spin, including animation and state signaling.

### SymbolTransporter.cs
Handles the movement and animation of symbols onto the reels for each spin, including both real and fake symbols for visual effects.

### TransportSymbols.cs
State machine behaviour that triggers the symbol transport logic at the correct point in the game flow.

### UIManager.cs
Updates and manages the UI elements for bet and balance, ensuring the player always sees the current values.

### WinningsAnimator.cs
Animates all winning symbols and paylines, including special paylines, and coordinates with the state machine to advance the game.

---

## License

This project is licensed under the MIT License. See [LICENCE.md](LICENCE.md) for details.

---

## Code of Conduct

All contributors are expected to follow our [Code of Conduct](CODE_OF_CONDUCT.md).

---

## Contributing

Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines on how to contribute, report bugs, or suggest enhancements.

---

## Security

If you discover a security vulnerability, please follow the process outlined in [SECURITY.md](SECURITY.md) and do not disclose it publicly until it is resolved.

---

## Support

For support, please open an issue in the repository or contact the maintainers directly.

---

## Contact

Project maintained by Joaquin Telleria. For business or support inquiries, see the repository or contact via the information provided in the project.

---

## Acknowledgements
- DOTween by Demigiant
- Unity Technologies
- TextMeshPro
- All contributors and testers
