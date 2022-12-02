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
        List<string> emptyWord = new List<string>();
        List<string> listOfWords = new List<string>();
        listOfWords.Add("cellphone");
        listOfWords.Add("notepad");
        listOfWords.Add("nutcracker");
        listOfWords.Add("beaver");
        listOfWords.Add("starfish");

        Console.WriteLine("Would you like to guess the word one letter at the time?\nyes - y, any key to exit \n");
        char playGame = Console.ReadKey().KeyChar;
        if (playGame == 'y')
        {
            Console.Clear();
            int randomWord = random.Next(listOfWords.Count());
            string wordToGuess = listOfWords[randomWord];
            int charCount = wordToGuess.Length;

            foreach (char letter in wordToGuess)  // creates empty wordspace list
            {
                emptyWord.Add(noGuess);
            }
            foreach (string letter in emptyWord) // prints empty wordspace list
            {
                Console.Write(letter + " ");
            }

            Console.WriteLine("\nonly " + charCount + " characters to guess!");
            Console.WriteLine("*" + wordToGuess + "*");



            while (wrongGuessCount > 0)   // counting wrong guesses
            {
                while (!Char.IsLetter(guess))
                {
                    Console.WriteLine("\nEnter a letter:");

                    guess = Console.ReadKey().KeyChar;
                }
                if (wordToGuess.Contains(guess))    // check if guess letter is in the word to guess
                {
                    Console.WriteLine("\nYou guessed!\n");

                    for (int index = charCount - 1; index > 0; index--)
                    {
                        //Console.WriteLine(wordToGuess[index] + " , " + guess);
                        if (wordToGuess[index] == guess)
                        {
                            emptyWord.RemoveAt(index);
                            emptyWord.Insert(index, guess.ToString());
                        }
                    }
                    foreach (string letter in emptyWord) // prints empty wordspace list
                    {
                        Console.Write(letter + " ");
                    }
                }

            }
        }
    }
}





//-- negative scenario - if guessed wrong the letter 

//                    //    for (int i = guess; i < charCount; i++)
//                    //    {
//                    //        if (guess.Equals(wordToGuess[i]))
//                    //        {
//                    //            emptyWord[i].ToString().ReplaceLineEndings(wordToGuess[i].ToString());
//                    //        }
//                    //    }
//                    //    foreach (string letter in emptyWord)  // prints empty with guesses
//                    //    {
//                    //        Console.Write(letter);
//                    //    }
//                    //    if (emptyWord.ToString() == wordToGuess)
//                    //    {
//                    //        Console.WriteLine("You won! Start over? " +
//                    //            "\nEnter y - to start over, enter any other key to Exit\n");
//                    //        startOver = Console.ReadKey().KeyChar;
//                    //        if (startOver == 'y')
//                    //        {
//                    //            break;
//                    //        }
//                    //        else
//                    //        {
//                    //            Environment.Exit(1);
//                    //        }
//                    //    }
//                    //}
//                    else
//                    {
//                        wrongGuessCount--;
//                        if (wrongGuessCount != 0)
//                        {
//                            Console.WriteLine($"\nTry again, you have {wrongGuessCount} wrong tries left");
//                        }
//                    }
//                    guess = '.';
//                }
//                Console.WriteLine("\nGuessed wrong too many times. Press any key for exit");
//                Console.ReadKey();
//                Environment.Exit(1);
//            }

//        }
//        else
//        {
//            Environment.Exit(1);
//        }
//        Console.ReadKey();
//    }

//}


