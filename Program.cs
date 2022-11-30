using System;

namespace hangman_game;
class Program
{

    static void Main(string[] args)
    {
        Random random = new Random();

        List<string> listOfWords = new List<string>();
        listOfWords.Add("cellphone");
        listOfWords.Add("notepad");
        listOfWords.Add("nutcracker");
        listOfWords.Add("beaver");
        listOfWords.Add("starfish");

        while (true)
        {
            int randomWord = random.Next(listOfWords.Count());
            List<string> wordToGuess = new List<string>();
            wordToGuess.Add(listOfWords[randomWord]);
            List<string> guessedWord = new List<string>();
            List<string> charSpace = new List<string>();
            int widthForCharSpace = wordToGuess.Count;
            string guess = "";

            Console.WriteLine("----" + wordToGuess.ToString());
            Console.WriteLine("----" + guessedWord);
            Console.WriteLine("----" + widthForCharSpace);
            Console.WriteLine("\n\nGuess the word one letter at the time!\nWhat would be your first guess?\n");


            while (guess == "")
            {
                guess = Console.ReadLine().ToLower();


                for (int index = 0; index < widthForCharSpace - 1; index++)
                {
                    if (wordToGuess.ElementAt(index) == guess)
                    {
                        Console.WriteLine("You guessed!");
                        break;
                    }
                    else
                    {
                        if (index == widthForCharSpace - 1)
                        {
                            Console.WriteLine("nope");
                        }
                    }


                }


                foreach (string letter in wordToGuess)
                {
                    if (letter == guess)
                    {
                        Console.Write(guess);
                    }
                    else
                    {
                        Console.Write(charSpace);
                    }
                }
                guess = "";
            }

            foreach (string letter in wordToGuess)
            {
                Console.Write(charSpace);
            }


        }


        //for (char letter in wordToGuess)
        //{
        //    if (letter == guess)
        //    {
        //        Console.Write(guess);
        //    }
        //    else
        //    {
        //        Console.Write(charSpace);
        //    }
        //}


        //static string HaveLetter(string guess)
        //{
        //    if 
        //}

        //for (char letter == answer in wordToGuess)
        //{
        //    Console.Write(letter);
        //}





        Console.ReadKey();

    }
}

