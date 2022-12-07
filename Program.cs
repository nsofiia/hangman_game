using System;

namespace hangman_game;

class Program
{
    const string NO_GUESS = "_";
    const int WRONG_GUESS_MAX = 3;
    const int DEFAULT = 0;

    static void Main(string[] args)
    {
        Random random = new Random();
        char guess = (char)DEFAULT;
        int wrongGuessCount = DEFAULT;
        char playGame = (char)DEFAULT;


        List<string> emptyWord = new List<string>();
        List<string> listOfWords = new List<string>();
        listOfWords.Add("cellphone");
        listOfWords.Add("notepad");
        listOfWords.Add("nutcracker");
        listOfWords.Add("beaver");
        listOfWords.Add("starfish");

        Console.WriteLine("Wanna guess a word one letter at the time?");

        //keep asking for answer if answer is not a walid letter
        do
        {
            Console.WriteLine("\npress y - to START \nany other key - to EXIT\n");
            playGame = Char.ToUpper(Console.ReadKey().KeyChar);

            if (playGame == 'Y')
            {
                Console.Clear();
                int randomWord = random.Next(listOfWords.Count);
                string wordToGuess = listOfWords[randomWord];
                int charCount = wordToGuess.Length;

                foreach (char letter in wordToGuess)  // creates empty wordspace list; letter is the iterator variable
                {
                    emptyWord.Add(NO_GUESS);
                }

                Console.WriteLine("\nOnly " + charCount + " characters!");

                printList(emptyWord);

                //Console.WriteLine("\nhint *" + wordToGuess + "*"); //print the random word selected 
                while (true)
                {
                    Console.WriteLine("Enter a letter:\n");
                    guess = Char.ToLower(Console.ReadKey().KeyChar);

                    if (Char.IsPunctuation(guess) || Char.IsWhiteSpace(guess))
                    {
                        Console.WriteLine("\nnot a letter");
                        continue;
                    }
                    if (Char.IsDigit(guess) || Char.IsSymbol(guess))
                    {
                        Console.WriteLine("\nnot a letter");
                        continue;
                    }

                    //put wrong guess counter and game exit here
                    if (!wordToGuess.Contains(guess))
                    {
                        wrongGuessCount++;
                        int lives = WRONG_GUESS_MAX - wrongGuessCount;
                        Console.WriteLine($"\n\nNope, {lives} wrong guesses left.");

                        if (wrongGuessCount == WRONG_GUESS_MAX)
                        {
                            Console.WriteLine("\nOut of tries, maybe next time. Press any key to exit.");
                            Console.ReadKey();
                            return;
                        }
                        Console.WriteLine("\nTry again. ");
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nYou guessed!\n"); // correct ***

                        //iterate through word, looking for the entered letter; index < charCount - because execution should iterate untill, and break when condition is false -> inex == charCount 
                        for (int index = DEFAULT; index < charCount; index++)
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
                        Console.WriteLine("\nHUGE WIN! Start over?\n");
                        playGame = (char)DEFAULT;
                        guess = (char)DEFAULT;
                        emptyWord.Clear();
                        break;
                    }
                    guess = (char)DEFAULT;
                }
            }

            else
            {
                return;
            }
        } while (playGame == guess);
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
}
























