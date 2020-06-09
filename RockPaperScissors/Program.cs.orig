using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string PlayAgain = "";
            int Ties = 0;
            int ComputerWins = 0;
            int UserWins = 0;
            // Loop will continue until user enter "NO" at end of rounds.
            while (PlayAgain != "NO")
            {
                Console.WriteLine("Let's Play Rock, Paper, Scissors!");
                Console.WriteLine("How many rounds would you like to play? 1 - 10\n");
                String Rounds = Console.ReadLine();
                // Convert input string into a int.
                
                bool Round = int.TryParse(Rounds, out int num);

                if (!Round)
                {
                    Console.WriteLine("Lets enter a number between 1 - 10 please.\n");
                    continue;
                }
                // If User enter # larger than 10 the program end.
                else if (num > 10 || num < 1)
                {
                    Console.WriteLine("Number was not in range.");
                    break;
                }
                // Random Object.
                Random rnd = new Random();

                // Looping thur the number of rounds given by user.
                for (int i = 0; i < num; i++)
                {
                    // User Choose.
                    Console.WriteLine("\nChoose Rock = 1, Paper = 2, Scissors = 3.\n");
                    String UserChoice = Console.ReadLine();
                    bool UserPick = int.TryParse(UserChoice, out int number);

                    // Generating random choose for computer.
                    String[] Choices = new string[3] { "Rock", "Paper", "Scissors" };
                    int ComputerChoice = rnd.Next(Choices.Length);

                    int Rock = 1;
                    int Paper = 2;
                    int Scissors = 3;
                        
                        
                    if (number > 3 || number < 1)
                    {
                        Console.WriteLine("Your Number was not in range of options");
                        i -= 1;
                        continue;
                    }
                    //Paper beats Rock.
                    if (number == Paper && ComputerChoice == 0 || number == Rock && ComputerChoice == 2 || number == Scissors && ComputerChoice == 1)
                    {
                        Console.WriteLine("User Wins!");
                        string Results = string.Format("You choose: {0}. Computer choose: {1}.", number, Choices[ComputerChoice]);
                        Console.WriteLine(Results);
                        UserWins += 1;
                    }
                    else if (number == Rock && ComputerChoice == 1 || number == Scissors && ComputerChoice == 0 || number == Paper && ComputerChoice == 2)
                    {
                        Console.WriteLine("Computer Wins!");
                        string Results = string.Format("You choose: {0}. Computer choose: {1}.", number, Choices[ComputerChoice]);
                        Console.WriteLine(Results);
                        ComputerWins += 1;
                    }  
                    else
                    {
                        Console.WriteLine("We got a draw!");
                        Ties += 1;
                    }
                }
        
            // If user selects "NO" then tally of scores will print out. If not, the tack of wins and ties continue.
            Console.WriteLine("User won " + UserWins + " rounds.");
            Console.WriteLine("Computer won " + ComputerWins + " rounds.");
            Console.WriteLine("You guys tied " + Ties + " rounds.");
            UserWins = 0;
            ComputerWins = 0;
            Ties = 0;
            Console.WriteLine("Would you like to play again? YES/NO");
            PlayAgain = Console.ReadLine().ToUpper();
            }  
        }
    }
}
