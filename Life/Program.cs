namespace Life
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Colony colony = new Colony(11);
            colony.AddAnts(2,3,4);
            colony.Display();
            string userInput = Console.ReadLine();
            while (userInput != "q")
            {
                colony.Update();
                colony.Display();
                userInput = Console.ReadLine();
            }
        }
    }
}