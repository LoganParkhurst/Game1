using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Game1
{
    internal class Utility
    {
        //We created this in class
        public static int UserOptions(List<string> options)
        {
            WriteLine($"Please enter a number between 1 and {options.Count}");
            for (int i = 0; i < options.Count; i++)
            {
                WriteLine($"{i + 1}) {options[i]}");
            }
            int result = -1;
            try
            {
                result = int.Parse(ReadLine());
                result--;
            }
            catch (Exception)
            {

            }
            if(result >= 0 && result < options.Count)
            {
                return result;
            }
            else
            {
                WriteLine($"Not a valid input. please input a number between 1 and {options.Count}.");
                Thread.Sleep(3500);
                return UserOptions(options);
            }
        }
    }
}
