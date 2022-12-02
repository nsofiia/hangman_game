using System;
using System.Diagnostics.Metrics;

namespace hangman_game;
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int wrongGuessCount = 3;
        char guess = '.';
        char startOver = '.';
        string noGuess = "_";
        string emptyWord = "";
        //  List<string> emptyWord = new List<string>();
        List<string> listOfWords = new List<string>();
        listOfWords.Add("cellphone");
        listOfWords.Add("notepad");
        listOfWords.Add("nutcracker");
        listOfWords.Add("beaver");
        listOfWords.Add("starfish");

        while (true)
        {
            int randomWord = random.Next(listOfWords.Count());
            string wordToGuess = listOfWords[randomWord];
            int charCount = wordToGuess.Length;


            Console.WriteLine("\nGuess the word one letter at the time!\n");

            foreach (char letter in wordToGuess)  // prints empty wordspace
            {
                emptyWord += noGuess;
            }
            Console.Write(emptyWord);

            Console.WriteLine("\n" + charCount + " characters");
            Console.WriteLine("----" + wordToGuess);

            while (guess == '.')
            {
                while (wrongGuessCount > 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nEnter your guess");
                    guess = Console.ReadKey().KeyChar;

                    if (wordToGuess.Contains(guess))
                    {
                        Console.WriteLine("\nYou guessed!");
                        for (int i = guess; i < charCount; i++)
                        {
                            if (guess.Equals(wordToGuess[i]))
                            {
                                emptyWord[i].ToString().ReplaceLineEndings(wordToGuess[i].ToString());
                            }
                        }
                        foreach (char letter in emptyWord)  // prints empty with guesses
                        {
                            Console.Write(letter);
                        }
                        if (emptyWord.ToString() == wordToGuess)
                        {
                            Console.WriteLine("You won! Start over? " +
                                "\nEnter y - to start over, enter any other key to Exit\n");
                            startOver = Console.ReadKey().KeyChar;
                            if (startOver == 'y')
                            {
                                break;
                            }
                            else
                            {
                                Environment.Exit(1);
                            }
                        }
                    }
                    else
                    {
                        wrongGuessCount--;
                        if (wrongGuessCount != 0)
                        {
                            Console.WriteLine($"\nTry again, you have {wrongGuessCount} wrong tries left");
                        }
                    }
                    guess = '.';
                }
                Console.WriteLine("\nGuessed wrong too many times. Press any key for exit");
                Console.ReadKey();
                Environment.Exit(1);
            }

        }
        Console.ReadKey();
    }

}


