using System.Runtime.CompilerServices;

namespace HANGMAN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wrongGuesses = 0; int totalGuesses = 0;
            string word = ""; String DisplayWord = "";string guess = "";
            List<string> words = new List<string>();
            bool done = false;
            bool done1 = false;
            Random random = new Random();
            List<string> wrongletters = new List<string>();
            Console.WriteLine(" Welcome to HangMan!");
            Console.WriteLine();
            Console.WriteLine(" The rules to this game are as follows:");
            Console.WriteLine(" -You have to guess the hidden word");
            Console.WriteLine(" -You have Six guesses");
            Console.WriteLine();
            



            while (!done)
            {
                done1 = false;
                Console.WriteLine("Press Enter to START");
                Console.ReadLine();
                var WORD = File.ReadAllLines("WORD.txt");
                foreach (var s in WORD)
                    words.Add(s);
                word = words[random.Next(0, words.Count)];
                Drawhanger();
                for (int i = 0; i < word.Length; i++)
                {
                    if (i % 2 != 0)
                        DisplayWord = DisplayWord.Insert(i, " ");
                    else
                        DisplayWord = DisplayWord.Insert(i, "_");
                }
                Console.WriteLine(DisplayWord);
                done = true;
                while (!done1)
                {
                    Console.Write("Pick a letter:  ");
                    guess = Console.ReadLine().ToUpper();


                    if (guess.Length == 1)
                    {
                        if (word.Contains(guess))
                        {
                            Console.WriteLine();
                            Console.WriteLine("That letter is in the word! ");
                            Console.WriteLine();
                            DisplayWord = DisplayWord.Remove(word.IndexOf(guess), 1);
                            DisplayWord = DisplayWord.Insert(word.IndexOf(guess), guess);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("That letter isn't in the word! ");
                            Console.WriteLine();
                            wrongGuesses++;
                            wrongletters.Add(guess);

                            foreach (string j in wrongletters)
                            {
                                Console.Write($"{j}, ");
                            }
                            Console.WriteLine();
                        }

                        totalGuesses++;

                        switch (wrongGuesses)
                        {
                            case 1: DrawHead(); break;
                            case 2: DrawBody(); break;
                            case 3: DrawLeftArm(); break;
                            case 4: DrawRightArm(); break;
                            case 5: DrawLeftLeg(); break;
                            case 6: DrawLoser(); break;
                        }

                        Console.WriteLine(DisplayWord);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You can only guess one at a time! ");
                        Console.WriteLine();

                    }

                    if (DisplayWord == word)
                    {
                        DrawWinner();
                        Console.WriteLine("You guessed the word! Winner!");
                        Console.WriteLine();
                        done = true;
                    }

                    if (wrongGuesses == 6)
                    {
                        Console.WriteLine("You died! LOSER!");
                        Console.WriteLine($"The word was {word}! ");
                        Console.WriteLine();
                        done1 = true;
                    }
                }


            }
        }
        static void Drawhanger()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }
        static void DrawHead()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }
        static void DrawBody()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine("  |   |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }
        static void DrawLeftArm()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine(" /|   |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }
        static void DrawRightArm()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine(" /|\\  |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }
        static void DrawLeftLeg()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine(" /|\\  |");
            Console.WriteLine(" /    |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }
        static void DrawLoser()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine(" /|\\  |");
            Console.WriteLine(" / \\  |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }
        static void DrawWinner()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine(" \\O/  |");
            Console.WriteLine("  |   |");
            Console.WriteLine(" / \\  |");
            Console.WriteLine("=========");
        }
    }
}