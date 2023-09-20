using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = 100, bet;
            string outcome;
            bool valid;
            Die die1 = new Die();
            System.Threading.Thread.Sleep(1000);
            Die die2 = new Die();
            while (money != 0)
            {
                Console.WriteLine($"You Currently Have {money.ToString("C")} Remaining");
                Console.Write("Enter Your Bet Amount: $");
                if (Double.TryParse(Console.ReadLine(), out bet))
                {
                    if (bet < 0)
                    {
                        bet = 0;
                    }
                    else if (bet > money)
                    {
                        bet = money;
                    }
                }
                else
                {
                    bet = 0;
                }
                valid = false;
                while (valid == false)
                {
                    Console.WriteLine("Choose an outcome to bet on...");
                    Console.WriteLine("Doubles: Win double your bet (2x). ex. Bet is $5, user wins $10 for a total of $110");
                    Console.WriteLine("Not Double: Win half your bet. ex. Bet is $10, user wins $5 for a total of $105");
                    Console.WriteLine("Even Sum: Win your bet. ex. Bet is $10, user wins $10 for a total of $110");
                    Console.WriteLine("Odd Sum: Win their bet. ex. Bet is $10, user wins $10 for a total of $110");
                    outcome = Console.ReadLine().ToLower();
                    switch (outcome)
                    {
                        case "doubles":
                            valid = true;
                            die1.RollDie();
                            Console.WriteLine($"You rolled a {die1}");
                            die1.DrawDie();
                            die2.RollDie();
                            Console.WriteLine($"You rolled a {die2}");
                            die2.DrawDie();
                            if (die1.Roll == die2.Roll)
                            {
                                money += bet * 2;
                            }
                            else
                            {
                                money -= bet;
                            }
                            break;
                        case "not double":
                            valid = true;
                            die1.RollDie();
                            Console.WriteLine($"You rolled a {die1}");
                            die1.DrawDie();
                            die2.RollDie();
                            Console.WriteLine($"You rolled a {die2}");
                            die2.DrawDie();
                            if (die1.Roll != die2.Roll)
                            {
                                money += bet / 2;
                            }
                            else
                            {
                                money -= bet;
                            }
                            break;
                        case "even sum":
                            valid = true;
                            die1.RollDie();
                            Console.WriteLine($"You rolled a {die1}");
                            die1.DrawDie();
                            die2.RollDie();
                            Console.WriteLine($"You rolled a {die2}");
                            die2.DrawDie();
                            if ((die1.Roll + die2.Roll) % 2 == 0)
                            {
                                money += bet;
                            }
                            else
                            {
                                money -= bet;
                            }
                            break;
                        case "odd sum":
                            valid = true;
                            die1.RollDie();
                            Console.WriteLine($"You rolled a {die1}");
                            die1.DrawDie();
                            die2.RollDie();
                            Console.WriteLine($"You rolled a {die2}");
                            die2.DrawDie();
                            if ((die1.Roll + die2.Roll) % 2 != 0)
                            {
                                money += bet;
                            }
                            else
                            {
                                money -= bet;
                            }
                            break;
                        default:
                            Console.WriteLine(outcome + " is not a valid outcome, try again");
                            break;
                    }
                }
            }
            Console.WriteLine("You are now broke, try gamble responsibly in the future!");
            System.Threading.Thread.Sleep(5000);
            Environment.Exit(0);
        }
    }
}
