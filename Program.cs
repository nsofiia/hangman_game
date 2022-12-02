using System;
using System.Diagnostics.Metrics;

namespace hangman_game;
class Program
{
    const string NO_GUESS = "_";
    const int WRONG_GUESS_MAX = 3;

    public static void printList(List<string> word)
    {
        foreach (string letter in word) // prints empty wordspace list (with guessed letters)
        {
            Console.Write(letter + " ");
        }
    }

    public static char continueOrStop(char answer)
    {
        Console.WriteLine("yes - y, any key to exit \n");
        answer = Console.ReadKey().KeyChar;
        return answer;
    }


    static void Main(string[] args)
    {
        Random random = new Random();
        char guess = '.';
        int wrongGuessCount = 0;
        char playGame = '.';

        List<string> emptyWord = new List<string>();
        List<string> listOfWords = new List<string>();
        listOfWords.Add("cellphone");
        listOfWords.Add("notepad");
        listOfWords.Add("nutcracker");
        listOfWords.Add("beaver");
        listOfWords.Add("starfish");

        Console.WriteLine("Would you like to guess the word one letter at the time?\n");

        while (playGame == '.')
        {
            //  continueOrStop(playGame);
            Console.WriteLine("yes - y, any key to exit \n");
            playGame = Console.ReadKey().KeyChar;

            if (playGame == 'y')
            {
                Console.Clear();
                int randomWord = random.Next(listOfWords.Count());
                string wordToGuess = listOfWords[randomWord];
                int charCount = wordToGuess.Length;

                foreach (char letter in wordToGuess)  // creates empty wordspace list; letter is the iterator variable
                {
                    emptyWord.Add(NO_GUESS);
                }

                printList(emptyWord);

                Console.WriteLine("\nonly " + charCount + " characters to guess!");
                Console.WriteLine("*" + wordToGuess + "*");

                while (WRONG_GUESS_MAX != wrongGuessCount)   // counting wrong guesses
                {
                    while (guess == '.')
                    {

                        while (!Char.IsLetter(guess))  //checking input
                        {
                            Console.WriteLine("\nEnter a letter:");
                            guess = Console.ReadKey().KeyChar;
                        }
                        Console.Clear();
                        if (wordToGuess.Contains(guess))    // check if guess letter is in the word to guess
                        {
                            Console.WriteLine("\nYou guessed!\n"); // correct ***

                            //iterate through word, looking for the entered letter; index < charCount - because execution should iterate untill, and break when condition is false -> inex == charCount 
                            for (int index = 0; index < charCount; index++)
                            {

                                if (wordToGuess[index] == guess)    // adding guessed letters into the correct spaces in the empty word
                                {
                                    emptyWord.RemoveAt(index);
                                    emptyWord.Insert(index, guess.ToString());
                                }
                            }

                            printList(emptyWord);
                        }

                        else // wrong - letter is not in the word to guess ***
                        {
                            wrongGuessCount++;  // decreasign the count of wrong guesses, since max wrong guesses is 3
                            Console.WriteLine($"\nTry again, you have {WRONG_GUESS_MAX - wrongGuessCount} wrong tries left");
                        }

                    }

                    //check if word is fully guessed
                    if (!emptyWord.Contains(NO_GUESS))
                    {
                        Console.WriteLine("\n\nHUGE WIN! Start over?");
                        playGame = '.';
                        Console.ReadKey();
                        Environment.Exit(1);
                        //////// how to start over ? 
                    }
                    guess = '.';
                }
                Console.WriteLine("\nGuessed wrong too many times. Press any key for exit");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

    }


}
