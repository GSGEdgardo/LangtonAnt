using System.Runtime.CompilerServices;

namespace LangtonAnt.LangtonsAntLogic;
public class LangtonsAntSimulation 
{
    private Grid grid;
    private List<Ant> ants;
    private int stepCounter = 0;
    private Random random = new();

    public LangtonsAntSimulation(int initialRows = 5, int initialCols = 5) 
    {
        grid = new Grid(initialRows, initialCols);
        //if you want to use only one ant, just uncomment this line and delete the foreach in the step function.
        //ant = new Ant(initialRows / 2, initialCols / 2); 

        ants = new List<Ant>();
        // We gonna add 3 ants to the grid to get a more chaotic simulation
        ants.Add(new Ant(initialRows / 2, initialCols / 2, true));           // Center
        ants.Add(new Ant(initialRows / 2 - 1, initialCols / 2 - 1, true));   // Top-left
        ants.Add(new Ant(initialRows / 2 + 1, initialCols / 2 + 1, true));   // Bottom-right
        ants.Add(new Ant(initialRows /2 + 1, initialCols / 2 - 1, false)); // Bottom-left
        ants.Add(new Ant(initialRows /2 - 1, initialCols / 2 + 1, false)); // Top-right
    }

    public void Step()
    {
        stepCounter++;
        foreach (var ant in ants)
        {
            // Ensure grid includes ant’s current position
            var (rowOffset, colOffset) = grid.ExpandGrid(ant.Row, ant.Col);
            // Update ant position accodingly
            ant.AdjustPosition(rowOffset, colOffset);
            var currentState = grid.GetCell(ant.Row, ant.Col);
            ant.Turn(currentState);
            grid.ToggleCell(ant.Row, ant.Col);
            ant.Movement();
            // Ensure that grid includes the new ant position
            (rowOffset, colOffset) = grid.ExpandGrid(ant.Row, ant.Col);
            grid.ExpandGrid(ant.Row, ant.Col);
        }
        // every 10 steps, add a new random ant to the grid
        if (stepCounter % 10 == 0) 
        {
            AddRandomAnt();
        }
    }

    public void RunSimulation(int steps) 
    {
        for (int i = 0; i < steps; i++)
        {
            Step();
        }
    }

    // Even with reverse behavior the ant colony isnt chaotic enough, so we add a new ant every 10 steps
    // with a 50% chance of being chaotic or lawful. And if this isnt enough, we can add more ants with a neutral set idk
    private void AddRandomAnt()
    {
        var (row, col) = grid.GetRandomPosition();
        bool reverse = random.NextDouble() < 0.5; // 50% chance of chaotic behavior
        var newAnt = new Ant(row, col, reverse);
        ants.Add(newAnt);
    }

    public void PrintGrid()
    {
        grid.PrintGrid(ants);
    }
}
