using System;
using System.Collections.Generic;
using System.Text;

namespace rpsls_csharp
{
    class Game
    {
        //member variables
        public Player player1;
        public Player player2;
        public int gamesToWin;

        //constructors
        public Game()
        {
            int validate;
            while (true)
            {
                try
                {
                    Console.WriteLine("Press 1 for single player");
                    Console.WriteLine("Press 2 for head to head play");
                    Console.WriteLine("Press 3 to run an AI simulation game");

                    validate = int.Parse(Console.ReadLine());
                    if (validate < 1 ||validate > 3)
                    {
                        Console.WriteLine("Oops we need a number between 1 and 3 please try again");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Oops we need a number between 1 and 3 please try again");
                }
            }
            if (validate == 1)
            {
                player1 = CreateHuman();
                player2 = new AiPlayer();
            }
            else if (validate == 2)
            {
                player1 = CreateHuman();
                player2 = CreateHuman();

            }
            else
            {
                player1 = new AiPlayer();
                player2 = new AiPlayer();
            }
            gamesToWin = BestOf();
            gamesToWin = gamesToWin / 2;
            gamesToWin++;
        }

        //member methods

        private HumanPlayer CreateHuman()
        {
            int validate;
            while (true)
            {
                try
                {
                    Console.WriteLine("Press 1 to provide your name");
                    Console.WriteLine("Press 2 to play incognito");

                    validate = int.Parse(Console.ReadLine());
                    if (validate != 1 && validate != 2)
                    {
                        Console.WriteLine("Oops we need a number between 1 and 2 please try again");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Oops we need a number between 1 and 2 please try again");
                }
            }
            if(validate == 1)
            {
                Console.WriteLine("What is your name?");
                return new HumanPlayer(Console.ReadLine());
                
            }
            else
            {
                return new HumanPlayer();
            }

        }

        private int BestOf()
        {
            int amount;
            while (true)
            {
                try
                {
                    Console.WriteLine("How many games do you want to play?");
                    Console.WriteLine("Please pick any odd number of games that is 3 or larger");

                    amount = int.Parse(Console.ReadLine());
                    if (amount < 3 || amount%2==0)
                    {
                        Console.WriteLine("Oops we need an odd number that is 3 or larger");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Oops we need an odd number that is 3 or larger");
                }
            }

            return amount;
        }

        private void DeclareWinner(Player player)
        {
            Console.WriteLine("Congratulations to {0} they have trimumped by winning {1} games", player.name, player.score);
        }
        public void GameStart()
        {
            Dictionary<string,string> p1WinResult = new Dictionary<string,string>();
            p1WinResult.Add("RockScissors", "Rock crushes Scissors");
            p1WinResult.Add("RockLizard", "Rock crushes Lizard");
            p1WinResult.Add("ScissorsPaper", "Scissors cuts Paper");
            p1WinResult.Add("ScissorsLizard", "Scissors decapitate a Lizard");
            p1WinResult.Add("PaperRock", "Paper covers Rock");
            p1WinResult.Add("PaperSpock", "Paper disproves Spock");
            p1WinResult.Add("LizardSpock", "Lizard poisons Spock");
            p1WinResult.Add("LizardPaper", "Lizard eats Paper");
            p1WinResult.Add("SpockScissors", "Spock Smashes Scissors");
            p1WinResult.Add("SpockRock", "Spock Vaporizes Rock");
            string p1;
            string p2;
            while (true)
            {
                if (this.player1.score >= this.gamesToWin)
                {
                    DeclareWinner(this.player1);
                    break;
                }
                else if (this.player2.score >= this.gamesToWin)
                {
                    DeclareWinner(this.player2);
                    break;
                }
                else
                {
                    p1 = player1.SelectSign();
                    p2 = player2.SelectSign();
                    if (p1 == p2)
                    {
                        Console.WriteLine("it was a draw as both players picked "+p1);
                    }
                    else if (p1WinResult.ContainsKey(p1 + p2))
                    {
                        Console.WriteLine(player1.name +" wins as their "+p1WinResult[p1+p2]);
                        player1.WinRound();
                    }
                    else if (p1WinResult.ContainsKey(p2 + p1))
                    {
                        Console.WriteLine(player2.name +" wins as their " + p1WinResult[p2 + p1]);
                        player2.WinRound();
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong value did not compute correctly");
                    }
                }

                
            }
        }
    }
}
