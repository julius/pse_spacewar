using System;

namespace EtherDuels
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (EtherDuels game = new EtherDuels())
            {
                game.Run();
            }
        }
    }
#endif
}

