namespace LangtonAnt.LangtonsAntLogic;
public class LangtonsAntSimulation 
{
    private Grid grid;
    private Ant ant;

    public LangtonsAntSimulation(int initialRows = 5, int initialCols = 5) 
    {
        grid = new Grid(initialRows, initialCols);
        ant = new Ant(initialRows / 2, initialCols / 2);
    }

    public void Step() 
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

    public void RunSimulation(int steps) 
    {
        for (int i = 0; i < steps; i++)
        {
            Step();
        }
    }
    public void PrintGrid()
    {
        grid.PrintGrid();
    }
}
