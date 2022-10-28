using System;

namespace Game1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://patorjk.com/software/taag/#p=display&f=Ghost&t=The%20Dungeon
            string Title = (@"
.-') _    ('-. .-.   ('-.         _ .-') _                    .-') _               ('-.                    .-') _  
(  OO) )  ( OO )  / _(  OO)       ( (  OO) )                  ( OO ) )            _(  OO)                  ( OO ) ) 
/     '._ ,--. ,--.(,------.       \     .'_  ,--. ,--.   ,--./ ,--,'  ,----.    (,------. .-'),-----. ,--./ ,--,'  
|'--...__)|  | |  | |  .---'       ,`'--..._) |  | |  |   |   \ |  |\ '  .-./-')  |  .---'( OO'  .-.  '|   \ |  |\  
'--.  .--'|   .|  | |  |           |  |  \  ' |  | | .-') |    \|  | )|  |_( O- ) |  |    /   |  | |  ||    \|  | ) 
   |  |   |       |(|  '--.        |  |   ' | |  |_|( OO )|  .     |/ |  | .--, \(|  '--. \_) |  |\|  ||  .     |/  
   |  |   |  .-.  | |  .--'        |  |   / : |  | | `-' /|  |\    | (|  | '. (_/ |  .--'   \ |  | |  ||  |\    |   
   |  |   |  | |  | |  `---.       |  '--'  /('  '-'(_.-' |  | \   |  |  '--'  |  |  `---.   `'  '-'  '|  | \   |   
   `--'   `--' `--' `------'       `-------'   `-----'    `--'  `--'   `------'   `------'     `-----' `--'  `--'   ");
            Console.Title = "The Dungeon";
            List<string> StartMenue = new List<string>();
            StartMenue.Add("Play");
            StartMenue.Add("Quit");
            int Option = Utility.WithImgageUserOptions(StartMenue, Title, "");
            PlayArea playarea = new PlayArea();

            if(Option == 0)
            {
                //start the game
                playarea.Welcome();
            }
            else if (Option == 1)
            {
                //quits the game
                System.Environment.Exit(0);
            }
        }
    }
}