using System;

namespace hangman_game;

class Program
{
    const string NO_GUESS = "_";
    const int WRONG_GUESS_MAX = 3;

    static void Main(string[] args)
    {
        Random random = new Random();
        char guess = '0';
        int wrongGuessCount = 0;
        char playGame = '0';


        List<string> emptyWord = new List<string>();
        List<string> listOfWords = new List<string>();
        listOfWords.Add("cellphone");
        listOfWords.Add("notepad");
        listOfWords.Add("nutcracker");
        listOfWords.Add("beaver");
        listOfWords.Add("starfish");

        Console.WriteLine("Guess the word one letter at the time! Strat?");

        //keep asking for answer if answer is not a walid letter
        while (!Char.IsLetter(playGame))
        {
            Console.WriteLine("\ny - start playng; any other key - to exit this game\n");
            playGame = Console.ReadKey().KeyChar;

            if (playGame == 'y' || playGame == 'Y')
            {
                Console.Clear();
                int randomWord = random.Next(listOfWords.Count());
                string wordToGuess = listOfWords[randomWord];
                int charCount = wordToGuess.Length;

                foreach (char letter in wordToGuess)  // creates empty wordspace list; letter is the iterator variable
                {
                    emptyWord.Add(NO_GUESS);
                }

                Console.WriteLine("\nGot lucky, only " + charCount + " characters!");

                printList(emptyWord);

                //Console.WriteLine("\nhint *" + wordToGuess + "*"); //print the random word selected 

                while (!Char.IsLetter(guess))  //checking input
                {
                    Console.WriteLine("Enter a letter:\n");
                    guess = Console.ReadKey().KeyChar;

                    //put wron guess counter and game exit here
                    if (!wordToGuess.Contains(guess))
                    {
                        wrongGuessCount++;
                        int lives = WRONG_GUESS_MAX - wrongGuessCount;
                        Console.WriteLine($"\n\nNope, {lives} wrong guesses left.");

                        if (wrongGuessCount == WRONG_GUESS_MAX)
                        {
                            Console.WriteLine("\nOut of tries, maybe next time. Press any key to exit.");
                            Console.ReadKey();
                            Environment.Exit(1);
                        }
                        Console.WriteLine("\nYou are close! Try again. ");
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nYou guessed!\n"); // correct ***

                        //iterate through word, looking for the entered letter; index < charCount - because execution should iterate untill, and break when condition is false -> inex == charCount 
                        for (int index = 0; index < charCount; index++)
                        {

                            if (wordToGuess[index] == guess) // adding guessed letters into the correct spaces in the empty word
                            {
                                emptyWord.RemoveAt(index);
                                emptyWord.Insert(index, guess.ToString());
                            }
                        }

                        printList(emptyWord);
                    }

                    //check if all letters in the word are guessed
                    if (!emptyWord.Contains(NO_GUESS))
                    {
                        Console.WriteLine("\n\nHUGE WIN! Start over?");
                        playGame = '0';
                        guess = '.';
                        emptyWord.Clear();
                        break;
                    }
                    guess = '.';
                }
            }

            else
            {
                Environment.Exit(1);
            }
        }
    }

    public static void printList(List<string> word)
    {
        Console.WriteLine("\n\n");
        foreach (string letter in word) // prints empty wordspace list (with guessed letters)
        {
            Console.Write(letter + " ");
        }
        Console.WriteLine("\n\n");
    }

    public static char continueOrStop(char answer) //doesn't work as expected
    {
        Console.WriteLine("yes - y, any key to exit \n");
        answer = Console.ReadKey().KeyChar;
        return answer;
    }
}
























