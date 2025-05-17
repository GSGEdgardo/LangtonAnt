namespace LangtonAnt.LangtonsAntLogic;
public class Program 
{
    public static void Main() 
    {
        var simulation = new LangtonsAntSimulation();
        for (int i = 0; i < 100; i++) 
        {
            Console.Clear();
            simulation.PrintGrid();
            simulation.Step();
            Thread.Sleep(100);
        }
    }
}