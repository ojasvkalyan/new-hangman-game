using System;
using System.Linq;

class Program
{
    static string[] words = { "apple", "banana", "orange", "grape", "strawberry", "kiwi" };
    static Random rnd = new Random();

    static void Main(string[] args)
    {
        string wordToGuess = words[rnd.Next(words.Length)];
        char[] guessedWord = new char[wordToGuess.Length];
        bool[] guessedLetters = new bool[26];
        int attemptsLeft = 6;

        for (int i = 0; i < wordToGuess.Length; i++)
        {
            guessedWord[i] = '_';
        }

        while (attemptsLeft > 0)
        {
            Console.Clear();
            DisplayHangman(attemptsLeft);
            DisplayWord(guessedWord);
            DisplayGuessedLetters(guessedLetters);

            Console.WriteLine("\nEnter a letter: ");
            char guess = Char.ToLower(Console.ReadKey().KeyChar);

            if (!char.IsLetter(guess))
            {
                Console.WriteLine("\nPlease enter a valid letter.");
                Console.ReadKey();
                continue;
            }

            if (guessedLetters[guess - 'a'])
            {
                Console.WriteLine("\nYou've already guessed this letter.");
                Console.ReadKey();
                continue;
            }

            guessedLetters[guess - 'a'] = true;

            if (wordToGuess.Contains(guess))
            {
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                    {
                        guessedWord[i] = guess;
                    }
                }
            }
            else
            {
                attemptsLeft--;
            }

            if (new string(guessedWord) == wordToGuess)
            {
                Console.Clear();
                DisplayWord(guessedWord);
                Console.WriteLine("\nCongratulations! You've guessed the word: " + wordToGuess);
                break;
            }
        }

        if (attemptsLeft == 0)
        {
            Console.Clear();
            DisplayHangman(attemptsLeft);
            Console.WriteLine("\nSorry, you ran out of attempts. The word was: " + wordToGuess);
        }
    }

    static void DisplayWord(char[] word)
    {
        foreach (char letter in word)
        {
            Console.Write(letter + " ");
        }
    }

    static void DisplayGuessedLetters(bool[] guessedLetters)
    {
        Console.Write("\n\nGuessed Letters: ");
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            if (guessedLetters[i])
            {
                Console.Write((char)('a' + i) + " ");
            }
        }
    }

    static void DisplayHangman(int attemptsLeft)
    {
        switch (attemptsLeft)
        {
            case 6:
                Console.WriteLine("  ____");
                Console.WriteLine(" |    |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("__|__");
                break;
            case 5:
                Console.WriteLine("  ____");
                Console.WriteLine(" |    |");
                Console.WriteLine(" |    O");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("__|__");
                break;
            case 4:
                Console.WriteLine("  ____");
                Console.WriteLine(" |    |");
                Console.WriteLine(" |    O");
                Console.WriteLine(" |    |");
                Console.WriteLine(" |");
                Console.WriteLine("__|__");
                break;
            case 3:
                Console.WriteLine("  ____");
                Console.WriteLine(" |    |");
                Console.WriteLine(" |    O");
                Console.WriteLine(" |   /|");
                Console.WriteLine(" |");
                Console.WriteLine("__|__");
                break;
            case 2:
                Console.WriteLine("  ____");
                Console.WriteLine(" |    |");
                Console.WriteLine(" |    O");
                Console.WriteLine(" |   /|\\");
                Console.WriteLine(" |");
                Console.WriteLine("__|__");
                break;
            case 1:
                Console.WriteLine("  ____");
                Console.WriteLine(" |    |");
                Console.WriteLine(" |    O");
                Console.WriteLine(" |   /|\\");
                Console.WriteLine(" |   /");
                Console.WriteLine("__|__");
                break;
            case 0:
                Console.WriteLine("  ____");
                Console.WriteLine(" |    |");
                Console.WriteLine(" |    O");
                Console.WriteLine(" |   /|\\");
                Console.WriteLine(" |   / \\");
                Console.WriteLine("__|__");
                break;
        }
    }
}
