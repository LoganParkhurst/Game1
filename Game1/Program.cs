using System;

namespace Game1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> StartMenue = new List<string>();
            StartMenue.Add("Play");
            StartMenue.Add("Quit");
            int Option = Utility.UserOptions(StartMenue);
            PlayArea playarea = new PlayArea();

            if(Option == 0)
            {
                playarea.Welcome();
            }
            else if (Option == 1)
            {
                System.Environment.Exit(0);
            }
        }
    }
}