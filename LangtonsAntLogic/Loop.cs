namespace LangtonAnt.LangtonsAntLogic;
public class LangtonsAntSimulation 
{
    private Grid grid;
    private List<Ant> ants;

    public LangtonsAntSimulation(int initialRows = 5, int initialCols = 5) 
    {
        grid = new Grid(initialRows, initialCols);
        //if you want to use only one ant, just uncomment this line and delete the foreach in the step function.
        //ant = new Ant(initialRows / 2, initialCols / 2); 

        ants = new List<Ant>();
        // We gonna add 3 ants to the grid to get a more chaotic simulation
        ants.Add(new Ant(initialRows / 2, initialCols / 2));           // Center
        ants.Add(new Ant(initialRows / 2 - 1, initialCols / 2 - 1));   // Top-left
        ants.Add(new Ant(initialRows / 2 + 1, initialCols / 2 + 1));   // Bottom-right
    }

    public void Step() 
    {
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
    }

    public void RunSimulation(int steps) 
    {
        for (int i = 0; i < steps; i++)
        {
            Step();
        }
    }
    public void PrintGrid()
    {
        grid.PrintGrid(ants);
    }
}
