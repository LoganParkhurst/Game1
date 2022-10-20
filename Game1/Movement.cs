using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Game1
{
    internal class Movement
    {

        public void PlayerMovement(List<string> options, Player player)
        {
            if (player.Location == 0)
            {
                Clear();
                options.Clear();
                options.Add("1");
                options.Add("2");
                options.Add("3");
                int movementOptions = Utility.UserOptions(options);
                if (movementOptions == 0)
                {
                    options.Clear();
                    WriteLine("you walk to the first room on the left. there are two large wooden doors that are covered in dust");
                    WriteLine("Would you like to open the doors?");
                    options.Add("Yes");
                    options.Add("No");
                    int yesOrNo = Utility.UserOptions(options);
                    if (yesOrNo == 0)
                    {
                        WriteLine("With a big push the dusty doors open with an eerie creek");
                        player.Location = 1;
                    }
                    else
                    {
                        WriteLine("You decide to not open the old dust door");
                    }

                }
                else if (movementOptions == 1)
                {
                    options.Clear();
                    WriteLine("You move to the first door on the right.\nA large wooden door with a metal handle.");
                    WriteLine("Would you like to open the door?");
                    options.Add("Yes");
                    options.Add("No");
                    int yesOrNo = Utility.UserOptions(options);
                    if (yesOrNo == 0)
                    {

                        WriteLine("you pull the door slowly.");
                        player.Location = 2;
                    }
                    else
                    {
                        WriteLine("You decide to not open the old dust door");
                    }
                }
                else if (movementOptions == 2)
                {
                    options.Clear();
                    WriteLine("You move to the second door on the right.\nA small wooden door you can see light streaming though.");
                    WriteLine("Would you like to open the door?");
                    options.Add("Yes");
                    options.Add("No");
                    int yesOrNo = Utility.UserOptions(options);
                    if (yesOrNo == 0)
                    {

                        WriteLine("you pull the door slowly.");
                        player.Location = 3;
                    }
                    else
                    {
                        WriteLine("You decide to not open the old dust door");
                    }
                }
                WriteLine("Press 'ENTER' to Continue");
                ReadLine();
            }
            else if (player.Location == 1 || player.Location == 2 || player.Location == 3 || player.Location == 4)
            {
                options.Clear();
                options.Add("Back to the hallway");
                options.Add("Stay here");
                int MovementOptions = Utility.UserOptions(options);
                if (MovementOptions == 0)
                {
                    WriteLine("You have had enough of the dusty old room so you head out");
                    player.Location = 8;

                }
                else if (MovementOptions == 1)
                {
                    WriteLine("You decide that you want to stay in the dusty old room");
                }
                WriteLine("Press 'ENTER' to Continue");
                ReadLine();
            }
            else if (player.Location == 5)
            {
                options.Clear();
                options.Add("Enter the room on the right");
                options.Add("Back to the hallway");
                options.Add("Stay here");
                int MovementOptions = Utility.UserOptions(options);
                if (MovementOptions == 1)
                {
                    WriteLine("You look to the door on the right side of the room");
                    WriteLine("Do you want to open the door?");
                    options.Clear();
                    options.Add("Yes");
                    options.Add("No");
                    int yesOrNo = Utility.UserOptions(options);
                    if (yesOrNo == 0)
                    {
                        WriteLine("you pull the door slowly.");
                        player.Location = 7;
                    }
                    else
                    {
                        WriteLine("You decide to not open the old dust door");
                    }
                    WriteLine("Press 'ENTER' to Continue");
                    ReadLine();
                }
                else if (MovementOptions == 2)
                {
                    WriteLine("You have had enough of the dusty old room so you head out");
                    player.Location = 8;
                }
                else if (MovementOptions == 3)
                {
                    WriteLine("You decide that you want to stay in the dusty old room");
                }
            }
            else if (player.Location == 6)
            {
                options.Clear();
                options.Add("Enter the room on the right");
                options.Add("Leave");
                options.Add("Stay here");
                int MovementOptions = Utility.UserOptions(options);
                if (MovementOptions == 1)
                {
                    WriteLine("You look at the vault and the keypad in the center of the door");
                    WriteLine("Do you want to input a code to open the door? you will enter the 4 digits one by one.");
                    options.Clear();
                    options.Add("1");
                    options.Add("2");
                    options.Add("3");
                    options.Add("4");
                    List<int> Ints = new List<int>();
                    //password is 1324
                    List<int> Password = new List<int>();
                    Password.Clear();
                    Password.Add(0);
                    Password.Add(2);
                    Password.Add(1);
                    Password.Add(3);
                    for (int i = 0; i <= 4; i++)
                    {
                        WriteLine($"Number {i}:");
                        int Choice = Utility.UserOptions(options);
                        Ints.Add(Choice);
                    }
                    if(Ints == Password)
                    {
                        WriteLine("The vault door makes a loud thunk as it slowly opens");
                        player.Location = 7;
                    }
                    else
                    {
                        WriteLine("All of the dials turn back to zero");
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine($"{player.Name}: Guess that wasn't the password");
                        ForegroundColor = ConsoleColor.White;
                    }

                    WriteLine("Press 'ENTER' to Continue");
                    ReadLine();
                }
                else if (MovementOptions == 2)
                {
                    options.Clear();
                    WriteLine("You have had enough of the dusty old room so you head out");
                    WriteLine("Would you like to go back to the hallway or the last room?");
                    options.Add("hallway");
                    options.Add("last room");
                    int HallOrNah = Utility.UserOptions(options);
                    if (HallOrNah == 0)
                    {
                        player.Location = 8;
                    }
                    else if(HallOrNah == 1)
                    {
                        player.Location = 5;
                    }
                    WriteLine("Press 'ENTER' to Continue");
                    ReadLine();
                }
                else if (MovementOptions == 3)
                {
                    WriteLine("You decide that you want to stay in the dusty old room");
                    WriteLine("Press 'ENTER' to Continue");
                    ReadLine();
                }
            }
            else if (player.Location == 8)
            {
                options.Clear();
                WriteLine("You Can go to all of the doors");
                options.Clear();
                options.Add("1");
                options.Add("2");
                options.Add("3");
                options.Add("4");
                options.Add("5");
                int movementOptions = Utility.UserOptions(options);
                if (movementOptions == 0)
                {
                    options.Clear();
                    WriteLine("You move to the first door on the right.\nA large wooden door with a metal handle.");
                    WriteLine("Would you like to open the door?");
                    options.Add("Yes");
                    options.Add("No");
                    int yesOrNo = Utility.UserOptions(options);
                    if (yesOrNo == 0)
                    {

                        WriteLine("you pull the door slowly.");
                        player.Location = 1;
                    }
                    else
                    {
                        WriteLine("You decide to not open the old dust door");
                    }
                }
                else if(movementOptions == 1)
                {
                    options.Clear();
                    WriteLine("You move to the first door on the right.\nA large wooden door with a metal handle. There is light coming through the bottom of the door.");
                    WriteLine("Would you like to open the door?");
                    options.Add("Yes");
                    options.Add("No");
                    int yesOrNo = Utility.UserOptions(options);
                    if (yesOrNo == 0)
                    {

                        WriteLine("you pull the door slowly.");
                        player.Location = 2;
                    }
                    else
                    {
                        WriteLine("You decide to not open the old dust door");
                    }
                }
                else if (movementOptions == 2)
                {
                    options.Clear();
                    WriteLine("You move to the second door on the right.\nA small wooden door you can see light streaming though.");
                    WriteLine("Would you like to open the door?");
                    options.Add("Yes");
                    options.Add("No");
                    int yesOrNo = Utility.UserOptions(options);
                    if (yesOrNo == 0)
                    {

                        WriteLine("you pull the door slowly.");
                        player.Location = 3;
                    }
                    else
                    {
                        WriteLine("You decide to not open the old dust door");
                    }
                }
                else if (movementOptions == 3)
                {
                    options.Clear();
                    WriteLine("This door has a flower painted on it.\n it seems to be more modern then the rest of the building.");
                    WriteLine("Would you like to open the door?");
                    options.Add("Yes");
                    options.Add("No");
                    int yesOrNo = Utility.UserOptions(options);
                    if (yesOrNo == 0)
                    {

                        WriteLine("you pull the door slowly.");
                        player.Location = 4;
                    }
                    else
                    {
                        WriteLine("You decide to not open the flower door");
                    }
                }
                else if (movementOptions == 4)
                {
                    if (player.GotKey)
                    {
                        WriteLine("you use the key that you picked up and unlock the door."); 
                        options.Clear();
                        WriteLine("Would you like to open the door?");
                        options.Add("Yes");
                        options.Add("No");
                        int yesOrNo = Utility.UserOptions(options);
                        if (yesOrNo == 0)
                        {

                            WriteLine("you pull the door slowly.");
                            player.Location = 5;
                        }
                        else
                        {
                            WriteLine("You decide to not open the old dust door");
                        }
                    }
                    else
                    {
                        WriteLine("The door is locked");
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("maybe there is a key around here");
                        ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }
    }
}