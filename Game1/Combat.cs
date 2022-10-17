using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Game1
{
    internal class Combat
    {
        public Player player1 { get; set; }
        public Enemy enemy1 { get; set; }
        public int PlayerHealth { get; set; } 
        public string PlayerName { get; set; }
        public int PlayerDamage { get; set; }
        public int EnemyHealth { get; set; }
        public string EnemyName { get; set; }
        public string EnemyAction { get; set; }
        public int EnemyDamage { get; set; }
        public bool Victory { get; set; } = false;
        public bool Loss { get; set; } = false;
        public Utility utility { get; set; } = new Utility();
        public PlayArea playArea { get; set; }
        public void SetUp(Player player, Enemy enemy)
        {
            //get Player stats
            player1 = player;
            PlayerHealth = player.Health;
            PlayerName = player.Name;
            PlayerDamage = player.Attack;
            //get Enemy stats
            enemy1 = enemy;
            EnemyHealth = enemy.Health;
            EnemyName = enemy.Name;
            EnemyDamage = enemy.Attack;
            //start Combat
            Start();
        }
        public void Start()
        {
            if (player1.Health == 0)
            {
                Loss = true;
            }
            if (enemy1.Health == 0)
            {
                Victory = true;
            }
            if (Loss == true)
            {
                playArea.GameOver();
            }
            if (Victory == true)
            {
                WriteLine($"You defeted the {EnemyName} Congrats");
                WriteLine("press 'ENTER' to continue");
                ReadLine();
                playArea.Play();
            }
            if (!Victory && !Loss)
            {
                EnemyAction = GetEnemyAction();
                WriteLine($"Your Health: {PlayerHealth}");
                WriteLine($"Enemy Health: {EnemyHealth}");
                WriteLine("What would you like to do?");
                List<string> Options = new List<string>();
                Options.Add("Attack");
                Options.Add("shield");
                Options.Add("Heal");
                int Choice = Utility.UserOptions(Options);
                if (Choice == 0)
                {
                    Attack();
                }
                else if (Choice == 1)
                {
                    shield();
                }
                else if (Choice == 2)
                {
                    Heal();
                }
            }
            
        }
        public void Attack()
        {
            if(EnemyAction == "Attack")
            {
                WriteLine($"As you attack the {EnemyName} for {PlayerDamage} damage, They slash back doing {EnemyDamage}");
                EnemyHealth -= PlayerDamage;
                PlayerHealth -= EnemyDamage;
                Start();

            }
            else if(EnemyAction == "Block")
            {
                WriteLine($"As you attack the {EnemyName} for {PlayerDamage} damage, They block reducing the effectiveness of your strike.");
                //reduce the damage of the player attack
                player1.Attack -= 5;
                EnemyHealth -= player1.Attack;
                //reset the player damage after a block
                player1.Attack = PlayerDamage;
                Start();
            }
        }
        public void shield()
        {
            if (EnemyAction == "Attack")
            {
                WriteLine($"The {EnemyName} lunged at you. You reduced the damage with your shield");
                //reduce the damage of the Enemy attack
                enemy1.Attack -= 5;
                PlayerHealth -= enemy1.Attack;
                //reset the Enemy damage after a block
                enemy1.Attack = EnemyDamage;
                WriteLine("press 'ENTER' to continue");
                ReadLine();
                Start();
            }
            else if (EnemyAction == "Block")
            {
                //both the player and the Enemy blocked
                WriteLine($"both you and the {EnemyName} cower in fear behind your shields");
                WriteLine("and nothing happens");
                WriteLine("press 'ENTER' to continue");
                ReadLine();
                Start();
            }
        }
        public void Heal()
        {
            if (EnemyAction == "Attack")
            {
                //goes through every item in the inventory and finds out if the player has a potion
                for (int i = 0; i < player1.Inventory.Count; i++)
                {
                    //if they have the potion they use it
                    if (player1.Inventory[i] == "Potion")
                    {
                        WriteLine($"You drink the potion but as you do the {EnemyName} attacks you");
                        WriteLine($"You take {enemy1.Attack} but heal 20hp");
                        player1.Health -= enemy1.Attack;
                        WriteLine("press 'ENTER' to continue");
                        ReadLine();
                        Start();
                    }
                    
                }
                //they cant drink a potion if they dont have one   
                WriteLine("You dont have a potion to drink");
                WriteLine("press 'ENTER' to continue");
                ReadLine();
                Start();

            }
            else if (EnemyAction == "Block")
            {
                for (int i = 0; i < player1.Inventory.Count; i++)
                {
                    if (player1.Inventory[i] == "Potion")
                    {
                        WriteLine($"The {EnemyName} hides behind his shield thinking you were going to strike");
                        WriteLine("You drink the potion and heal 20hp");
                        player1.Health -= enemy1.Attack;
                        WriteLine("press anything to continue");
                        ReadLine();
                        Start();
                    }
                }
            }
        }
        public string GetEnemyAction()
        {
            Random rnd = new Random(2);
            if (rnd.Next(1) == 0)
            {
                return "Attack";
            }
            else if (rnd.Next(1) == 1)
            {
                return "Block";
            }
            else
            {
                return GetEnemyAction();
            }
        }
    }
}
