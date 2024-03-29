﻿using System;
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
        Map TheMap { get; set; } = new Map();
        Combat Combat { get; set; } = new Combat();
        public List<string> options { get; set; } = new List<string>(); //make the options list it will be used a LOT



        public void Welcome()
        {
            Clear();
            //Get Player name
            WriteLine("Welcome adventurer. \nWhat is your name?");
            Player.Name = ReadLine().Trim();
            bool IsNameString = int.TryParse(Player.Name, out var name);
            if (IsNameString)
            {
                WriteLine("Please enter a valid input.");
                WriteLine("Press 'ENTER' to Continue");
                ReadLine();
                Welcome();
            }
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
            //As long as the game isn't over the game doesn't end
            while (!Player.IsGameOver)
            {
                //start of the main game loop
                Clear();
                //checking to see what the player location is. by defalt it is set to 0
                if (Player.Location == 0)
                {
                    //clear our options list
                    options.Clear();
                    //add what options we want
                    options.Add("Describe");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    //send to a modified version of our option class from class to find out what the user wants to do
                    int Choice = Utility.WithImgageUserOptions(options, TheMap.map0, "You stand in a Large open hallway with many doors");
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("You stand in the start of the hallway");
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
                }
                else if (Player.Location == 1)
                {
                    if (Player.FirstTime1)
                    {
                        //create a new enemy
                        Enemy enemy1 = new Enemy()
                        {
                            //add the stats to the new enemy
                            Name = "Goblin",
                            Health = 100,
                            Attack = 10
                        };
                        WriteLine("Befor you could get a good look a goblin jumps out at you");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                        //sends the player to a combat class
                        Combat.SetUp(Player, enemy1);
                        
                        WriteLine("As you enter the room you notice that the room is a large ball room.\nThere are many old tables. all of the tables are set up as if there was to be a ball");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                        //added a random item that you can pick up but only when you first get in
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
                            if(PlayerYesOrNo == 0)
                            {
                                WriteLine("You dont inspect the shiny item");
                            }
                            else if(PlayerYesOrNo == 1)
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
                    options.Add("Describe");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.WithImgageUserOptions(options, TheMap.map1, "You stand in the dusty old ball room. the darkness seems to streach on forever.");
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("The room is a large ball room. all of the tables are set up as if there was to be a ball.");
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
                        Player.CheckInventory(Player);
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
                        Player.FirstTime2 = false;
                    }
                    Clear();
                    options.Clear();
                    options.Add("Describe");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.WithImgageUserOptions(options, TheMap.map2, "You stand in the well pereserved room. the light is strangly relaxing.");
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("The room is clean and seems to have some natural light coming through a window");
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
                        Player.CheckInventory(Player);
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
                        Player.FirstTime3 = false;
                    }
                    Clear();
                    options.Clear();
                    options.Add("Describe");
                    options.Add("Search");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.WithImgageUserOptions(options, TheMap.map3, "You stand in the servent's quarters");
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("There are many drawers and a few bunk beds");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                    else if (Choice == 1)
                    {
                        if (!Player.Inventory.Contains("Key"))
                        {
                            WriteLine("There are many drawers. so you get to work looking through");
                            WriteLine("You found a key in one of the drawers");
                            Player.Inventory.Add("Key");
                            WriteLine("Press 'ENTER' to Continue");
                            ReadLine();
                        }
                        else
                        {
                            WriteLine("You have already searched this area you found a key\n maybe it could be used somwhere.");
                            WriteLine("Press 'ENTER' to Continue");
                            ReadLine();
                        }
                        
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
                        Player.CheckInventory(Player);
                    }
                }
                else if (Player.Location == 4)
                {
                    if (Player.FirstTime4)
                    {
                        WriteLine("Stepping into the room your immediately notice the plants that cover the sides of the room");
                        WriteLine("You can make out a few books on some desks and scattered around the room");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                        Player.FirstTime4 = false;
                    }
                    Clear();
                    options.Clear();
                    options.Add("Describe");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.WithImgageUserOptions(options, TheMap.map4, "You stand in the room covered in plants");
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("You can make out a few books on some desks and scattered around the room");
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
                        Player.CheckInventory(Player);
                    }
                }
                else if (Player.Location == 5)
                {
                    if (Player.FirstTime5)
                    {
                        WriteLine("You step into the room and it seems to look like and office");
                        Enemy enemy1 = new Enemy()
                        {
                            Name = "Hob-Goblin",
                            Health = 120,
                            Attack = 15
                        };
                        WriteLine("Before you could get a good look a Hob-Goblin jumps out at you");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                        Combat.SetUp(Player, enemy1);
                        WriteLine("There is a desk at the far end of the room and a smaller door on the right side of the room");
                        WriteLine("There are some papers on the desk you might be able to read them.");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                        Clear();
                        WriteLine("From what you could make out there are 4 poems that write");
                        //Kobayashi Issa (1763-1828)
                        WriteLine("1) In this world of ours\nWe walk on hell beneath us,\nGazing at flowers");
                        //Endō Atsujin (1758-1836)
                        WriteLine("2) Earth and Metal...\nAlthough my breathing ceases\nTime and tide go on.");
                        //Tachibana Genjiro (1665-1718)
                        WriteLine("3) I write, Erase, Write\nErase Again, and then\nA poppy blooms");
                        //Omoda Seiju (1771-1776)
                        WriteLine("4) Not for a moment\nDo things stand still - witness\nColour in the trees.");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                        Player.FirstTime5 = false;
                    }
                    options.Clear();
                    options.Add("Describe");
                    options.Add("Read Poems");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.WithImgageUserOptions(options, TheMap.map5, "You stand in a formal office with a large desk at the far side of the room");
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("There is a desk at the far end of the room and a smaller door on the right side of the room");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                    else if(Choice == 1)
                    {
                        Clear();
                        WriteLine("From what you could make out there are 4 poems that write");
                        //Kobayashi Issa (1763-1828)
                        WriteLine("1) In this world of ours\nWe walk on hell beneath us,\nGazing at flowers");

                        //Endō Atsujin (1758-1836)
                        WriteLine("2) Earth and Metal...\nAlthough my breathing ceases\nTime and tide go on.");

                        //Tachibana Genjiro (1665-1718)
                        WriteLine("3) I write, Erase, Write\nErase Again, and then\nA poppy blooms");

                        //Omoda Seiju (1771-1776)
                        WriteLine("4) Not for a moment\nDo things stand still - witness\nColour in the trees.");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
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
                        Player.CheckInventory(Player);
                    }
                }
                else if (Player.Location == 6)
                {
                    if (Player.FirstTime6)
                    {
                        WriteLine("You enter a small room that has a large vault");
                        Enemy enemy1 = new Enemy()
                        {
                            Name = "Goblin",
                            Health = 100,
                            Attack = 15
                        };
                        WriteLine("Befor you could get a good look a Goblin jumps out at you");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                        Combat.SetUp(Player, enemy1);
                        WriteLine("The vault has a small peice of paper attached it reads");
                        WriteLine("If you forget the password your hint is:\n'Flowers bloom on trees'");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                        Player.FirstTime6 = false;
                    }
                    Clear();
                    options.Clear();
                    options.Add("Describe");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.WithImgageUserOptions(options, TheMap.map6, "You stand in the small room next to the vault\nThe paper said the hint was:'Flowers bloom on trees'");
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("You enter a small room that has a large vault");
                        WriteLine("The vault has a small peice of paper attached it reads");
                        WriteLine("If you forget the password your hint is:\n'Flowers bloom on trees'");
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
                else if (Player.Location == 7)
                {
                    Clear();
                    options.Clear();
                    WriteLine(TheMap.map7 + "\n");
                    if (Player.FirstTime7)
                    {
                        WriteLine("You step into the vault infront of you is a pile of gold");
                        WriteLine("after you pick up the gold you hear a noise from the hallway");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                        Player.Inventory.Add("Big Pile of Gold");
                        Player.FirstTime7 = false;
                    }
                    else
                    {
                        WriteLine("The vault is now empty");
                        WriteLine("Press 'ENTER' to Continue");
                        ReadLine();
                    }
                    options.Add("Describe");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.WithImgageUserOptions(options, TheMap.map7, "You stand in a empty vault");
                    if (Choice == 0)
                    {
                        Clear();
                        WriteLine("The vault is now empty");
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
                        Player.CheckInventory(Player);
                    }
                }
                else if (Player.Location == 8)
                {
                    Clear();
                    options.Clear();
                    if (Player.Inventory.Contains("Big Pile of Gold"))
                    {
                        Ending();
                    }
                    options.Clear();
                    options.Add("Describe");
                    options.Add("Move");
                    options.Add("Rest");
                    options.Add("Check Invintory");
                    int Choice = Utility.WithImgageUserOptions(options, TheMap.map0, "You return to the hallway");
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
                        Player.CheckInventory(Player);
                    }
                }

            }
        }
        public void GameOver()
        {
            WriteLine("You Lost befor you could get the tressure");
            System.Environment.Exit(0);
        }
        public void Ending()
        {
            WriteLine("You got the tressure and made it to the exit");
            WriteLine("As you exit the building the snow has stopped.");
            System.Environment.Exit(0);

        }
    }
} 
