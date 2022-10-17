using System;
using System.Collections.Generic;
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
                WriteLine("You can go to Room(s):\n");
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
            if (player.Location == 1 || player.Location == 2 || player.Location == 3 || player.Location == 4)
            {
                options.Clear();
                options.Add("Back to the hallway");
                options.Add("Stay here");
                int MovementOptions = Utility.UserOptions(options);
                if (MovementOptions == 1)
                {
                    WriteLine("You have had enough of the dusty old room so you head out");
                    player.Location = 8;

                }
                else if (MovementOptions == 2)
                {
                    WriteLine("You decide that you want to stay in the dusty old room");
                }
                WriteLine("Press 'ENTER' to Continue");
                ReadLine();
            }
            if (player.Location == 5)
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
            if (player.Location == 6)
            {
                options.Clear();
                options.Add("Enter the room on the right");
                options.Add("Leave");
                options.Add("Stay here");
                int MovementOptions = Utility.UserOptions(options);
                if (MovementOptions == 1)
                {
                    WriteLine("You look to the door on the right side of the room");
                    WriteLine("Do you want to open the door?");
                    options.Clear();
                    options.Add("Yes");
                    options.Add("No");
                    int YesOrNo = Utility.UserOptions(options);
                    if (YesOrNo == 0)
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
        }
    }
}