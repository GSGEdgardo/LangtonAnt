namespace LangtonAnt.LangtonsAntLogic;
public class Program 
{
    public static void Main() 
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;

        var simulation = new LangtonsAntSimulation();
        for (int i = 0; i < 10000; i++) 
        {
            simulation.PrintGrid();
            simulation.Step();
            Thread.Sleep(100);
        }
    }
}