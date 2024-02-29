using System.ComponentModel.Design;
using System.IO;
using System.Xml;

namespace Hangman_app
{
    internal class Program
    {
        //This creates fields for the Program class
        static string path = "list.txt"; //path of the txt file where words will be stored
        static string[] allWords;  //stores words from the list.txt file 
        static string[] basicWords = new[] { "apple", "computer", "fridge" }; //words that will be added to the newwly created list.txt file

        static void Main(string[] args)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("      Hangman     ");
            Console.WriteLine("------------------");

            //Checks if initializing of the game completed without errors
            //If initialize hangman returns false, the program exits
            if (!InitializeHangman())
            {
                return;
            }

            //If everything is okay, the menu is opened in the console
            Menu();
        }

        //A method to create list.txt or if it exists just read all the words in it. 
        static bool InitializeHangman()
        {
            if (!File.Exists(path)) //Checks if file exists
            {
                try
                {
                    //If it's not it creates a new file
                    File.Create(path).Close();
                    //By using StreamWriter we write basicWords in it
                    using var writer = new StreamWriter(path);
                    writer.Write(string.Join(", ", basicWords).ToLower());
                }
                catch (Exception e)
                {
                    //If error emerges we return false
                    Console.WriteLine("There was some error.");
                    return false;
                }
            }

            //After file is either created or existed we try to read words from it 
            //and save it to the allWords variable 
            try
            {
                string words = File.ReadAllText(path).Trim();
                allWords = words.Split(", ");
            }
            catch (Exception e)
            {
                //If error emerges we return false
                Console.WriteLine("There was some error");
                return false;
            }
            //If everything goes fine, we return true
            return true;
        }


        public static void Menu()
        {
            //Giving options to the user
            Console.WriteLine("Choose one");
            Console.WriteLine("1. Play a new game");
            Console.WriteLine("2. Add a new word");
            Console.WriteLine("3. Exit the program");

            //Reading the menu options
            var menuOption = Console.ReadLine().Trim();
            switch (menuOption)
            {
                case "1":
                    StartNewGame(); 
                    break;
                case "2":
                    AddNewWord();
                    break;
                default:
                    return;
            }
        }
        
        //This method adds a new word to the list and file
        public static void AddNewWord()
        {
            Console.WriteLine("Enter a new word: ");
            var word = Console.ReadLine().Trim(); //We trim any white spaces from the word
            File.WriteAllText(path, File.ReadAllText(path).Trim() + ", " + word); //We read all text from the file, add a new word, and rewrite the whole file with the modified words
            Menu(); 
        }

        //This method starts aa new game
        public static void StartNewGame()
        {
            //We save the length of the all words array in the length variable  
            int length = allWords.Length;
            //Creating a new Random object and generating random index from zero to the length of the array
            Random rand = new Random();
            int index = rand.Next(0, length);
            //We save the word on that inedx from the array
            string word = allWords[index];
            int attemptsLeft = 5;
            //We have different strings for all guesses and guessedLetters
            string guessedLetters = "";
            string allGuesses = "";


            //The actual game loop
            while (true)
            {
                //The word is found is set to true
                //If all the letters from the random word are contained in the guessed letters string, we leave it to true
                //Otherwise we set it to false
                bool wordFound = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (guessedLetters.Contains(word[i])) //Checking if each letter is contained in the guessed letters
                    {
                        Console.Write(word[i]);
                    }
                    else
                    {
                        wordFound = false;
                        Console.Write("-");
                    }
                }
                Console.WriteLine();

                if (wordFound)
                {
                    Console.WriteLine("Congratulations!!!"); //If word is found, the player wins and the game loop exits
                    break;
                }

                if (attemptsLeft < 1) //If no attempts are left, the player loses and the game loop exits
                {
                    Console.WriteLine("You lost. The word was: " + word);
                    break;
                }

                //Reading the keya nd saving the character into the guess variable 
                Console.WriteLine("Guess a letter:");
                char guess = char.ToLower(Console.ReadKey().KeyChar);
                if (allGuesses.Contains(guess)) //If guess is contained in all guesses, attempts don't decrease, and the user continues
                {
                    Console.WriteLine();
                    Console.WriteLine("You already guessed this letter");
                    continue;
                }

                allGuesses += guess; //We add the guess to all guesses
                Console.WriteLine();

                bool found = false;
                for (int i = 0; i < word.Length; i++) //Checks if any of the letters equals the entered letter, if yes sets found variable to true
                {
                    if (word[i] == guess)
                    {
                        guessedLetters += guess;
                        found = true;
                    }
                }

                if (!found) //If not found we decrease attempt and display to the console
                {
                    attemptsLeft--;
                    Console.WriteLine("Incorrect. Attempts left: " + attemptsLeft);
                }
                else
                {
                    Console.WriteLine("Nice guess");
                }
            }

            //After breaking from the loop, we return to the menu
            Menu();
        }
    }
}