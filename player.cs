using System;
using System.Collections.Generic;
using System.Text;

namespace rpsls_csharp
{
    abstract class Player
    {
        //class properties
        public string name;
        public int score;

        //constructor methods
        public Player(string name)
        {
            this.name = name;
            score = 0;
        }
        public Player()
        {
            Random rando = new Random();
            this.name = "Challenger#:" + rando.Next(1, 10000);
            score = 0;
        }

        //class methods
        public string SelectSign(int sign)
        {
            string guestureString;
            switch (sign)
            {
                case 1:
                    guestureString = "Rock";
                    Console.WriteLine(name+" Selected "+guestureString);
                    break;
                case 2:
                    guestureString = "Paper";
                    Console.WriteLine(name + " Selected " + guestureString);
                    break;
                case 3:
                    guestureString = "Scissors";
                    Console.WriteLine(name + " Selected " + guestureString);
                    break;
                case 4:
                    guestureString = "Lizard";
                    Console.WriteLine(name + " Selected " + guestureString);
                    break;
                case 5:
                    guestureString = "Spock";
                    Console.WriteLine(name + " Selected " + guestureString);
                    break;
                default:
                    guestureString = "error";
                    Console.WriteLine(name + " Selected " + guestureString);
                    break;
            }

            return guestureString;
        }
        public abstract string SelectSign();
       
        public void WinRound()
        {
            score++;
        }
    }

    class AiPlayer:Player
    {
        //class properties

        //constructor method
        public AiPlayer(string name)
            :base(name)
        {
            
        }
        public AiPlayer()
            :base()
        {

        }

        //class methods
        public override string SelectSign()
        {
            Random r = new Random();
            int select = r.Next(1, 5);
            string guesture = SelectSign(select);
            return guesture;

        }
    }
    class HumanPlayer : Player
    {
        //constructor menthod
        public HumanPlayer(string name)
            : base(name)
        {

        }
        public HumanPlayer()
            : base()
        {

        }
        //class methods
        public override string SelectSign()
        {
            string guesture = "";
            int choice = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Please press 1 to select Rock");
                    Console.WriteLine("Please press 2 to select Paper");
                    Console.WriteLine("Please press 3 to select Scissors");
                    Console.WriteLine("Please press 4 to select Lizard");
                    Console.WriteLine("Please press 5 to select Spock");
                    int validate = int.Parse(Console.ReadLine());

                    if (validate < 1 || validate > 5)
                    {
                        Console.WriteLine("Oops we need a number between 1 and 5 please try again");
                    }
                    else
                    {
                        choice = validate;
                        break;
                    }

                }
                catch
                {
                    Console.WriteLine("Oops we need a number between 1 and 5 please try again");
                }
            }

            guesture = SelectSign(choice);
            return guesture;
        }
    }
}
