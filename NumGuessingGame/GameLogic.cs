using CSC160_ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumGuessingGame
{
    public class GameLogic
    {
        static Random rand = new Random();
        public static void run()
        {
            int selection = CIO.PromptForMenuSelection(new string[] { "Easy -range = 1-10, max attempts = 5", "Medium -range = 1-50, max attempts = 5", "Hard - range = 1 - 100, max attempts = 5" }, true);
            Guess(selection);
            selection = CIO.PromptForMenuSelection(new string[] { "Easy -range = 1-10, max attempts = 5", "Medium -range = 1-50, max attempts = 5", "Hard - range = 1 - 100, max attempts = 5" }, true);
            Guess(selection);
            selection = CIO.PromptForMenuSelection(new string[] { "Easy -range = 1-10, max attempts = 5", "Medium -range = 1-50, max attempts = 5", "Hard - range = 1 - 100, max attempts = 5" }, true);
            Guess(selection);
            selection = CIO.PromptForMenuSelection(new string[] { "Easy -range = 1-10, max attempts = 5", "Medium -range = 1-50, max attempts = 5", "Hard - range = 1 - 100, max attempts = 5" }, true);
            Guess(selection);
        }

        public static void Guess(int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    game(1, 10);
                    break;
                case 2:
                    game(1, 50);
                    break;
                case 3:
                    game(1, 100);
                    break;
                default:
                    break;
            }

        }

        public static void game(int min, int max)
        {
            int counter = 0;

            int[] guesses = new int[5];
            int guess = 1; ;
            bool gameWon = false;
            int randNum = rand.Next(min, max + 1);
            do
            {
                int inc = 0;
                string userIn;
                int guessCT = 1;
                int CT = 4;

                int temp = 0;
                while (inc < 5)
                {
                    Console.WriteLine("Enter guess");
                    if (inc > 4)
                    {
                        counter = 8;
                        Console.WriteLine("Out of guesses");
                        break;
                    }
                    try
                    {
                        userIn = Console.ReadLine();
                        temp = int.Parse(userIn);

                        guesses[inc] = temp;
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine("Not a number ");
                    }
                    catch (OverflowException oe)
                    {
                        Console.WriteLine("Larger than max");
                    }
                    catch (ArgumentNullException an)
                    {
                        Console.WriteLine("Null or empty input");
                    }
                    catch (IndexOutOfRangeException ie)
                    {
                        Console.WriteLine("Out of range");
                    }
                    if (temp < min || temp > max)
                    {
                        inc--;
                        CT += 1;
                        Console.WriteLine("Out of range");
                    }
                    bool stop = false;
                    while (!stop)
                    {
                        if (inc > 0)
                        {
                            if (guesses[inc] == guesses[inc - 1])
                            {
                                Console.WriteLine("Already guessed");
                                inc--;
                                CT += 1;
                                break;
                            }
                        }
                        stop = true;
                    }

                    if (temp < randNum)
                    {

                        Console.WriteLine($"Guess is Low. Guesses Left:{CT} \n");
                        CT--;
                        guessCT++;
                        counter++;

                    }
                    else if (temp > randNum)
                    {

                        Console.WriteLine($"Guess is High. Guesses Left:{CT} \n");
                        CT--;
                        counter++;
                        guessCT++;
                    }

                    else
                    {
                        Console.WriteLine("Winner!!. Guesses: " + guessCT);
                        counter = 8;
                        break;
                    }

                    inc++;
                    if (inc == 5)
                    {
                        Console.WriteLine("You have lost\n Play Again?");
                    }
                }

            } while (counter < 5);


        }


    }
}
