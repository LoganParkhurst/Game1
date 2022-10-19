using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Game1
{
    internal class PlayArea
    {
        Player Player { get; set; } = new Player();
        Map Map { get; set; } = new Map();
        Combat Combat { get; set; } = new Combat();
        public List<string> options { get; set; } = new List<string>();



        public void Welcome()
        {
            Clear();
            //Get Player name
            WriteLine("Welcome adventurer. \nWhat is your name?");
            Player.Name = ReadLine().Trim();
            //inform player of their goal
            WriteLine($"Your goal {Player.Name} is to get the tresure at the end of the temple.");
            WriteLine("There is a map in this game.\n= or | mean walls\n/ means a door\n@ is your current Location");
            WriteLine("Press 'ENTER' to Continue");
            ReadLine();
            //set up inventory
            Player.Inventory.Add("Sword");
            Player.Inventory.Add("Shield");
            Player.Inventory.Add("Potion");
            Player.Inventory.Add("Potion");
            Player.Location = 0;
            SetUp();
        }
        public void SetUp()
        {
            //set up some sort of story
            Clear();
            WriteLine("As you approach the large doors of the temple. Your breath clouds your vision. ");
            ForegroundColor = ConsoleColor.Blue;
            WriteLine($"{Player.Name}: I better get inside before the blizard gets worse.");
            ForegroundColor = ConsoleColor.White;
            WriteLine("With a slow creek the large stone doors slowly opened, and you stepped in.\nAs you enter the door slams shut behind you.");
            ForegroundColor = ConsoleColor.Blue;
            WriteLine($"{Player.Name}: No turning around now I guess.");
            ForegroundColor = ConsoleColor.White;
            WriteLine("Press 'ENTER' to Continue");
            ReadLine();
            Play();
        }
        public void Play()
        {
            while (!Player.IsGameOver)
            {
                Clear();
                if (Player.Location == 0)
                {
                    options.Clear();
                    WriteLine(Map.map0);
                    WriteLine("You stand in a Large open hallway with many doors");
                    options.Add("Describe");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.UserOptions(options);
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                    else if (Choice == 1)
                    {
                        Movement movement = new Movement();
                        movement.PlayerMovement(options, Player);
                    }
                    else if (Choice == 2)
                    {
                        Clear();
                        Player.rest(options, Player);
                    }
                    else if (Choice == 3)
                    {
                        WriteLine("Your current Inventory is: ");
                        int x = 0;
                        foreach (string i in Player.Inventory)
                        {
                            WriteLine(Player.Inventory[x]);
                            x++;
                        }
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                }
                else if (Player.Location == 1)
                {
                    if (Player.FirstTime1)
                    {
                        WriteLine("As you enter the room you notice that the room is a large ball room.\nThere are many old tables. all of the tables are set up as if there was to be a ball");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                        WriteLine("There is somthing shiny in the cornner would you like to inspect the item?");
                        options.Clear();
                        options.Add("Yes");
                        options.Add("No");
                        int  PlayerYesOrNo = Utility.UserOptions(options);
                        if(PlayerYesOrNo == 0)
                        {
                            WriteLine("You pick up the shiny coin");
                            WriteLine("You picked up a Gold Coin");
                            Player.Inventory.Add("Gold Coin");
                        }
                        else if(PlayerYesOrNo == 1)
                        {
                            WriteLine("Are you sure?");
                            PlayerYesOrNo = -1;
                            PlayerYesOrNo = Utility.UserOptions(options);
                            if(PlayerYesOrNo != -1 && PlayerYesOrNo == 0)
                            {
                                WriteLine("You dont inspect the shiny item");
                            }
                            else if(PlayerYesOrNo != -1 && PlayerYesOrNo == 1)
                            {
                                WriteLine("You pick up the shiny coin");
                                WriteLine("You picked up a Gold Coin");
                                Player.Inventory.Add("Gold Coin");
                            }
                        }
                        Player.FirstTime1 = false;
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                    Clear();
                    options.Clear();
                    WriteLine(Map.map1);
                    WriteLine("You stand in the dusty old ball room. the darkness seems to streach on forever.");
                    options.Add("Describe");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.UserOptions(options);
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                    else if (Choice == 1)
                    {
                        Movement movement = new Movement();
                        movement.PlayerMovement(options, Player);
                    }
                    else if (Choice == 2)
                    {
                        Clear();
                        Player.rest(options, Player);
                    }
                    else if (Choice == 3)
                    {
                        WriteLine("Your current Inventory is: ");
                        int x = 0;
                        foreach (string i in Player.Inventory)
                        {
                            WriteLine(Player.Inventory[x]);
                            x++;
                        }
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }

                }
                else if (Player.Location == 2)
                {
                    if (Player.FirstTime2)
                    {
                        WriteLine("As you open the wooden door you notice this room is well kept.");
                        WriteLine("The room is clean and seems to have some natural light coming through a window");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                    Clear();
                    options.Clear();
                    WriteLine(Map.map2);
                    WriteLine("You stand in the well pereserved room. the light is strangly relaxing.");
                    options.Add("Describe");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.UserOptions(options);
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                    else if (Choice == 1)
                    {
                        Movement movement = new Movement();
                        movement.PlayerMovement(options, Player);
                    }
                    else if (Choice == 2)
                    {
                        Clear();
                        Player.rest(options, Player);
                    }
                    else if (Choice == 3)
                    {
                        WriteLine("Your current Inventory is: ");
                        int x = 0;
                        foreach (string i in Player.Inventory)
                        {
                            WriteLine(Player.Inventory[x]);
                            x++;
                        }
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                }
                else if (Player.Location == 3)
                {
                    if (Player.FirstTime3)
                    {
                        WriteLine("You open the small wooden door and now stand in what you assume is a servent's quarters.");
                        WriteLine("There are many drawers and a few bunk beds");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                    options.Clear();
                    WriteLine(Map.map2);
                    WriteLine("You stand in the servent's quarters");
                    options.Add("Describe");
                    options.Add("Search");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.UserOptions(options);
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                    else if (Choice == 1)
                    {
                        WriteLine("There are many drawers. so you get to work looking through");
                    }
                    else if (Choice == 2)
                    {
                        Movement movement = new Movement();
                        movement.PlayerMovement(options, Player);
                    }
                    else if (Choice == 3)
                    {
                        Clear();
                        Player.rest(options, Player);
                    }
                    else if (Choice == 4)
                    {
                        WriteLine("Your current Inventory is: ");
                        int x = 0;
                        foreach (string i in Player.Inventory)
                        {
                            WriteLine(Player.Inventory[x]);
                            x++;
                        }
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                }
                else if (Player.Location == 4)
                {
                    if (Player.FirstTime3)
                    {
                        WriteLine("Stepping into the room your immediately notice the plants that cover the sides of the room");
                        WriteLine("You can make out a few books on some desks and scattered around the room");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                    Clear();
                    options.Clear();
                    WriteLine(Map.map2);
                    WriteLine("You stand in the room covered in plants");
                    options.Add("Describe");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.UserOptions(options);
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                    else if (Choice == 1)
                    {
                        Movement movement = new Movement();
                        movement.PlayerMovement(options, Player);
                    }
                    else if (Choice == 2)
                    {
                        Clear();
                        Player.rest(options, Player);
                    }
                    else if (Choice == 3)
                    {
                        WriteLine("Your current Inventory is: ");
                        int x = 0;
                        foreach (string i in Player.Inventory)
                        {
                            WriteLine(Player.Inventory[x]);
                            x++;
                        }
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                }
                else if (Player.Location == 5)
                {
                    if (Player.FirstTime5)
                    {
                        WriteLine("");
                    }
                }
                else if (Player.Location == 6)
                {

                }
                else if (Player.Location == 7)
                {

                }
                else if (Player.Location == 8)
                {

                }

            }
        }
            //public void GameOver()
            //{

            //}
            public void Ending()
            {

            }
        }
    } 
