namespace LangtonAnt.LangtonsAntLogic;
public class Program 
{
    public static void Main() 
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var simulation = new LangtonsAntSimulation();
        for (int i = 0; i < 10000; i++) 
        {
            Console.Clear();
            simulation.PrintGrid();
            simulation.Step();
            Thread.Sleep(100);
        }
    }
}