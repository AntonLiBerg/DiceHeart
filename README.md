# DiceHeart

DiceHeart is a small proof-of-concept game made in Godot 4 with C#.  
The goal of this project is to experiment with game feel and mechanics, especially:

- dice allocation
- resource pressure
- turn-based risk/reward
- escalating random events

This is not meant to be a polished, content-complete game. It is a mechanics sandbox and a learning project.

## What This Is

At a high level, DiceHeart is a turn-based survival puzzle:

- You roll and place dice onto cards.
- Cards convert those dice into resources.
- Every turn applies upkeep and event effects.
- You try to survive as many turns as possible.

The system is intentionally simple so different mechanics can be tested quickly.

## Core Idea

You manage three resources:

- Heart: your survival resource
- Gold: your economy resource
- Power: your protection resource

Heart is the one that matters most. If it falls to 0 or below, the run ends.

## How You Play

Each turn looks like this:

1. Spend Gold to prepare dice.
2. Use number keys `1` to `6` to select a die by its face value.
3. Place selected dice onto cards using the card `Add Die` button.
4. Press `Play turn` to resolve all effects.
5. Survive upkeep and repeat.

### Controls

- `Roll 🎲` (costs 1 Gold): rerolls dice in tray
- `Add 1 🎲` (costs 2 Gold): adds another die to the tray
- Keyboard `1`-`6`: selects a die with matching value
- `Add Die` on card: assigns selected die to that card
- `Play turn`: resolves card effects, events, and upkeep

## Current Mechanics

### Cards

- Heart: assigned dice directly add Heart
- Invest: dice with value `4+` build progress; on 2 progress, you gain Gold
- Power: needs dice with value `5+`; when completed, you gain Power and the requirement increases

### Ongoing Effects and Events

Runs can gain positive and negative ongoing changes, such as:

- Income Tax (boon): steady Gold income
- Poor Harvest: Gold loss each turn
- Crime Wave / Crime Gang: problems that can be ended by building enough Power
- Corruption: temporary pressure that can drain Gold and reduce dice

### Upkeep

At end of turn:

- Heart is reduced by 1
- Turn counter increases
- A random new negative event may appear

This creates the main tension: building momentum while keeping Heart alive.

## Starting Conditions

- Gold: 10
- Power: 0
- Heart: 0

Because Heart starts at 0, early decisions are important. You usually need to prioritize Heart quickly to avoid an immediate loss.

## Running the Project

### Requirements

- Godot 4 with .NET support
- Compatible .NET SDK installed

### Launch

1. Clone the repo.
2. Open `project.godot` in Godot.
3. Run the project (`F5`).
