namespace ConsoleBLENet48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BLEControlLogic logic = new BLEControlLogic();
            logic.MainLoop(args);
        }
    }
}
