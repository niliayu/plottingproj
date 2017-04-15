// Create instance of base window

namespace ConsoleApplication
{
    public static class GlobalVars
    {
        public static string[] Buildings = {"olin", "white"};
    }

    internal class MainClass
    {
        public static void Main(string[] args)
        {
            System.Windows.Forms.Application.Run(new Window());
        }
    }

}