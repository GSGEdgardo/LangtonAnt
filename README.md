# The Langton's Ant Project

![C#](https://img.shields.io/badge/c%23-%23239120.svg?)
![Last Commit](https://img.shields.io/github/last-commit/GSGEdgardo/LangtonAnt)
![Institution](https://img.shields.io/badge/institution-Universidad%20Cat%C3%B3lica%20del%20Norte-blue)

## Description

This repository contains a dynamic and visually chaotic simulation of [Langton's Ant](https://en.wikipedia.org/wiki/Langton%27s_ant), developed in C#. Unlike the traditional implementation, this version introduces multiple ants, randomized spawning, and behavioral divergence (some ants turn oppositely), resulting in a complex emergent system that resembles an ant city or "colony chaos."

The simulation expands the grid dynamically, prints real-time updates using Unicode characters, and introduces a new ant every 10 steps with a 50% chance of reverse behavior to increase entropy in the system.

## Features

- Infinite expanding grid
- Multiple ants with independent directions
- Reverse behavior ants (chaotic agents)
- Random ant generation every 10 steps
- Unicode-based console visualization

### Requirements
- .NET 8.0 SDK


## Folder Structure

```
LangtonsAnt/
│
├── LangtonsAntLogic/         # Core simulation logic (Grid, Ant, Simulation)
│   ├── Ant.cs
│   ├── Grid.cs
│   ├── Directions.cs
│   ├── CellState.cs
│   └── Loop.cs
│
├── Program.cs                # Main entry point to run the simulation
├── LangtonsAnt.csproj
└── README.md
```
---

## License

This project is licensed under the [MIT License](https://github.com/GSGEdgardo/LangtonAnt?tab=MIT-1-ov-file)
