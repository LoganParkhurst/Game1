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
        public int HealAmount { get; set; } = 50;
        public int PlayerHealth { get; set; } 
        public string PlayerName { get; set; }
        public int PlayerDamage { get; set; }
        public int EnemyHealth { get; set; }
        public string EnemyName { get; set; }
        public string EnemyAction { get; set; }
        public int EnemyDamage { get; set; }
        public bool Victory { get; set; }
        public bool Loss { get; set; }
        public bool InCombat { get; set; }
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
            //clean slate
            Victory = false;
            Loss = false;
            //start Combat
            Start();
        }
        public void Start()
        {
            if (PlayerHealth == 0 )
            {
                playArea.GameOver();
            }
            if (enemy1.Health == 0)
            {
                WriteLine($"You defeted the {EnemyName} Congrats");
                WriteLine($"Would you like to loot the {EnemyName}? Y or N");
                string YoN = ReadLine().ToLower();
                if(YoN == "y")
                {

                }
                WriteLine("press 'ENTER' to continue");
                ReadLine();
            }
            while(PlayerHealth > 0 && EnemyHealth > 0)
            {
                Clear();
                if(EnemyHealth > 0)
                {
                    EnemyAction = GetEnemyAction();
                }
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
                PlayerDamage -= 5;
                EnemyHealth -= PlayerDamage;
                //reset the player damage after a block
                PlayerDamage = player1.Attack;
                Start();
            }
        }
        public void shield()
        {
            if (EnemyAction == "Attack")
            {
                WriteLine($"The {EnemyName} lunged at you. You reduced the damage with your shield");
                //reduce the damage of the Enemy attack
                EnemyDamage -= 5;
                PlayerHealth -= enemy1.Attack;
                //reset the Enemy damage after a block
                EnemyDamage = EnemyDamage;
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
                    //if they have the potion they use it
               if (player1.Inventory.Contains("Potion"))
               {
                    WriteLine($"You drink the potion but as you do the {EnemyName} attacks you");
                    WriteLine($"You take {EnemyDamage} but heal {HealAmount}hp");
                    PlayerHealth -= EnemyDamage;
                    PlayerHealth += HealAmount;
                    WriteLine("press 'ENTER' to continue");
                    ReadLine();
                    Start();
               }
                //they cant drink a potion if they dont have one   
                WriteLine("You dont have a potion to drink");
                WriteLine("press 'ENTER' to continue");
                ReadLine();
                Start();

            }
            else if (EnemyAction == "Block")
            {
                if (player1.Inventory.Contains("Potion"))
                {
                    WriteLine($"You drink the potion but as you do the {EnemyName} attacks you");
                    WriteLine($"You take {EnemyDamage} but heal {HealAmount}hp");
                    PlayerHealth += HealAmount;
                    WriteLine("press 'ENTER' to continue");
                    ReadLine();
                    Start();
                }
                //they cant drink a potion if they dont have one   
                WriteLine("You dont have a potion to drink");
                WriteLine("press 'ENTER' to continue");
                ReadLine();
                Start();
            }
        }
        public string GetEnemyAction()
        {
            Random rnd = new Random();
            int enemyChoice = rnd.Next(0, 2);
            if (enemyChoice == 0)
            {
                return "Attack";
            }
            else
            {
                return "Block";
            }
            
        }
    }
}
