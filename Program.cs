using System;

namespace Paddlist
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Paddlist())
                game.Run();
        }
    }
}
